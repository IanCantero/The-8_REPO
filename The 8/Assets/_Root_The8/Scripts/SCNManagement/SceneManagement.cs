using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneManagement : MonoBehaviour
{
    Animator anim;
    int scene;
    [SerializeField] GameObject buttons;

    void Awake()
    {
        buttons.SetActive(true);
        anim = GetComponent<Animator>();
    }

    public void LoadScene(int sceneToLoad)
    {
        if (scene != sceneToLoad)
        {
            scene = sceneToLoad;
        }
        
        StartCoroutine(LoadAnimScene());
    }


    IEnumerator LoadAnimScene()
    {
        buttons.SetActive(false);
        anim.SetTrigger("FadeOut");

        yield return new WaitForSeconds(2f);
        // Load the new scene
        SceneManager.LoadScene(scene);
    }



    public void ExitGame()
    {
        Application.Quit();

        Debug.Log("Game exited."); // This will only show in the editor, not in a built application
    }
}
