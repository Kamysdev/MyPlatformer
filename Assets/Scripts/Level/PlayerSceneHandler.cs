using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSceneHandler : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayerSpawnPoint spawn = FindObjectOfType<PlayerSpawnPoint>();

        if (spawn != null)
        {
            transform.position = spawn.transform.position;
        }
        else
        {
            Debug.LogWarning("No PlayerSpawnPoint found in scene " + scene.name);
        }
    }
}
