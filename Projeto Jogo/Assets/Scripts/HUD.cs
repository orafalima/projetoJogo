using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Image dashIcon;
    PlayerMovement player;
    public Image dashOnCooldown;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        bool dash = player.getDashCooldown();

        if (!dash)
        {
            dashIcon.sprite.
        }
    }
}
