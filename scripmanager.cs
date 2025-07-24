using JetBrains.Annotations;
using UnityEngine;

public class scripmanager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public playerobjectcriptsabke playerObjectScriptable;
    public void increascore(int amount)
    {
        if (playerObjectScriptable != null)
        {
            playerObjectScriptable.playerscore += amount;
            Debug.Log("Player score increased by " + amount + ". New score: " + playerObjectScriptable.playerscore);
        }
        else
        {
            Debug.LogWarning("playerObjectScriptable is not assigned.");
        }
    }
    void Start()
    {
        increascore(10); // Khi bắt đầu game, cộng 10 điểm


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Savescore()
    {
        PlayerPrefs.SetInt("PlayerScore", playerObjectScriptable.playerscore);
        PlayerPrefs.Save();
        Debug.Log("Saving player score: " + playerObjectScriptable.playerscore);
    }
    public void Loadscore()
    {
        if (PlayerPrefs.HasKey("PlayerScore"))
        {
            playerObjectScriptable.playerscore = PlayerPrefs.GetInt("PlayerScore");
            Debug.Log("Loaded player score: " + playerObjectScriptable.playerscore);
        }
        else
        {
            Debug.LogWarning("No saved player score found.");
        }
    }
}
