using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingBarProgress : MonoBehaviour
{
    
    // Start is called before the first frame update
    public Slider loadingSlider;
    public TextMeshProUGUI loadingText;

    void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        // Lấy chỉ số scene hiện tại
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Lấy chỉ số scene kế tiếp
        int nextSceneIndex = currentSceneIndex + 1;

        // Load scene kế tiếp theo build index
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextSceneIndex);
        operation.allowSceneActivation = false;

        float targetProgress = 0f;

        while (!operation.isDone)
        {
            float realProgress = Mathf.Clamp01(operation.progress / 0.9f);
            targetProgress = Mathf.MoveTowards(targetProgress, realProgress, Time.deltaTime);

            if (loadingSlider != null)
                loadingSlider.value = targetProgress;

            if (loadingText != null)
                loadingText.text = $"Loading... {Mathf.RoundToInt(targetProgress * 100)}%";

            if (targetProgress >= 1f && operation.progress >= 0.9f)
            {
                yield return new WaitForSeconds(0.5f);
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
