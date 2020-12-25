using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    public class QNode<T>
    {
        public T Data;
        public QNode<T> Next;

        public QNode(T data)
        {
            Data = data;
        }
       
    }

    public class MyQueue<T> : IEnumerable<T>
    {
        QNode<T> head;
        QNode<T> last;
        int count;
        public void Enqueue(T data)
        {
            QNode<T> node = new QNode<T>(data);
            if (count == 0)
            {
                head = last = node;
            }
            else
            {
                last.Next = node;
                last = node;
            }
            count++;  }
        public void Dequeue()
        {
            if (count == 0)
            {
                throw new InvalidOperationException();
            }
            head = head.Next;
            count--;
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            QNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            MyQueue<int> q = new MyQueue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            foreach(var i in q)
            {
                Console.WriteLine(i);
            }

            q.Dequeue();
            foreach (var i in q)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();


        }
    }
}
