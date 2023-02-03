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
        public static void jsonDeserialization()
        {
            try 
            {
                List<Mineral> newlist;
                using (StreamReader file = File.OpenText("../../Resources/" + countryName + ".json"))
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
                MessageBox.Show("Файл JSON не знайдено");
            }

            catch (Newtonsoft.Json.JsonSerializationException)
            {
                MessageBox.Show("Неправильний тип у файлі JSON");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Файл CSV не знайдено");
            }

        }
        public static DoubleList<Yearly> readFromCsv(string mineralName)
        {

            try
            {
                DoubleList<Yearly> yearlyList = new DoubleList<Yearly>();
                FileStream stream = new FileStream("../../Resources/" + countryName + "yearly.csv", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                try
                { 
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
                    } while (data != null);
                    if (found)
                    {
                        var cols = data.Split(',');
                        do
                        {
                            try
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
                                yearlyList.add(nextYear);
                                
                            }
                            catch
                            {

                            }
                            data = reader.ReadLine();
                            if (data != null)
                                cols = data.Split(',');
                        } while (cols[0] == mineralName && data != null);
                    }
                    else
                    {
                        throw new MineralNotFoundException();
                    }
                    reader.Close();
                }
                catch(MineralNotFoundException)
                {
                    return null;
                }
                finally
                {
                    reader.Close();
                }
               
                stream.Close();
                return yearlyList;
            }

            catch(FileNotFoundException)
            {
                list = null;
                return null;
            }

        }
        public static void write(string value, string exp, string income, DoubleList<Mineral> mineralList, Mineral mineral)
        {
            double v=0, e=0, i=0;

            try
            {
                if (System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0] == ',')
                {
                    value.Replace('.', ',');
                    exp.Replace('.', ',');
                    income.Replace('.', ',');
                }
                else
                {
                    value.Replace(',', '.');
                    exp.Replace(',', '.');
                    income.Replace(',', '.');
                }
                if (!double.TryParse(value, out v) || !double.TryParse(exp, out e) || !double.TryParse(income, out i))
                {
                    throw new WrongFormatException();
                }


                int year = mineral.list.tail.data.year + 1;
                mineral.Value -= v;

                List<Mineral> newlist = new List<Mineral>();
                Node<Mineral> temp = mineralList.head;
                while (temp != null)
                {
                    newlist.Add(temp.data);
                    temp = temp.next;
                }

                using (StreamWriter file = File.CreateText("../../Resources/" + countryName + ".json"))
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
                FileStream stream = new FileStream("../../Resources/" + countryName + "yearly.csv", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                currentline = "";
                string[] cols1 = new String[1];
                while ((cols1[0] != mineral.Name || int.Parse(cols1[1]) != newlist[0].list.tail.data.year) && currentline != null)
                {
                    currentline = reader.ReadLine();
                    cols1 = currentline.Split(',');
                    half1 += currentline + '\n';
                }
                //while ((cols1[0] == newlist[0].Name || int.Parse(cols1[1]) != newlist[0].list.tail.data.year) && currentline != null)
                //{
                //    currentline = reader.ReadLine();
                //    cols1 = currentline.Split(',');
                //    half1 += currentline + '\n';
                //}
                half1.Remove(half1.Length - 2, 1);
                half2 = reader.ReadToEnd();
                half2.Remove(0, 1);
                half2.Remove(half2.Length - 2, 1);
                reader.Close();
                stream.Close();

                if (System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0] == ',')
                {
                    value = value.Replace(',', '.');
                    exp = exp.Replace(',', '.');
                    income = income.Replace(',', '.');
                }

                string newdata = mineral.Name + ',' +
                    year.ToString() + ',' +
                    value + ',' +
                    exp + ',' +
                    income;
                stream = new FileStream("../../Resources/" + countryName + "yearly.csv", FileMode.Open, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);

                writer.Write(half1);
                writer.Write(newdata);
                if (half2 != "")
                writer.Write('\n' + half2);
                writer.Flush();
                writer.Close();
                stream.Close();
                MessageBox.Show("Дані записано.");
            }
            catch(WrongFormatException)
            {
                MessageBox.Show("Неправильний формат даних");
            }     
        }
    }
}
