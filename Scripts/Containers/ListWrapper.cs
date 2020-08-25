using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RichUnity.Containers
{
    [Serializable]
    public class ListWrapper<T> : IList<T>
    {
        [SerializeField]
        private List<T> L;
        
        public List<T> List
        {
            get
            {
                return L;
            }
            set
            {
                L = value;
            }
        }

        public int IndexOf(T item)
        {
            return L.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            L.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            L.RemoveAt(index);
        }

        public T this[int index]
        {
            get
            {
                return L[index];
            }
            set
            {
                L[index] = value;
            }
        }

        public void Add(T item)
        {
            L.Add(item);
        }

        public void Clear()
        {
            L.Clear();
        }

        public bool Contains(T item)
        {
            return L.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            L.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return L.Remove(item);
        }

        public int Count
        {
            get
            {
                return L.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return ((IList<T>) L).IsReadOnly;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return L.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return L.GetEnumerator();
        }
    }
}