using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingLevel : MonoBehaviour {

	public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Scoring.score = 0;
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
