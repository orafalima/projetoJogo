using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressedKeys : MonoBehaviour
{
<<<<<<< Updated upstream
    public Image a_Key;
    public Image d_Key;
    public Image space_Key;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            a_Key.color = Color.green;

        if (Input.GetKeyUp(KeyCode.A))
            a_Key.color = Color.white;
=======
    public Image wKey;
    public Image upArrowKey;
    public Image sKey;
    public Image dKey;
    public Image downArrowKey;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            wKey.color = Color.green;

        if (Input.GetKeyUp(KeyCode.W))
            wKey.color = Color.white;

        if (Input.GetKeyDown(KeyCode.UpArrow))
            upArrowKey.color = Color.green;

        if (Input.GetKeyUp(KeyCode.UpArrow))
            upArrowKey.color = Color.white;

        if (Input.GetKeyDown(KeyCode.S))
            sKey.color = Color.green;

        if (Input.GetKeyUp(KeyCode.S))
            sKey.color = Color.white;

        if (Input.GetKeyDown(KeyCode.D))
            dKey.color = Color.green;

        if (Input.GetKeyUp(KeyCode.D))
            dKey.color = Color.white;

        if (Input.GetKeyDown(KeyCode.DownArrow))
            downArrowKey.color = Color.green;

        if (Input.GetKeyUp(KeyCode.DownArrow))
            downArrowKey.color = Color.white;
>>>>>>> Stashed changes

        if (Input.GetKeyDown(KeyCode.D))
            d_Key.color = Color.green;

        if (Input.GetKeyUp(KeyCode.D))
            d_Key.color = Color.white;

        if (Input.GetKeyDown(KeyCode.Space))
            space_Key.color = Color.green;

        if (Input.GetKeyUp(KeyCode.Space))
            space_Key.color = Color.white;
    }
}
