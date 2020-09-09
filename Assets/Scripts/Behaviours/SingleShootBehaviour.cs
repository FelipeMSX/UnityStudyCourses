using Assets.Scripts;
using Assets.Scripts.Behaviours;
using UnityEngine;

public class SingleShootBehaviour : MonoBehaviour, IShootBehaviour
{
    public GameObject ProjectilePrefab;
    public float Speed = 3.5f;

    private Weapon _weapon;
    private RecycleProjectileWrapper _recycleProjectile;

    private void Start()
    {
        _weapon = GetComponent<Weapon>();
        _recycleProjectile = GetComponent<RecycleProjectileWrapper>();
    }

    public void Shoot()
    {
        if(ProjectilePrefab != null)
        {
            ProjectileStandard recyledProjectile = _recycleProjectile.RecoverObject(ProjectilePrefab);
            if(recyledProjectile == null)
            {
                GameObject _clonePrefab = Instantiate(ProjectilePrefab, _weapon.ShootPosition.transform.position, Quaternion.identity);
                ProjectileStandard projectileStandard = _clonePrefab.GetComponent<ProjectileStandard>();
                projectileStandard.UpdateSpeed(Speed);
                projectileStandard.OnTriggerEntered += OnTriggerEntered;
            }
            else
            {
                recyledProjectile.EnableRecyleRoutine(_weapon.ShootPosition.transform.position);
            }

        }
    }


    private void OnTriggerEntered(ProjectileStandard projectileStandard)
    {
        bool added =_recycleProjectile.AddObject(projectileStandard);

        if (!added)
        {
            projectileStandard.OnTriggerEntered -= OnTriggerEntered;
            Destroy(projectileStandard);

        }

    }

}
