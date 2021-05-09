using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIUpdate : MonoBehaviour
{
    private TextMeshProUGUI scoreTxt;
    private TextMeshProUGUI levelTxt;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    void Awake()
    {
        scoreTxt = GameObject.Find("scoreValue").GetComponent<TextMeshProUGUI>();
        levelTxt = GameObject.Find("levelTxt").GetComponent<TextMeshProUGUI>();

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

    }
}
