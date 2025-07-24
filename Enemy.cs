using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float attackRange = 2f;
    public float attackDamage = 10f;
    public float attackRate = 1f;
    public float detectionRange = 15f;
    public GameObject fireballPrefab;
    public float fireballRate = 2f;

    private Transform player;
    private NavMeshAgent agent;
    private float nextAttackTime = 0f;
    private float nextFireballTime = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionRange)
        {
            agent.SetDestination(player.position);

            if (distance <= attackRange && Time.time >= nextAttackTime)
            {
                nextAttackTime = Time.time + 1f / attackRate;
                AttackPlayer();
            }

            // Bắn fireball
            if (Time.time >= nextFireballTime)
            {
                nextFireballTime = Time.time + fireballRate;
                ShootFireball();
            }
        }
    }

    void AttackPlayer()
    {
        Health playerHealth = player.GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }

    void ShootFireball()
    {
        if (fireballPrefab != null && player != null)
        {
            GameObject fireball = Instantiate(fireballPrefab, transform.position + Vector3.up, Quaternion.identity);
            fireball.GetComponent<Fireball>().SetTarget(player);
        }
    }

    public void Die()
    {
        // Ẩn enemy và respawn sau 3 giây bằng Coroutine
        StartCoroutine(RespawnCoroutine());
        gameObject.SetActive(false);
    }

    private System.Collections.IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(3f);
        // Đặt lại vị trí ngẫu nhiên trong phòng
        Vector3 randomPos = new Vector3(Random.Range(-8, 8), 1, Random.Range(-8, 8));
        transform.position = randomPos;
        GetComponent<Health>().currentHealth = GetComponent<Health>().maxHealth;
        gameObject.SetActive(true);
    }
}