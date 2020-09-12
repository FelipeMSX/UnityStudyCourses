using Assets.Scripts.Behaviours;
using UnityEngine;

namespace Assets.Scripts
{

    public class TripleShootPickup : MonoBehaviour
    {
        private Pickup _pickup;

        void Start()
        {
            _pickup = GetComponent<Pickup>();

            // Subscribe to pickup action
            _pickup.OnPick += OnPicked;
        }

        void OnPicked(Player player)
        {
            player.ChangeWeaponShoot(1);

            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            // Subscribe to pickup action to avoid memory leak.
            _pickup.OnPick -= OnPicked;
        }
    }
}
