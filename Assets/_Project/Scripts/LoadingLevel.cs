using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingLevel : MonoBehaviour {

    public Slider m_SliderLoader;
    public Text m_PourcentLoader;


	public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Scoring.score = 0;
    }

    public void QuitApp()
    {
        QuitApplication();
    }

    public static void QuitApplication()
    {
        Application.Quit();
    }

    public void LoadAsyncLevel(int _level)
    {
        StartCoroutine(LoadLevelAsync(_level));
    }

    IEnumerator LoadLevelAsync(int _lv)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(_lv);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            m_SliderLoader.value = progress;
            m_PourcentLoader.text = (progress * 100) + "%";
            yield return null;
        }
    }
}
