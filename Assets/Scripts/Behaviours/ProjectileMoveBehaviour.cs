using UnityEngine;

namespace Assets.Scripts.Behaviours
{
    public class ProjectileMoveBehaviour : MonoBehaviour
    {
        private float _projectileSpeed = 0f;

        private void Update()
        {
            if (_projectileSpeed == 0f)
                return;

            this.transform.Translate(Vector3.up * _projectileSpeed * Time.deltaTime);
        }


        public void UpdateSpeed(float speed)
        {
            _projectileSpeed = speed;
        }
    }
}
