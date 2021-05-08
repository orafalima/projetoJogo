using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadSceneAsync((int)ScenesIndexes.MENU, LoadSceneMode.Single);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            Back();
        }
    }

    public void BackHover()
    {
        SoundManager.Play("change");
    }
}
