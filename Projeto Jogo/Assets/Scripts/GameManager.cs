using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int starCount = 0;
    private int score = 0;
    private int totalStarCount = 0;
    private int totalScore = 0;
    private int starsRequired = 3;
    private int Level = 0;

    // Game sound volume :))))))))))
    private float volume = 0.5f;

    private void Awake()
    {
        instance = this;
        SceneManager.LoadSceneAsync((int)ScenesIndexes.MENU, LoadSceneMode.Additive);
    }

    private void Start()
    {
        Play("soundtrack");
    }

    // Load first level scene
    public void PlayGame()
    {
        GameManager.instance.Play("select");
        // Scene change
        SceneManager.UnloadSceneAsync((int)ScenesIndexes.MENU);
        SceneManager.LoadSceneAsync((int)ScenesIndexes.LEVEL_1, LoadSceneMode.Additive);
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

    public void Play(string sound)
    {
        SoundManager.Play(sound);
    }

    public void AddStar()
    {
        starCount++;
    }

    public int GetStar()
    {
        return starCount;
    }

    public void AddScore(int newScore)
    {
        score += newScore;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetTotalScore()
    {
        return totalScore;
    }

    public int GetTotalStar()
    {
        return totalStarCount;
    }

    public void NextLevel()
    {
        totalStarCount += starCount;
        starCount = 0;
        totalScore += score;
        score = 0;
        Level++;
    }

    public void ResetStarScore()
    {
        score = 0;
        starCount = 0;
    }

    public int GetStarsRequired()
    {
        return starsRequired;
    }

    public float GetVolume()
    {
        return volume;
    }
}
