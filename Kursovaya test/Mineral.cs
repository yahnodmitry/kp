using Newtonsoft.Json;

namespace Kursovaya_test
{
    public struct Yearly
    {
        public int year;
        public double value;
        public double income;
        public double exp;
    }
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class Mineral
    {
        protected string name;
        protected double value;
        protected double income;
        protected double exp;
        public DoubleList<Yearly> list;
        public Mineral(string name, double value)
        {
            this.name = name;
            this.value = value;
            list = DataOperating.readFromCsv(name);

            double sumincome = 0, sumexp = 0;
            if (this.list != null)
            {

                Node<Yearly> temp = this.list.head;
                do
                {
                    sumincome += temp.data.income;
                    sumexp += temp.data.exp;
                    temp = temp.next;
                } while (temp != null);
                this.income = sumincome / this.list.size;
                this.exp = sumexp / this.list.size;
            }
        }
        [JsonProperty]
        public string Name
        {
            get { return name; }
        }
        [JsonProperty]
        public double Value
        {
            get { return value; }
            set { this.value = value; }
        }
        public double Income
        {
            get { return income; }
        }
        public double Exp
        {
            get { return exp; }
        }
    }
    public class Solid : Mineral
    {
        public Solid(string name = "", double value = 0)
            : base( name, value)
        {

        }
    }

    public class Liquid : Mineral
    {
        public Liquid(string name = "", double value = 0)
            : base(name, value)
        {

        }
    }

    public class Gas : Mineral 
    {
        public Gas( string name = "", double value = 0)
            : base( name, value)
        {

        }
    }
}
