using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Weapons.Behaviours
{
    public class RecycleManager<T> where T : class
    {

        /// <summary>
        /// Resolves a transition effect between an active and deactivated object, 
        /// some times if the object is put in the recycle list and remove fast can occasionally visual issues.
        /// </summary>
        private const int MIN_AMOUNT_TO_REMOVE = 1;
        public int MaxSize { get; }

        //LinkedList was chosen because it has a insert/remove O(1).
        private readonly LinkedList<T> _recycleLinkedList;

        public RecycleManager(int maxSize)
        {
            _recycleLinkedList = new LinkedList<T>();
            MaxSize = maxSize;
        }

        /// <summary>
        /// If the list is full returns false and it doesn't add the item, otherwise the item will be inserted in the recycle list.
        /// </summary>
        public bool AddIfNecessary(T item)
        {
            if (_recycleLinkedList.Count == MaxSize)
                return false;

            _recycleLinkedList.AddFirst(item);

            return true;
        }

        /// <summary>
        /// Returns null if the recycle list doesn't contain an item, but otherwise will return the item.
        /// </summary>
        public T Remove()
        {
            if (_recycleLinkedList.Count == 0 || _recycleLinkedList.Count <= MIN_AMOUNT_TO_REMOVE)
            {
                return null;
            }
            else
            {
                T item = _recycleLinkedList.Last.Value;
                _recycleLinkedList.RemoveLast();
                return item;

            }
        }
    }
}
