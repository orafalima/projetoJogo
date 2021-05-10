using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIUpdate : MonoBehaviour
{
    private TextMeshProUGUI scoreTxt;
    private TextMeshProUGUI levelTxt;
    private Queue<string> levelTextList;

    // Start is called before the first frame update
    void Start()
    {
        levelTextList.Enqueue("Aperte ↑ para pular");
        levelTextList.Enqueue("Você pode apertar duas vezes ↑ para realizar um pulo duplo");
        levelTextList.Enqueue("Colete 3 estrelas e chegue até o final para prosseguir");
    }

    void Awake()
    {
        scoreTxt = GameObject.Find("scoreValue").GetComponent<TextMeshProUGUI>();
        levelTxt = GameObject.Find("levelTxt").GetComponent<TextMeshProUGUI>();
        levelTextList = new Queue<string>();

        StartCoroutine(FadeLevelText());

    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = GameManager.instance.GetStar().ToString();
    }


    IEnumerator FadeLevelText()
    {
        yield return new WaitForSeconds(2);

        for(float i = 1; i >= 0; i -= Time.deltaTime)
        {
            levelTxt.color = new Color(1, 1, 1, i);
            yield return null;
        }

        if(levelTextList.Count != 0)
        {
            levelTxt.fontSize = 40;
            levelTxt.color = new Color(1, 1, 1, 1);
            levelTxt.text = levelTextList.Dequeue();
            StartCoroutine(FadeLevelText());
        }

    }
}
