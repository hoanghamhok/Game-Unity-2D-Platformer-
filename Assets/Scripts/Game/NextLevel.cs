using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    public string nextSceneName = "Level02"; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            // Reset checkpoint trước khi load scene mới
            PlayerManager.lastCheckPointPos = Vector2.zero;

            SceneManager.LoadScene(nextSceneName);
        }
    }
}
