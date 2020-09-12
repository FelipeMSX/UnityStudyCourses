using UnityEngine;

namespace Assets.Scripts
{
    public class RotateBehaviour : MonoBehaviour
    {
        public Axis AxisToRotate;

        public float RotationSpeed = 80f;

        [SerializeField]
        private bool _opposite = true;
        public bool Opposite
        {
            get => _opposite;
            set => _opposite = value;
        }


        private void Update()
        {
            transform.Rotate(GetVector3WithClockWise() * RotationSpeed * Time.deltaTime, Space.Self);
        }

        private Vector3 GetVector3WithClockWise()
        {
            if (AxisToRotate == Axis.X && !Opposite)
                return Vector3.right;
            else if (AxisToRotate == Axis.X && Opposite)
                return Vector3.left;
            else if (AxisToRotate == Axis.Y && !Opposite)
                return Vector3.up;
            else if (AxisToRotate == Axis.Y && Opposite)
                return Vector3.down;
            else if (AxisToRotate == Axis.Z && !Opposite)
                return Vector3.forward;
            else
                return Vector3.back;
        }
    }

    public enum Axis { X, Y, Z };
}
