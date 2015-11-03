namespace Stack
{
    using System;

    public class MyStack<T>
    {
        private const int InitialSize = 4;

        private T[] elements;
        private int currentSize;

        public MyStack()
        {
            this.elements = new T[InitialSize];
            this.currentSize = 0;
        }

        public int Count
        {
            get
            {
                return this.currentSize;
            }
        }

        public void Push(T value)
        {
            if (this.currentSize == this.elements.Length)
            {
                this.AutoGrow();
            }

            this.elements[this.currentSize] = value;
            this.currentSize++;
        }

        public T Pop()
        {
            if (this.currentSize == 0)
            {
                throw new ArgumentException("There are no elements left in the stack to be removed");
            }

            var elemetToReturn = this.elements[this.currentSize - 1];
            this.currentSize--;
            return elemetToReturn;
        }

        public T Peek()
        {
            if (this.currentSize == 0)
            {
                throw new ArgumentException("The stack is empty");
            }

            return this.elements[this.currentSize - 1];
        }

        public void Clear()
        {
            this.elements = new T[InitialSize];
            this.currentSize = 0;
        }

        private void AutoGrow()
        {
            int nextSize = this.currentSize * 2;
            T[] newElements = new T[nextSize];
            Array.Copy(this.elements, newElements, this.elements.Length);
            this.elements = newElements;
        }
    }
}