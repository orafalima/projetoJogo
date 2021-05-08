using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;

        SceneManager.LoadSceneAsync((int)ScenesIndexes.MENU, LoadSceneMode.Additive);
    }

    public void LoadGame()
    {
        SceneManager.UnloadSceneAsync((int)ScenesIndexes.MENU);
        SceneManager.LoadSceneAsync((int)ScenesIndexes.LEVEL_0, LoadSceneMode.Additive);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
