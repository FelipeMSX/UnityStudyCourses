using UnityEngine;

namespace Assets.Scripts.Behaviours
{
    public class TripleShootBehaviour : MonoBehaviour, IShootBehaviour
    {
        [SerializeField]
        private Vector3 _eulerAngle;
        public Vector3 EulerAngle
        {
            get => _eulerAngle;
            set => _eulerAngle = value;
        }

        [SerializeField]
        private float _duration;
        public float Duration
        {
            get => _duration;
            set => _duration = value;
        }

        public GameObject ProjectilePrefab;
        public float Speed = 3.5f;

        private Weapon _weapon;
        private RecycleProjectileWrapper _recycleProjectile;

        private void Start()
        {
            _weapon = GetComponent<Weapon>();
            _recycleProjectile = GetComponent<RecycleProjectileWrapper>();
        }

        //Spawns 3 bullets like this format "\ | /".
        public void Shoot()
        {
            if (ProjectilePrefab != null)
            {
                for(int i = 0; i < 3; i++)
                {
                    ProjectileStandard recyledProjectile = _recycleProjectile.RecoverObject(ProjectilePrefab);

                    if (recyledProjectile == null)
                    {
                        GameObject _clonePrefab = Instantiate(ProjectilePrefab, _weapon.ShootPosition.transform.position, GetQuaternionByItem(i));
                        ProjectileStandard projectileStandard = _clonePrefab.GetComponent<ProjectileStandard>();
                        projectileStandard.UpdateSpeed(Speed);
                        projectileStandard.OnTriggerEntered += OnTriggerEntered;
                    }
                    else
                    {
                        //resets the rotation;
                        recyledProjectile.transform.rotation = Quaternion.identity;
                        recyledProjectile.EnableRecyleRoutine(_weapon.ShootPosition.transform.position);
                        recyledProjectile.gameObject.transform.rotation = GetQuaternionByItem(i);
                    }
                }
            }
        }


        private void OnTriggerEntered(ProjectileStandard projectileStandard)
        {
            bool added = _recycleProjectile.AddObject(projectileStandard);

            if (!added)
            {
                projectileStandard.OnTriggerEntered -= OnTriggerEntered;
                Destroy(projectileStandard.gameObject);

            }

        }

        private Quaternion GetQuaternionByItem(int position)
        {
            if (position == 0)
                return Quaternion.identity;
            else if (position == 1)
                return Quaternion.Euler(_eulerAngle);
            else
                return Quaternion.Euler(_eulerAngle.x, _eulerAngle.y, -_eulerAngle.z);
        }
    }
}
