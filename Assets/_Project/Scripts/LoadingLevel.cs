using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingLevel : MonoBehaviour {

	public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Scoring.score = 0;
    }

    public static void QuitApplication()
    {
        Application.Quit();
    }
}
