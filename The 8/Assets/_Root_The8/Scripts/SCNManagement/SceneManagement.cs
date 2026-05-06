using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    

    public void SceneLoad(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ExitGame()
    {
        Application.Quit();

        Debug.Log("Game exited."); // This will only show in the editor, not in a built application
    }
}
