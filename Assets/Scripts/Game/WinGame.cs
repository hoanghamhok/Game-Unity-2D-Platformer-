using UnityEngine;

public class WinGame : MonoBehaviour
{
    public GameObject winPanel;
    public AudioClip winSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            winPanel.SetActive(true);
            AudioSource.PlayClipAtPoint(winSound, transform.position);
            // Dừng game
            Time.timeScale = 0f;

            // Có thể phát nhạc thắng nếu muốn
        }
    }
}
