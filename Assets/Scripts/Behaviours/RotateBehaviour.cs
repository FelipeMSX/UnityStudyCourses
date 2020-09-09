using UnityEngine;

namespace Assets.Scripts
{
    public class RotateBehaviour : MonoBehaviour
    {
        public Axis AxisToRotate;

        public float RotationSpeed = 80f;


        private void Update()
        {
            if (AxisToRotate == Axis.X)
            {
                transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime, Space.Self);
            }
            else if (AxisToRotate == Axis.Y)
            {
                transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime, Space.Self);
            }
            else
            {
                transform.Rotate(Vector3.forward * RotationSpeed * Time.deltaTime, Space.Self);
            }
        }
    }

    public enum Axis { X, Y, Z };
}
