using Assets.Scripts.Behaviours;
using System;
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

        public void ChangeWeaponStyle(int pickupCode)
        {
            if(pickupCode == 0)
            {
                Destroy(ShootBehaviour as SingleShootBehaviour);
            }
            else if (pickupCode == 1)
            {
                Destroy(ShootBehaviour as TripleShootBehaviour);
            }

            if (pickupCode == 0)
            {
                gameObject.AddComponent(typeof(SingleShootBehaviour));
            }
            else if (pickupCode == 1)
            {
                gameObject.AddComponent(typeof(TripleShootBehaviour));
            }

            ShootBehaviour = GetComponent<IShootBehaviour>();

        }

        private bool CanShoot() => _nextTimetoFire >= 1.0f;
        
    }
}
