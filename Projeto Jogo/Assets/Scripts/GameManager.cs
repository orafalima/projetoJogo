using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int starCount = 0;
    private int score = 0;
    private int totalStarCount = 0;
    private int totalScore = 0;
    private int level = 0;

    private void Awake()
    {
        instance = this;
        SceneManager.LoadSceneAsync((int)ScenesIndexes.MENU, LoadSceneMode.Additive);
    }

   public void Play(string sound)
    {
        SoundManager.Play(sound);
    }

    public void addStar()
    {
        starCount++;
    }

    public int getStar()
    {
        return starCount;
    }

    public void addScore(int newScore)
    {
        score += newScore;
    }

    public int getScore()
    {
        return score;
    }

    public int getTotalScore()
    {
        return totalScore;
    }

    public int getTotalStar()
    {
        return totalStarCount;
    }

    public void nextLevel()
    {
        totalStarCount += starCount;
        starCount = 0;
        totalScore += score;
        score = 0;
        level++;
    }
}
