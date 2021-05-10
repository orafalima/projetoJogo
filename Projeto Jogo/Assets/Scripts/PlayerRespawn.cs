using System.Collections;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour

{
    private GameObject player;
    private GameObject deathSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        deathSpawnPoint = GameObject.Find("Spawn");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision is BoxCollider2D)
        {
        player.transform.position = deathSpawnPoint.transform.position;
        GameManager.instance.ResetStarScore();
        GameManager.instance.AddDeath();
        }
    }
}
