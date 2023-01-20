using System.Windows.Forms;

namespace Kursovaya_test
{


    //public class Node
    //{
    //    public Mineral mineral;
    //    public Node next;
    //    public Node prev;
    //    public Node(Mineral mineral = null, Node next = null, Node prev = null)
    //    {
    //        this.mineral = mineral;
    //        this.next = next;
    //        this.prev = prev;
    //    }
    //}

    //public class Node_struct
    //{
    //    public Yearly year;
    //    public Node_struct next;
    //    public Node_struct prev;
    //    public Node_struct(Yearly year, Node_struct next = null, Node_struct prev = null)
    //    {
    //        this.year = year;
    //        this.next = next;
    //        this.prev = prev;
    //    }
    //}

    //public class Lst
    //{

    //    public Node head;
    //    Node tail;
    //    int size;
    //    public Lst()
    //    {
    //        size = 0;
    //        head = null;
    //        tail = null;
    //    }

    //    public void push_back(Mineral mineral)
    //    {
    //        if (head == null)
    //        {
    //            head = new Node(mineral);
    //            tail = head;
    //        }
    //        else
    //        {
    //            Node temp = new Node(mineral);
    //            temp.prev = tail;
    //            tail.next = temp;
    //            tail = temp; 
    //        }
    //        size++;
    //    }
    //}

    //public class Lst_struct
    //{

    //    public Node_struct head;
    //    Node_struct tail;
    //    int size;
    //    public Lst_struct()
    //    {
    //        size = 0;
    //        head = null;
    //        tail = null;
    //    }

    //    public void push_back(Yearly year)
    //    {
    //        if (head == null)
    //        {
    //            head = new Node_struct(year);
    //            tail = head;
    //        }
    //        else
    //        {
    //            Node_struct temp = new Node_struct(year);
    //            temp.prev = tail;
    //            tail.next = temp;
    //            tail = temp;
    //        }
    //        size++;
    //    }
    //}

    //public class aNode<T>
    //{
    //    public aNode()
    //    {

    //    }
    //    public aNode(T data)
    //    {
    //        this.data = data;
    //    }
    //    public T data { get; set; }
    //    public aNode<T> prev { get; set; }
    //    public aNode<T> next { get; set; }
    //}

    //public class aList<T> 
    //{
    //    public aNode<T> head;
    //    public aNode<T> tail;
    //    int size;
    //    public int Size { get { return size; } /*set { size = value; } */}

    //    public void push_back(T data)
    //    {
    //        if (head == null)
    //        {
    //            head = new aNode<T>(data);
    //            tail = head;
    //        }
    //        else
    //        {
    //            aNode<T> temp = new aNode<T>(data);
    //            temp.prev = tail;
    //            tail.next = temp;
    //            tail = temp;
    //        }
    //        size++;
    //    }
    //}
    public class Node<T>
    {
        public T data;
        public Node<T> previous;
        public Node<T> next;

        public Node(T data)
        {
            this.data = data;
        }
        public Node()
        {

        }
    }

    public class DoubleList<T>
    {
        public Node<T> head;
        public Node<T> tail;
        public int size;

        public void add(T data)
        {
            if (head == null)
            {
                Node<T> node = new Node<T>(data);
                head = node;
                tail = node;
            }
            else
            {
                Node<T> node = new Node<T>(data);
                tail.next = node;
                node.previous = tail;
                tail = node;
            }
            size++;
        }
        public Node<T> find(int number)
        {
            Node<T> temporary = head;
            for (int i = 0; i < number; i++)
            {
                temporary = temporary.next;
                if (temporary == null)
                    break;
            }
            if (temporary != null)
                return temporary;
            else
                return null;
        }
        public void delete(int number)
        {
            Node<T> temporary = head;
            for (int i = 0; i < number; i++)
            {
                temporary = temporary.next;
                if (temporary == null)
                    break;
            }
            if (temporary != null)
            {
                if (temporary.next != null)
                    temporary.next.previous = temporary.previous;
                else
                    tail = temporary.previous;
                if (temporary.previous != null)
                    temporary.previous.next = temporary.next;
                else
                    head = temporary.next;
                size--;
            }
        }
    }

    public class BinaryHeap
    {
        private DoubleList<Mineral> list;
        public int heapSize
        {
            get
            {
                return list.size;
            }
        }
        public bool sortInc;

        public void sortByIncome(DoubleList<Mineral> list)
        {
            sortInc = true;
            heapSort(list);
        }

        public void sortByExp(DoubleList<Mineral> list)
        {
            sortInc=false;
            heapSort(list);
        }

        public void heapify(int i)
        {
            int leftChild;
            int rightChild;
            int largestChild;

            for (; ; )
            {
                leftChild = 2 * i + 1;
                rightChild = 2 * i + 2;
                largestChild = i;

                if(sortInc)
                {
                    if (leftChild < heapSize &&
                   list.find(leftChild).data.Income > list.find(largestChild).data.Income)
                    {
                        largestChild = leftChild;
                    }

                    if (rightChild < heapSize &&
                        list.find(rightChild).data.Income > list.find(largestChild).data.Income)
                    {
                        largestChild = rightChild;
                    }
                }
                else
                {
                    if (leftChild < heapSize &&
                   list.find(leftChild).data.Exp > list.find(largestChild).data.Exp)
                    {
                        largestChild = leftChild;
                    }

                    if (rightChild < heapSize &&
                        list.find(rightChild).data.Exp > list.find(largestChild).data.Exp)
                    {
                        largestChild = rightChild;
                    }
                }
                if (largestChild == i)
                {
                    break;
                }
                Mineral temporary = list.find(i).data;
                list.find(i).data = list.find(largestChild).data;
                list.find(largestChild).data = temporary;


                i = largestChild;
            }
        }
        public void buildHeap(DoubleList<Mineral> list)
        {
            this.list = new DoubleList<Mineral>();
            for (int i = 0; i < list.size; i++)
            {
                this.list.add(list.find(i).data);
            }
            for (int i = (heapSize / 2) - 1; i >= 0; i--)
            {
                heapify(i);
            }
        }
        public Mineral getMax()
        {
            Mineral result = this.list.find(0).data;
            this.list.find(0).data = list.find(heapSize - 1).data;
            this.list.delete(heapSize - 1);
            return result;
        }
        public void heapSort(DoubleList<Mineral> list)
        {
            buildHeap(list);
            for (int i = 0; i < list.size; i++)
            {
                list.find(i).data = getMax();
                heapify(0);
            }
        }
    }


}
