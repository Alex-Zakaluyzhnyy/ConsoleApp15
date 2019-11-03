using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{

    public class myQueue
    {
        private int n;
        private int head;
        private int tail;
        private int[] array;
        private int maxSize;
        private bool operation;

        public myQueue()
        {
            n = 1;
            array = new int[n];
            head = tail = 0;
            maxSize = Int32.MaxValue;
        }

        public myQueue(int maxSize)
        {
            n = 1;
            array = new int[n];
            head = tail = 0;
            this.maxSize = maxSize;
        }

        private int[] Resize(int[] array)
        {
            if (operation)
            {
                int[] newArray = new int[this.tail + 1];
                for (int i = 0; i < this.array.Length; i++)
                    newArray[i] = array[i];
                return newArray;
            }
            else
            {
                int[] newArray = new int[this.tail-1];
                for (int i = this.tail - 1; i >= head; i--)
                    newArray[i-1] = array[i];
                return newArray;
            }
        }

        private bool isEmpty()
        {
            var emptyOrNot = (this.head == 0 && this.tail == 0) ? true : false;
            return emptyOrNot;
        }

        public void Enqueue(int number)
        {
            operation = true;
            if (tail + 1 > maxSize)
                throw new ArgumentException();
            else
            {
                this.array = Resize(this.array);
                this.array[tail] = number;
                this.tail++;
            }
        }

        public int Dequeue()
        {
            if (isEmpty())
                throw new ArgumentException();
            else
            {
                operation = false;
                var outputElement = this.array[head];
                head++;
                this.array = Resize(this.array);
                head = 0;
                tail--;
                return outputElement;
            }
        }

        public void Print()
        {
            foreach (var elem in this.array)
                Console.Write(elem + "\t");
            Console.WriteLine();
        }
            
    }



    class Program
    {
        static void Main(string[] args)
        {
            myQueue queque = new myQueue();
            queque.Enqueue(5);
            queque.Enqueue(3);
            queque.Enqueue(2);
            queque.Enqueue(4);
            queque.Enqueue(1);
            queque.Print();
            queque.Dequeue();
            queque.Print();
            queque.Enqueue(15);
            queque.Enqueue(2);
            queque.Enqueue(4);
            queque.Enqueue(1);
            queque.Print();
            queque.Dequeue();
            queque.Print();
            queque.Dequeue();
            queque.Print();
            queque.Dequeue();
            queque.Print();
            queque.Dequeue();
            queque.Print();
            queque.Dequeue();
            queque.Print();
            queque.Enqueue(6);
            queque.Print();
            queque.Dequeue();
            queque.Dequeue();
            queque.Dequeue();
            queque.Dequeue();
            queque.Dequeue();
            queque.Print();
            Console.ReadLine();
        }
    }
}
