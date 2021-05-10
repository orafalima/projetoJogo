using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLogic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Portal"))
        {
            SoundManager.Play("star");
            GameManager.instance.NextLevel();
        }
    }
}
