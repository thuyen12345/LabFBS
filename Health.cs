using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    
    private GameManager gameManager;
    
    void Start()
    {
        currentHealth = maxHealth;
        gameManager = FindFirstObjectByType<GameManager>();
    }
    
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            if (gameManager != null)
                gameManager.EnemyKilled();
                
            // Script Enemy sẽ xử lý hồi sinh
            GetComponent<Enemy>().Die();
        }
        else if (gameObject.CompareTag("Player"))
        {
            Debug.Log("Người chơi đã chết!");
            // Xử lý khi người chơi chết (ví dụ: khởi động lại màn chơi)
            if (gameManager != null)
                gameManager.PlayerDied();
        }
    }
}