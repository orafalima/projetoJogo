using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    private TextMeshProUGUI startSelect;
    private TextMeshProUGUI creditsSelect;
    private TextMeshProUGUI exitSelect;

    private int selected = 0;

    // Load first level scene
    public void PlayGame()
    {
        // Scene change
        SceneManager.UnloadSceneAsync((int)ScenesIndexes.MENU);
        SceneManager.LoadSceneAsync((int)ScenesIndexes.LEVEL_0, LoadSceneMode.Additive);
    }

    // Exit game - desktop builds only
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowCredits()
    {
        // Scene change
        SceneManager.UnloadSceneAsync((int)ScenesIndexes.MENU);
        SceneManager.LoadSceneAsync((int)ScenesIndexes.CREDITS, LoadSceneMode.Additive);
    }

    public void HoverStart()
    {
        SoundManager.Play("change");
        selected = 0;
    }

    public void HoverCredits()
    {
        SoundManager.Play("change");
        selected = 1;
    }

    public void HoverExit()
    {
        SoundManager.Play("change");
        selected = 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        startSelect = GameObject.Find("startSelect").GetComponent<TextMeshProUGUI>();
        creditsSelect = GameObject.Find("creditsSelect").GetComponent<TextMeshProUGUI>();
        exitSelect = GameObject.Find("exitSelect").GetComponent<TextMeshProUGUI>();

        creditsSelect.enabled = false;
        exitSelect.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (selected)
        {
            case 0:
                startSelect.enabled = true;
                creditsSelect.enabled = false;
                exitSelect.enabled = false;
                break;
            case 1:
                startSelect.enabled = false;
                creditsSelect.enabled = true;
                exitSelect.enabled = false;
                break;
            case 2:
                startSelect.enabled = false;
                creditsSelect.enabled = false;
                exitSelect.enabled = true;
                break;
        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (selected > 0)
            {
                SoundManager.Play("change");
                selected--;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (selected < 3)
            {
                SoundManager.Play("change");
                selected++;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            SoundManager.Play("select");
            switch (selected)
            {
                case 0:
                    PlayGame();
                    break;
                case 1:
                    ShowCredits();
                    break;
                case 2:
                    ExitGame();
                    break;
            }
        }

    }
}
