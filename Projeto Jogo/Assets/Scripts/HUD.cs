using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Image DashIcon;
    public Image CooldownCircle;
    public Image Meteoro1;
    public Image Meteoro2;
    public Image MeteoroFull;
    private float cooldownTime;
    PlayerMovement player;
    CollectStar stars;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>();
        stars = GameObject.FindObjectOfType<CollectStar>();
        cooldownTime = player.dashCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        bool dash = player.getReadyToDash();

        int starNum = stars.getStarCount();

        this.CooldownCircle.enabled = false;

        this.showCooldown(dash);

        this.updateMeteor(starNum);
    }

    private void showCooldown(bool dash)
    {

        Color color = this.DashIcon.color;
        if (!dash)
        {
            color.a = 0.5f;
            this.DashIcon.color = color;
            this.CooldownCircle.enabled = true;
            this.CooldownCircle.fillAmount -= 1.0f / cooldownTime * Time.deltaTime;
            
        }
        else
        {
            if(this.CooldownCircle.fillAmount == 0f)
            {
                this.CooldownCircle.fillAmount += 1.0f; 
            }
            this.CooldownCircle.enabled = false;
            color.a = 1.0f;
            this.DashIcon.color = color;
        }
    }

    private void updateMeteor(int stars)
    {
        switch (stars)
        {
            case 1:
                this.Meteoro1.enabled = true;
                break;
            case 2:
                this.Meteoro2.enabled = true;
                break;
            case 3:
                this.MeteoroFull.enabled = true;
                break;
        }
    }


}
