using UnityEngine;

namespace Assets.Scripts
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 4.0f;
        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        private Health _health;


        private void Start()
        {
            _health = GetComponent<Health>();
            _health.OnDamaged += OnDamaged;
            _health.OnDie += OnDie;
        }

        private void Update()
        {

            transform.Translate(Vector3.down * _speed * Time.deltaTime);

            if(transform.position.y < -7f)
            {
                transform.position = new Vector3(Random.Range(-12f,14f), 7f, 0f);
            }

        }

        private void OnDamaged(float damage, GameObject damageSouce)
        {

        }

        private void OnDie()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _health.OnDamaged -= OnDamaged;
            _health.OnDie -= OnDie;
        }

    }
}
