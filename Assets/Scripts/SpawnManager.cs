using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _spawnObject;
        public GameObject SpawnObject
        {
            get => _spawnObject;
            set => _spawnObject = value;
        }

        [SerializeField]
        private float _spawnVelocity = 3.0f;
        public float SpawnVelocity
        {
            get => _spawnVelocity;
            set => _spawnVelocity = value;
        }

        private void Start()
        {
            StartCoroutine(SpawnRoutine());
        }


        IEnumerator SpawnRoutine()
        {
            while (true)
            {
                Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
                GameObject clone = Instantiate(_spawnObject, posToSpawn, Quaternion.identity);
                clone.transform.parent = transform;
                yield return new WaitForSeconds(_spawnVelocity);
            }
        }
    }
}
