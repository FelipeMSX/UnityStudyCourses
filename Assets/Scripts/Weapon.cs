using Assets.Scripts.Behaviours;
using UnityEngine;

namespace Assets.Scripts
{
    public class Weapon : MonoBehaviour
    {
        public IShootBehaviour ShootBehaviour;

        public float FireRate = 10f;

        public Transform ShootPosition;

        private float _nextTimetoFire = 0f;


        private void Start()
        {
            ShootBehaviour = GetComponent<IShootBehaviour>();
        }

        private void Update()
        {
            if (_nextTimetoFire <= 1f)
                _nextTimetoFire += ((FireRate / 10f) * Time.deltaTime);
        }


        public void Shoot()
        {
            if (!CanShoot())
                return;

            ShootBehaviour.Shoot();
            _nextTimetoFire = 0f;
        }

        private bool CanShoot() => _nextTimetoFire >= 1.0f;
        
    }
}
