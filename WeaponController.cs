using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 1f;
    public Camera playerCamera;
    
    private float nextTimeToFire = 0f;
    
    // Hiệu ứng lóe sáng đơn giản
    public GameObject muzzleFlashPrefab;
    public Transform muzzlePoint;

    public GameObject bulletPrefab;
    public float bulletSpeed = 50f;
    
    void Start()
    {
        if (playerCamera == null)
            playerCamera = GetComponentInChildren<Camera>();
            
        // Tạo điểm đầu súng đơn giản nếu không được gán
        if (muzzlePoint == null)
        {
            muzzlePoint = new GameObject("MuzzlePoint").transform;
            muzzlePoint.SetParent(playerCamera.transform);
            muzzlePoint.localPosition = new Vector3(0f, 0f, 0.7f); // Đặt ngay trước camera
            muzzlePoint.localRotation = Quaternion.identity;
        }
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
    
    void Shoot()
    {
        // Tạo hiệu ứng lóe sáng
        if (muzzleFlashPrefab != null)
        {
            GameObject flash = Instantiate(muzzleFlashPrefab, muzzlePoint.position, muzzlePoint.rotation);
            Destroy(flash, 0.05f);
        }

        // Tạo viên đạn bay ra
        if (bulletPrefab != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.damage = damage;
                bulletScript.speed = bulletSpeed;
            }
        }
        // Đã loại bỏ raycast instant hit, chỉ còn bắn thật bằng viên đạn
    }
}