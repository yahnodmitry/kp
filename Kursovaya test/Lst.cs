using System.Windows.Forms;

namespace Kursovaya_test
{


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

        /// <summary>
        /// строки 181 и 189 я немного изменил и добавил туда исключительные ситуации
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Node<T> find(int number)
        {
            if (number < 0 || size <= number) return null; //исключительная ситуация 
            Node<T> temporary = head;
            for (int i = 0; i < number; i++)
                temporary = temporary.next;
            return temporary;
        }
        public void delete(int number)
        {
            if (number < 0 || size <= number) return;     //исключительная ситуация 
            Node<T> temporary = head;
            for (int i = 0; i < number; i++)
               temporary = temporary.next;
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
