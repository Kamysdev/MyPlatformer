using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.collider.GetComponent<PlayerController>();
        if (player == null) return;

        if (player.IsInKillState())
        {
            collision.collider.GetComponent<ScoreWatcher>().AddScore(10);
            Die();
        }
    }

    private void Die()
    {
        Destroy(enemy);
    }
}
