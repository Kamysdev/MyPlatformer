using UnityEngine;

public class ExperienceStar : MonoBehaviour, IItem
{
    public int xpAmount = 10;

    public string GetName()
    {
        return "Experience Star";
    }

    public void Use(GameObject player)
    {
        ScoreWatcher xp = player.GetComponent<ScoreWatcher>();
        if (xp != null)
        {
            xp.AddScore(xpAmount);
        }

        Destroy(gameObject);
    }
}
