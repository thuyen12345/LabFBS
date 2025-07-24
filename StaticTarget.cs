using UnityEngine;

public class StaticTarget : MonoBehaviour
{
    public Renderer rend;
    public Color hitColor = Color.red;
    private Color originalColor;
    public float health = 10f;

    void Start()
    {
        if (rend == null) rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        StartCoroutine(HitEffect());
        if (health <= 0)
        {
            gameObject.SetActive(false); // hoặc Destroy(gameObject);
        }
    }

    System.Collections.IEnumerator HitEffect()
    {
        rend.material.color = hitColor;
        yield return new WaitForSeconds(0.1f);
        rend.material.color = originalColor;
    }
}
