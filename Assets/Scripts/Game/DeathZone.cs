using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject gameOverScreen;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Hiện màn game over
            gameOverScreen.SetActive(true);

            // Dừng game (tuỳ chọn)
            Time.timeScale = 0f;
        }
    }
}
