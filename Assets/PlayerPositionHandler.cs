using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPositionHandler : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Kiểm tra nếu có checkpoint
        if (PlayerManager.lastCheckPointPos != Vector2.zero)
        {
            transform.position = PlayerManager.lastCheckPointPos;
        }
        else
        {
            // Nếu chưa có checkpoint thì tìm SpawnPoint trong scene
            GameObject spawnPoint = GameObject.Find("SpawnPoint");
            if (spawnPoint != null)
            {
                transform.position = spawnPoint.transform.position;
            }
        }
    }
}
