﻿namespace TurboCollections
{
   
    public class TurboList<T>
    {

        T[] items = Array.Empty<T>();

        /// <summary>
        /// Gives the amount of items inside of the List
        /// </summary>
        public int Count
        {
            get;
            private set;
        }

        /// <summary>
        /// Gives the size of the List
        /// </summary>
        public int Lenght => items.Length;
        
        /// <summary>
        /// Adds an item to the list
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            EnsureSize(Count+1);
            items[Count++] = item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        void EnsureSize(int size)
        {
            if (items.Length >= size)
            {
                return;
            }

            //Double array size or set to given size if not enough.
            int newSize = Math.Max(size, items.Length * 2);
            
            T[] newArray = new T[newSize];
            for (int i = 0; i < Count; i++)
            {
                newArray[i] = items[i];
            }
            //Assign new array 
           items = newArray;

        }

        T[] ResizeArray(int sizeChange)
        {
            //Resizing the array
            T[] newArray = new T[Count + sizeChange];
            if (items != Array.Empty<T>())
            {
                for (int i = 0; i < Count; i++)
                {
                    newArray[i] = items[i];
                }
            }
            
            return newArray;
        }

        public T Get(int index)
        {
            return items[index];
        }

        public void Set(int index, T item)
        {
            if (index >= Count)
            {
                EnsureSize(index+1);
                Count = index + 1;
            }
             items[index] = item;
        }

        public void Clear()
        {
            items = Array.Empty<T>();
            Count = 0;
        }
/// <summary>
/// // Removes one item from the list.
/// </summary>
/// <param name="index"></param>

public void RemoveAt(int index)
{
    T[] newArray = new T[Count - 1];
    for (int i = 0; i < index; i++)
    {
        newArray[i] = items[i];
    }

    for (int i = index; i < (Count) - index; i++)
    {
        newArray[i] = items[i + 1];
    }

    items = newArray;
    Count--;
}

       public bool Contains(T item)
       {
           for (var i = 0; i < items.Length; i++)
           {
               if (items[i].Equals(item))
               {
                   return true;
               }
           }

           return false;
       }

       /// <summary>
       /// // returns the index of the given item if it is in the list, else -1.
       /// </summary>
       /// <param name="item"></param>
       /// <returns></returns>
       public int IndexOf(T item)
       {
           for (var i = 0; i < Count; i++)
           {
               if (items[i].Equals(item))
               {
                    return i;
               }
           }

            return -1;
       }
       
       public IEnumerable<int> AllIndicesOf(T item)
       {
           bool hasElement = false;
           for (var i = 0; i < Count; i++)
           {
               if (items[i].Equals(item))
               {
                   

                   hasElement = true;
                   yield return i;
               }
           }


           if (hasElement == false)
           {
               yield return -1;
           }
           
       }

       /// <summary>
       ///  Removes the specified item from the list, if it can be found.
       /// </summary>
       /// <param name="item"></param>
       public void Remove(T item)
       {
           if (IndexOf(item) != -1)
           {
               RemoveAt(IndexOf(item));
           }
           else
           {
               throw new System.Exception("Item does not exit in list");
           }
       }
       

       public void AddRange(IEnumerable<T> things)
       {
           
           foreach (var thing in things)
           {
               Add(thing);
           }
       }

    } 
}
