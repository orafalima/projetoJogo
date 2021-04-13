using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressedKeys : MonoBehaviour
{
    public Image upArrow_Key;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            upArrow_Key.color = Color.green;

        if (Input.GetKeyUp(KeyCode.UpArrow))
            upArrow_Key.color = Color.white;

    }
}
