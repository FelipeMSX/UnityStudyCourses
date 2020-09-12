using Assets.Scripts.Behaviours;
using Assets.Scripts.Weapons.Behaviours;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class RecycleProjectileWrapper : MonoBehaviour
    {

        [SerializeField]
        public int _maxSize = 15;
        public int MaxSize
        {
            get => _maxSize;
            set => _maxSize = value;
        }

        private RecycleManager<ProjectileStandard> _recycleManagar;

        [SerializeField]
        public Transform _recyleContainer;
        public Transform RecyleContainer
        {
            get => _recyleContainer;
            set => _recyleContainer = value;
        }



        private void Start()
        {
            _recycleManagar = new RecycleManager<ProjectileStandard>(MaxSize);
        }


        public ProjectileStandard RecoverObject(GameObject prefab)
        {
            ProjectileStandard projectile = (ProjectileStandard)_recycleManagar.Remove();

            if (projectile == null)
                return null;

            //After recover needs to remove the parent.
            projectile.gameObject.transform.parent = null;

            return projectile;
        }

        public bool AddObject(ProjectileStandard projectileStandard)
        {
            bool result = _recycleManagar.AddIfNecessary(projectileStandard);

            if (result)
            {
                projectileStandard.gameObject.transform.parent = RecyleContainer;
                projectileStandard.gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
            }

            return result;
        }
    }
}
