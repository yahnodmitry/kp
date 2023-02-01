using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya_test
{
    public class DataOperating
    {
        public static string countryName;
        public static DoubleList<Mineral> list;
        public static void jsonDeserialization(/*DoubleList<Mineral> mineralList*/)
        {
            try 
            {
                List<Mineral> newlist;
                using (StreamReader file = File.OpenText("../../" + countryName + ".json"))
                {
                    JsonSerializer serializer = new JsonSerializer
                    {
                        TypeNameHandling = TypeNameHandling.Auto,
                    };
                    newlist = (List<Mineral>)serializer.Deserialize(file, typeof(List<Mineral>));
                }
                for (int i = 0; i < newlist.Count; i++)
                    list.add(newlist[i]);
            }

            catch(FileNotFoundException)
            {
                MessageBox.Show("Файл не знайдено");
            }

            catch(Newtonsoft.Json.JsonSerializationException)
            {
                MessageBox.Show("Файл пошкоджено");
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("ffadasdsd");
            }

        }
        public static DoubleList<Yearly> readFromCsv(string mineralName)
        {

            try
            {
                DoubleList<Yearly> yearlyList = null;
                FileStream stream = new FileStream("../../" + countryName + "yearly.sv", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                bool found = false;
                string data;
                do
                {
                    string[] cols = new string[1];
                    data = reader.ReadLine();
                    if (data != null)
                        cols = data.Split(',');
                    if (cols[0] == mineralName)
                    {
                        found = true;
                        break;
                    }
                    else if (cols[0] == "")
                    {
                        throw new StringIsEmptyException();
                    }   
                } while (data != null);
                if (found)
                {
                    var cols = data.Split(',');
                    int year = int.Parse(cols[1]) - 1;
                    do
                    {

                        if (int.Parse(cols[1]) == year + 1)
                        {
                            if (System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0] == ',')
                            {
                                cols[2] = cols[2].Replace('.', ',');
                                cols[3] = cols[3].Replace('.', ',');
                                cols[4] = cols[4].Replace('.', ',');
                            }
                            Yearly nextYear = new Yearly
                            {
                                year = int.Parse(cols[1]),
                                value = double.Parse(cols[2]),
                                exp = double.Parse(cols[3]),
                                income = double.Parse(cols[4])

                            };
                            if (yearlyList == null)
                                yearlyList = new DoubleList<Yearly>();
                            yearlyList.add(nextYear);
                            year = int.Parse(cols[1]);
                        }
                        //else if (int.Parse(cols[1]) > year + 1)
                        //{
                        //    Yearly nextYear = new Yearly
                        //    {
                        //        year = year + 1,
                        //        value = 0,
                        //        income = 0,
                        //        exp = 0
                        //    };
                        //    year++;
                        //}
                        else
                        {
                            MessageBox.Show("Відсутня інформація") ;
                            return null;
                        }
                        data = reader.ReadLine();
                        if (data != null)
                            cols = data.Split(',');
                    } while (cols[0] == mineralName && data != null);
                }
                else
                {
                    MessageBox.Show("Такої руди в цій країні немає, будь ласка, введіть іншу.");
                    return null;
                }
                reader.Close();
                stream.Close();
                return yearlyList;
            }

            catch(FileNotFoundException)
            {
                list = null;
                return null;
            }

            catch (StringIsEmptyException a)
            {
                MessageBox.Show(a.Message);
                return null;
            }
        }
        public static void write(string value, string exp, string income, DoubleList<Mineral> mineralList, Mineral mineral)
        {
            int year = mineral.list.tail.data.year + 1;
            mineral.Value -= double.Parse(value);

            List<Mineral> newlist = new List<Mineral>();
            Node<Mineral> temp = mineralList.head;
            while(temp != null)
            {
                newlist.Add(temp.data);
            }

            using (StreamWriter file = File.CreateText("../../" + countryName + ".json"))
            {
                JsonSerializer serializer = new JsonSerializer
                {
                    TypeNameHandling = TypeNameHandling.All,
                    Formatting = Formatting.Indented
                };
                serializer.Serialize(file, newlist);
            }

            string half1 = "";
            string half2 = "";
            string currentline = "";
            FileStream stream = new FileStream("../../" + countryName + "yearly.csv", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            currentline = "";
            string[] cols1 = new String[1];
            while ((cols1[0] != newlist[0].Name || int.Parse(cols1[1]) != newlist[0].list.tail.data.year) && currentline != null)
            {
                currentline = reader.ReadLine();
                cols1 = currentline.Split(',');
                half1 += currentline + '\n';
            }
            half1.Remove(half1.Length - 2, 1);
            half2 = reader.ReadToEnd();
            half2.Remove(0, 1);
            half2.Remove(half2.Length - 2, 1);
            reader.Close();
            stream.Close();

            if(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0] == ',')
            {
                value = value.Replace(',', '.');
                exp = exp.Replace(',', '.');
                income = income.Replace(',', '.');
            }

            string newdata = newlist[0].Name + ',' +
                year.ToString() + ',' +
                value + ',' +
                exp + ',' +
                income;
            stream = new FileStream("../../" + countryName + "yearly.csv", FileMode.Open, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            //string full = half1 + newdata;
            //if (half2 != "")
            //    full += half2;

            writer.Write(half1);
            writer.Write(newdata);
            if (half2 != "")
                writer.Write('\n' + half2);
            //writer.Write(full);
            writer.Flush();
            writer.Close();
            stream.Close();
        }
    }
}
