using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50f;
    public float damage = 10f;
    public float lifeTime = 2f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Di chuyển viên đạn thẳng về phía trước
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        // Gây damage nếu trúng enemy hoặc mục tiêu tĩnh
        Health enemyHealth = other.GetComponent<Health>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }
        StaticTarget staticTarget = other.GetComponent<StaticTarget>();
        if (staticTarget != null)
        {
            staticTarget.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }
        // Tự hủy nếu trúng vật thể khác
        if (!other.isTrigger)
            Destroy(gameObject);
    }
}
