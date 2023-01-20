namespace Kursovaya_test
{
    public struct Yearly
    {
        public int year;
        public double value;
        public double income;
        public double exp;
    }
    public abstract class Mineral
    {
        protected string name;
        protected double value;
        protected double income;
        protected double exp;
        public DoubleList<Yearly> list;
        public Mineral(DoubleList<Yearly> list, string name, double value)
        {
            this.list = list;
            this.name = name;
            this.value = value;

            double sumincome = 0, sumexp = 0;
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
        public string Name
        {
            get { return name; }
        }
        public double Value
        {
            get { return value; }
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
        static private string measure = "";
        public Solid(DoubleList<Yearly> list = null, string name = "", double value = 0)
            : base(list, name, value)
        {

        }
    }

    public class Liquid : Mineral
    {
        static private string measure = "";
        public Liquid(DoubleList<Yearly> list = null, string name = "", double value = 0)
            : base(list, name, value)
        {

        }
    }

    public class Gas : Mineral 
    {
        static private string measure = "";
        public Gas(DoubleList<Yearly> list = null, string name = "", double value = 0)
            : base(list, name, value)
        {

        }
    }
}
