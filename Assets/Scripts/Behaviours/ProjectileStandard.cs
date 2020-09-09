using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Behaviours
{
    public class ProjectileStandard : MonoBehaviour
    {
        [SerializeField]
        private float _projectileSpeed = 2f;
        public float ProjectileSpeed
        {
            get => _projectileSpeed;
            set => _projectileSpeed = value;
        }

        [SerializeField]
        private float _damage = 1f;
        public float Damage
        {
            get => _damage;
            set => _damage = value;
        }

        [SerializeField]
        private float _reamingLifeTime = 10f;
        public float ReamingLifeTime
        {
            get => _reamingLifeTime;
            set => _reamingLifeTime = value;
        }

        [SerializeField]
        private float _decaySpeed = 20f;
        public float DecaySpeed
        {
            get => _decaySpeed;
            set => _decaySpeed = value;
        }


        private bool _stop;
        private float _currentReamingLifeTime;

        public UnityAction<ProjectileStandard> OnTriggerEntered;


        private void Start()
        {
            _currentReamingLifeTime = _reamingLifeTime;
        }

        private void Update()
        {

            if (_projectileSpeed == 0f || _stop)
                return;

            _currentReamingLifeTime -= _decaySpeed * Time.deltaTime;

            if(_currentReamingLifeTime <= 0f)
            {
                //Recycle
                _stop = true;
                gameObject.SetActive(false);
                OnTriggerEntered?.Invoke(this);
            }
            else
            {
                this.transform.Translate(Vector3.up * _projectileSpeed * Time.deltaTime);

            }
        }


        public void UpdateSpeed(float speed)
        {
            _projectileSpeed = speed;
        }

        private void OnTriggerEnter(Collider other)
        {

            Health health = other.gameObject.GetComponent<Health>();
            if (health == null)
                return;

            health.TakeDamage(_damage, other.gameObject);

            //Recycle
            _stop = true;
            gameObject.SetActive(false);
            OnTriggerEntered?.Invoke(this);

        }

        public void EnableRecyleRoutine(Vector3 position)
        {
            _currentReamingLifeTime = _reamingLifeTime;
            transform.position = position;

            if (!this.isActiveAndEnabled)
                gameObject.SetActive(true);

            _stop = false;
        }
    }
}
