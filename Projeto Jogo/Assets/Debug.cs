using UnityEngine;
using UnityEngine.UI;

public class Debug : MonoBehaviour
{

    public PlayerMovement player;
    public Text speedText;
    public Text jumpCountText;

    // Update is called once per frame
    void Update()
    {
        speedText.text = player.speed.ToString();
        jumpCountText.text = player.jumpCount.ToString();
    }
}
