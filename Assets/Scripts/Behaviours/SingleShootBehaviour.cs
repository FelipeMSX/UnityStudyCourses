using Assets.Scripts;
using Assets.Scripts.Behaviours;
using UnityEngine;

public class SingleShootBehaviour : MonoBehaviour, IShootBehaviour
{
    public GameObject ProjectilePrefab;
    public float Speed = 3.5f;

    private GameObject _clonePrefab;
    private Weapon _weapon;

    private void Start()
    {
        _weapon = GetComponent<Weapon>();
    }

    public void Shoot()
    {
        if(ProjectilePrefab != null)
        {
            _clonePrefab = Instantiate(ProjectilePrefab, _weapon.ShootPosition.transform.position, Quaternion.identity);
            ProjectileMoveBehaviour projectileMoveBehaviour = _clonePrefab.GetComponent<ProjectileMoveBehaviour>();
            projectileMoveBehaviour.UpdateSpeed(Speed); 
        }
    }
}
