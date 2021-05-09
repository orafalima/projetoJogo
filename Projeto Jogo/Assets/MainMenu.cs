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
        GameManager.instance.Play("select");
        // Scene change
        SceneManager.UnloadSceneAsync((int)ScenesIndexes.MENU);
        SceneManager.LoadSceneAsync((int)ScenesIndexes.LEVEL_0, LoadSceneMode.Additive);
    }

    // Exit game - desktop builds only
    public void ExitGame()
    {
        GameManager.instance.Play("select");
        Application.Quit();
    }

    public void ShowCredits()
    {
        GameManager.instance.Play("select");
        // Scene change
        SceneManager.UnloadSceneAsync((int)ScenesIndexes.MENU);
        SceneManager.LoadSceneAsync((int)ScenesIndexes.CREDITS, LoadSceneMode.Additive);
    }

    public void HoverStart()
    {
        GameManager.instance.Play("change");
        selected = 0;
    }

    public void HoverCredits()
    {
        GameManager.instance.Play("change");
        selected = 1;
    }

    public void HoverExit()
    {
        GameManager.instance.Play("change");
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
                GameManager.instance.Play("change");
                selected--;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (selected < 3)
            {
                GameManager.instance.Play("change");
                selected++;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Return))
        {
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
