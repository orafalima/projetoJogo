using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressedKeys : MonoBehaviour
{
    public Image a_Key;
    public Image d_Key;
    public Image space_Key;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            a_Key.color = Color.green;

        if (Input.GetKeyUp(KeyCode.A))
            a_Key.color = Color.white;

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
