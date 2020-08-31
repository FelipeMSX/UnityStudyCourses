using Assets.Scripts.ScriptableObjects.Events;

using UnityEngine;
using UnityEngine.InputSystem;

public class InputControlsController : MonoBehaviour
{

    [SerializeField]
    private InputSystemEvent OnMovePerformed = null;

    [SerializeField]
    private InputSystemEvent OnShootPerformed = null;


    private InputControls _controls;

    private void Awake()
    {
        _controls = new InputControls();

        _controls.Player.Movement.performed += Move_performed;
        _controls.Player.Shoot.performed += Shoot_performed;
    }

    private void Shoot_performed(InputAction.CallbackContext obj)
    {
        OnShootPerformed?.Raise(obj);
    }

    private void Move_performed(InputAction.CallbackContext obj)
    {
        OnMovePerformed?.Raise(obj);
    }


    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void OnDestroy()
    {
        _controls.Player.Movement.performed -= Move_performed;
        _controls.Player.Shoot.performed -= Shoot_performed;

    }
}
