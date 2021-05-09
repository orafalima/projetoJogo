using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Image DashIcon;
    public Image CooldownCircle;
    private float cooldownTime;
    PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>();
        cooldownTime = player.dashCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        bool dash = player.getCanDash();

        this.CooldownCircle.enabled = false;

        this.showCooldown(dash);

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


}
