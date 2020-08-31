using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "New Void Event", menuName = "ScriptableObjects/New Void Event", order = 1)]
    public class VoidEvent: BaseGameEvent<Void>
    {
        public void Raise() => Raise(new Void());
    }
}
