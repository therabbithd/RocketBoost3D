using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Ammo Settings")]
    [SerializeField] private int currentAmmo = 10;
    [SerializeField] private int maxAmmo = 10;
    [SerializeField] private bool infiniteAmmo = false;

    [Header("Shooting Settings")]
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private float BulletRate = 5f;
    [SerializeField] private int bulletDamage = 1;

    private Transform bulletSpawnPoint;

    private ObjectPool bulletPool;

    private float lastShotTime = 0f;
    void Start()
    {
        bulletSpawnPoint = transform.Find("ShootPoint");
        bulletPool = GetComponent<ObjectPool>();
    }
    public bool CanShoot()
    {
        return (Time.time - lastShotTime >= BulletRate) && (infiniteAmmo || currentAmmo > 0);
    }
    public void Shoot()
    {
        if (CanShoot())
        {
            lastShotTime = Time.time;

            if(!infiniteAmmo)currentAmmo--;

            GameObject bullet = bulletPool.GetObjectFromPool();
            bullet.transform.position = bulletSpawnPoint.position;
            bullet.transform.rotation = bulletSpawnPoint.rotation;

            Rigidbody bulletRigidBody = bullet.GetComponent<Rigidbody>();

            bulletRigidBody.linearVelocity = bulletSpawnPoint.up * bulletSpeed;


        }
    }
}
