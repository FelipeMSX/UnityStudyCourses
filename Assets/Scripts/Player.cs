using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public float Speed = 3.5f;

        public Weapon Weapon;

        private Vector2 _horizontalVerticalMove;
        private float _horizontalBoundLimit = 22f;
        private float _verticalBoundLimit = 4.4f;


        private void Update()
        {
            if(_horizontalVerticalMove != Vector2.zero)
            {
                transform.Translate((_horizontalVerticalMove.x * Vector3.right + _horizontalVerticalMove.y * Vector3.up) * Speed * Time.deltaTime);
            }

            CheckPlayerBounds();
        }

        //It's called by a ScriptableObject
        public void MovePerformed(InputAction.CallbackContext obj)
        {
            _horizontalVerticalMove = obj.ReadValue<Vector2>();
        }

        //It's called by a ScriptableObject
        public void ShootPerformed(InputAction.CallbackContext obj)
        {
            Weapon.Shoot();
        }

        private void CheckPlayerBounds()
        {
            //If the player trespass the horizontal limit, so it must be teleported to the opposite side.
            if (transform.position.x >= _horizontalBoundLimit || transform.position.x <= -_horizontalBoundLimit)
            {
                transform.position = new Vector3(transform.position.x >= _horizontalBoundLimit ? -_horizontalBoundLimit : _horizontalBoundLimit, transform.position.y, transform.position.z);
            }
                
            transform.position = new Vector3(transform.position.x,Mathf.Clamp(transform.position.y, -_verticalBoundLimit, _verticalBoundLimit), transform.position.z);
        }
    }
}
