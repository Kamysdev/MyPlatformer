using UnityEngine;

public class HealthPotion : MonoBehaviour, IItem
{
    public float healAmount = 20f;

    public string GetName()
    {
        return "Health Potion";
    }

    public void Use(GameObject player)
    {
        HealthScript health = player.GetComponent<HealthScript>();
        if (health != null)
        {
            health.Heal(healAmount);
        }

        Destroy(gameObject);
    }
}
