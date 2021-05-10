using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIUpdate : MonoBehaviour
{
    private TextMeshProUGUI scoreTxt;
    private TextMeshProUGUI levelTxt;
    private Queue<string> levelTextList;

    // Gambiarra variable
    private bool firstDeath = true;

    // Gambiarra variable - o inimigo agora é outro
    float elapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        switch (GameManager.instance.GetLevel())
        {
            case 1:
                levelTextList.Enqueue("Aperte ↑ para pular");
                levelTextList.Enqueue("Você pode apertar duas vezes ↑ para realizar um pulo duplo");
                break;
            case 2:
                levelTextList.Enqueue("Enquanto estiver no ar, você tem acesso a um poder");
                levelTextList.Enqueue("Você pode apertar D para realizar um voô à frente");
                levelTextList.Enqueue("Porém este poder demora alguns segundos para carregar");
                levelTextList.Enqueue("Use com cuidado ;)");
                break;
            case 3:
                levelTextList.Enqueue("Enquanto estiver no ar, você consegue realizar um mergulho");
                levelTextList.Enqueue("Basta apertar a tecla S");
                levelTextList.Enqueue("Este poder não possui recarga...");
                levelTextList.Enqueue("... Mas não saia mergulhando sem saber o que te espera");
                break;
            case 4:
                levelTextList.Enqueue("Você ganha pontos enquanto estiver correndo..");
                levelTextList.Enqueue("Mas ganha muito mais pontos coletando as estrelas");
                break;
        }

        levelTextList.Enqueue("Colete " + GameManager.instance.GetStarsRequired() + " estrelas e chegue até o final para prosseguir");
    }

    void Awake()
    {
        scoreTxt = GameObject.Find("scoreValue").GetComponent<TextMeshProUGUI>();
        levelTxt = GameObject.Find("levelTxt").GetComponent<TextMeshProUGUI>();
        levelTextList = new Queue<string>();

        StartCoroutine(FadeLevelText());

    }

    public void AddDeathMessage()
    {
        firstDeath = false;
        levelTextList.Enqueue("Ao morrer, você perde seu score da fase e suas estrelas coletadas");
        levelTextList.Enqueue("Além de voltar para o começo da fase");
        levelTxt.text = levelTextList.Dequeue();
        levelTxt.color = new Color(1, 1, 1, 1);
        StartCoroutine(FadeLevelText());
    }

    public void AddFailedStarMessage()
    {
        GameManager.instance.SetFailedStar(false);
        levelTextList.Enqueue("Você não conseguiu capturar as estrelas.");
        levelTxt.text = levelTextList.Dequeue();
        levelTxt.color = new Color(1, 1, 1, 1);
        StartCoroutine(FadeLevelText());
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = (GameManager.instance.GetScore() + GameManager.instance.GetTotalScore()).ToString();

        if(GameManager.instance.GetDeathCount() == 1 && firstDeath)
        {
            AddDeathMessage();
        }

        elapsed += Time.deltaTime;

        if(elapsed >= 1f)
        {
            elapsed %= 1f;
            GameManager.instance.AddScore(10);
        }

        if (GameManager.instance.GetFailedStar())
        {
            AddFailedStarMessage();
        }


    }


    IEnumerator FadeLevelText()
    {
        yield return new WaitForSeconds(2);

        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            levelTxt.color = new Color(1, 1, 1, i);
            yield return null;
        }

        if (levelTextList.Count != 0)
        {
            levelTxt.fontSize = 40;
            levelTxt.color = new Color(1, 1, 1, 1);
            levelTxt.text = levelTextList.Dequeue();
            StartCoroutine(FadeLevelText());
        }

    }
}
