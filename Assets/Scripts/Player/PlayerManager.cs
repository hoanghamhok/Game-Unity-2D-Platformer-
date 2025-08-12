using UnityEngine.SceneManagement;
using UnityEngine;
using Cinemachine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;

    public static Vector2 lastCheckPointPos;

    public static int numberOfCoins;

    public TextMeshProUGUI coinsText;

    public CinemachineVirtualCamera VCam;
    public GameObject[] playerPrefabs;
    // public static Vector2 respawnPosition = new Vector2(0, -3);

    int characterIndex;

    private void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player = Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);

        if (VCam == null)
            VCam = FindObjectOfType<CinemachineVirtualCamera>();

        if (VCam != null)
            VCam.Follow = player.transform;

        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        isGameOver = false;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Khi load scene mới, tự tìm lại coinsText
        coinsText = FindObjectOfType<TextMeshProUGUI>(); 
    }

    void Update()
    {
        if (coinsText != null) coinsText.text = numberOfCoins.ToString();
        if (isGameOver && gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        if (pauseMenuScreen != null) pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        if (pauseMenuScreen != null) pauseMenuScreen.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
