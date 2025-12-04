using UnityEngine;

public class UIScore : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    public static UIScore instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateScore(float score)
    {
        scoreText.text = "Score: " + score.ToString("0");
    }
}
