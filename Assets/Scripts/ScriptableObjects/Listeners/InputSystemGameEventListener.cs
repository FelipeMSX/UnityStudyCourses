using Assets.Scripts.ScriptableObjects.Events;
using Assets.Scripts.ScriptableObjects.UnityEvents;
using UnityEngine.InputSystem;

namespace Assets.Scripts.ScriptableObjects.Listeners
{
    public class InputSystemGameEventListener : BaseGameEventListener<InputAction.CallbackContext, InputSystemEvent, UnityInputSystemEvent>
    {
    }
}
