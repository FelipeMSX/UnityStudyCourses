using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "New Input System Event", menuName = "ScriptableObjects/New Input System Event", order = 2)]
    public class InputSystemEvent : BaseGameEvent<InputAction.CallbackContext>
    {
    }
}