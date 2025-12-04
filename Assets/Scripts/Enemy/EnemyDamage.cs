using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<ScoreWatcher>().AddScore(10);
            Destroy(enemy);
        }
    }
}
