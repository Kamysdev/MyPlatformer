using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float currentHealth;

    [Header("Color Settings")]
    public Color healthyColor = Color.green;
    public Color midColor = Color.yellow;
    public Color lowColor = Color.red;

    [Header("UI")]
    public GameObject DeadPanel;

    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        UpdateColor();
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth == 0)
        {
            DeadPanel.SetActive(true);
        }

        UpdateColor();
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateColor();
    }

    private void UpdateColor()
    {
        float t = currentHealth / maxHealth;

        if (t < 0.5f)
        {
            float lerp = t / 0.5f; 
            sr.color = Color.Lerp(lowColor, midColor, lerp);
        }
        else
        {
            float lerp = (t - 0.5f) / 0.5f;
            sr.color = Color.Lerp(midColor, healthyColor, lerp);
        }
    }
}
