using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class GenericList<T>
    {
        private T[] allElements;
        private int elementsCount;
        public GenericList(int capacity)
        {
            this.allElements = new T[capacity];
            this.elementsCount = 0;
        }

        public T Max()
        {
            dynamic result = long.MinValue;
            for (int i = 1; i < this.allElements.Length; i++)
            {
                if (this.allElements[i] > result)
                {
                    result = this.allElements[i];
                }
            }
            return result;
        }

        public T Min()
        {
            dynamic result = long.MaxValue;
            for (int i = 0; i < this.allElements.Length; i++)
            {
                if (this.allElements[i] < result)
                {
                    result = this.allElements[i];
                }
            }
            return result;
        }

        public void AddElement(T element)
        {
            if (this.elementsCount == this.allElements.Length)
            {
                T[] newList = new T[this.allElements.Length*2];
                for (int i = 0; i < this.allElements.Length; i++)
                {
                    newList[i] = this.allElements[i];
                }
                newList[this.elementsCount] = element;
                this.elementsCount++;
                this.allElements = newList;
            }
            else
            {
                this.allElements[this.elementsCount] = element;
                this.elementsCount++;
            }
        }


        public T GetElementByIndex(int index)
        {
            T result = default(T);
            result = this.allElements[index];

            return result;
        }

        public void RemoveElementByIndex(int index)
        {
            for (int i = index; i < this.elementsCount-1; i++)
            {
                if (i + 1 <= this.elementsCount-1)
                {
                    this.allElements[i] = this.allElements[i + 1];
                }
            }

            this.allElements[this.elementsCount-1] = default(T);
            this.elementsCount--;
        }

        public void InsertElement(int index, T newElement)
        {
            if (index <= this.allElements.Length)
            {
                if (this.elementsCount == this.allElements.Length)
                {
                    T[] newList = new T[this.allElements.Length * 2];
                    for (int i = 0; i < this.allElements.Length; i++)
                    {
                        newList[i] = this.allElements[i];
                    }

                    for (int i = this.elementsCount - 1; i >= index; i--)
                    {
                        newList[i + 1] = newList[i];
                    }
                    this.elementsCount++;
                    this.allElements = newList;
                    this.allElements[index] = newElement;
                }
                else
                {
                    for (int i = this.elementsCount - 1; i >= index; i--)
                    {
                        this.allElements[i + 1] = this.allElements[i];
                    }
                    this.allElements[index] = newElement;
                    this.elementsCount++;
                }
            }
            else
            {
                Console.WriteLine("Index out of range!");
            }
        }


        public void ClearList()
        {
            this.allElements = new T[this.allElements.Length];
        }


        public int FindElement(T element)
        {
            int result = -1;
            for (int i = 0; i < this.allElements.Length; i++)
            {
                if (this.allElements[i].Equals(element))
                {
                    result = i;
                    break;
                }
            }
            return result;
        }


        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("All elements:");
            for (int i = 0; i < this.elementsCount; i++)
            {
                result.AppendLine(allElements[i].ToString());
            }
            return result.ToString();
        }
    }
}
