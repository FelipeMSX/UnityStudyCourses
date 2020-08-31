using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Assets.Scripts.ScriptableObjects.UnityEvents
{
    [System.Serializable] public class UnityInputSystemEvent : UnityEvent<InputAction.CallbackContext> { }
}
