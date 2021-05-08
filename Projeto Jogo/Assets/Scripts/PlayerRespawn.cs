using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class PlayerRespawn : MonoBehaviour

{
     public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Thread.Sleep(1000);
        player.transform.position = new Vector3(-4, -1, 0);
    }
}
