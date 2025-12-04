using UnityEngine;

public class ScoreWatcher : MonoBehaviour
{
    [SerializeField] private float score { get; set; }

    private UIScore uiScore;

    void Start()
    {
        uiScore = FindObjectOfType<UIScore>();
        score = 0;
        uiScore.UpdateScore(score);
    }

    public void AddScore(float amount)
    {
        score += amount;
        uiScore.UpdateScore(score);
    }
}
