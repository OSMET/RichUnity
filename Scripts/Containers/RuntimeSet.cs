using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RichUnity.Containers
{
    public abstract class RuntimeSet<T> : ScriptableObject
    {
        [SerializeField]
        private List<T> items = new List<T>();

        public void Add(T item)
        {
            if (!Contains(item))
            {
                items.Add(item);
            }
        }

        public void Remove(T item)
        {
            if (Contains(item))
            {
                items.Remove(item);
            }
        }

        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        public T Find(Predicate<T> match)
        {
            return items.Find(match);
        }

        public List<T> FindAll(Predicate<T> match)
        {
            return items.FindAll(match);
        }

        public List<T> ToList()
        {
            return items.ToList();
        }
    }
}