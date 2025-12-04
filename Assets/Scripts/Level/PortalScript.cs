using UnityEngine;

public class PortalScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Portal"))
        {
            SceneController sceneController = FindObjectOfType<SceneController>();
            Debug.Log("Player entered the portal.");
            if (sceneController != null)
            {
                sceneController.LoadNextLevel();
            }
        }
    }
}
