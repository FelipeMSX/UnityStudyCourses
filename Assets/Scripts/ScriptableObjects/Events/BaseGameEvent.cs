using Assets.Scripts.ScriptableObjects.Listeners;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Events
{
    public abstract class BaseGameEvent<T> : ScriptableObject
    {
        private readonly List<IGameEventListener<T>> _listeners = new List<IGameEventListener<T>>();

        public void Raise(T item)
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].OnEventRaised(item);
            }
        }
        public void RegisterListener(IGameEventListener<T> listener)
        {
            if (_listeners.Contains(listener))
                return;

            _listeners.Add(listener);
        }

        public void UnregisterListener(IGameEventListener<T> listener)
        {
            if (!_listeners.Contains(listener))
                return;

            _listeners.Remove(listener);
        }
    }
}