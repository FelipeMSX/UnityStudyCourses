using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Pickup : MonoBehaviour
    {

        [Tooltip("The code of pickup"), SerializeField]
        private int _pickupCode;
        public int PickupCode
        {
            get => _pickupCode;
            set => _pickupCode = value;
        }

        [Tooltip("VFX spawned on pickup"), SerializeField]
        private GameObject _pickupVFXPrefab;
        public GameObject PickupVFXPrefab
        {
            get => _pickupVFXPrefab;
            set => _pickupVFXPrefab = value;
        }

        public UnityAction<Player> OnPick;

        public Rigidbody PickupRigidbody { get; private set; }

        private void Start()
        {
            PickupRigidbody = GetComponent<Rigidbody>();
            Collider collider = GetComponent<Collider>();

            // ensure the physics setup is a kinematic rigidbody trigger
            PickupRigidbody.isKinematic = true;
            collider.isTrigger = true;


        }

        private void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            Player pickingPlayer = other.GetComponent<Player>();

            if (pickingPlayer != null && OnPick != null)
            {
                OnPick.Invoke(pickingPlayer);
            }
        }


        public void PlayPickupFeedback()
        {
            //if (PickupSFX != null)
            //{
            //    AudioSource.PlayClipAtPoint(PickupSFX, Camera.main.transform.position, 1f);
            //    //AudioUtility.CreateSFX(pickupSFX, transform.position, AudioUtility.AudioGroups.Pickup, 0f);
            //}

            //if (PickupVFXPrefab != null)
            //{
            //    var pickupVFXInstance = Instantiate(PickupVFXPrefab, transform.position, Quaternion.identity);
            //}
        }
    }
}
