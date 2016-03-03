using System.Threading;

namespace UnitTesting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CustomQueue<T>
    {
        public void Enqueue(T element)
        {
            var newNode = new QueueNode<T>(element);

            if (this.Count == 0)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                this.tail.NextNode = newNode;
                this.tail = newNode;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            var element = this.head.Value;
            this.head = this.head.NextNode;

            this.Count--;

            return element;
        }

        public IEnumerable<T> 
    }
}
