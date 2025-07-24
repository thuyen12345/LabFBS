using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text killCountText;
    
    private int killCount = 0;
    private Health playerHealth;
    
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        UpdateUI();
    }
    
    void Update()
    {
        UpdateUI();
    }
    
    void UpdateUI()
    {
        if (healthText != null && playerHealth != null)
        {
            healthText.text = "Máu: " + playerHealth.currentHealth.ToString("0");
        }
        
        if (killCountText != null)
        {
            killCountText.text = "Đã Giết: " + killCount;
        }
    }
    
    public void EnemyKilled()
    {
        killCount++;
        UpdateUI();
    }
    
    public void PlayerDied()
    {
        // Xử lý kết thúc game
        Debug.Log("Game Over!");
        // Tải lại cảnh hoặc hiển thị màn hình kết thúc
    }
}