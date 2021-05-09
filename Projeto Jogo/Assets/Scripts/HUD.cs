using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Image BarFill;
    public Image Meteor;
    private float cooldownTime;
    private int totalStars;
    PlayerMovement player;
    CollectStar stars;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>();
        stars = GameObject.FindObjectOfType<CollectStar>();
        cooldownTime = player.dashCooldown;
        totalStars = GameObject.FindGameObjectsWithTag("Star").Length;
        this.Meteor.fillAmount -= 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        bool dash = player.getReadyToDash();

        int starNum = stars.getStarCount();

        this.cooldownBar(dash);

        this.updateMeteor(starNum);

    }

    private void cooldownBar(bool dash)
    {

        if (!dash)
        {
            if(this.BarFill.fillAmount >= 1.0f)
            {
                this.BarFill.fillAmount -= 1.0f;
            }
            
            this.BarFill.fillAmount += 1.0f / cooldownTime * Time.deltaTime;
            
        }
        else
        {
            this.BarFill.fillAmount += 1.0f;
        }
    }

    private void updateMeteor(int stars)
    {
        this.Meteor.fillAmount = (1.0f / totalStars) * stars;
    }


}
