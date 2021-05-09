using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class PlayerRespawn : MonoBehaviour

{
    public Score score;
    public GameObject player;
    public Transform deathSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score.ResetScore();

        player.GetComponent<PlayerMovement>().IsDead = true;
        player.GetComponent<PlayerMovement>().StopRunning();
        player.GetComponent<Rigidbody2D>().simulated = false;

        StartCoroutine(ResetPosition());
    }

    IEnumerator ResetPosition()
    {
        yield return new WaitForSeconds(1.5f);

        player.GetComponent<PlayerMovement>().IsDead = false;
        player.GetComponent<PlayerMovement>().ResumeRunning();
        player.GetComponent<Rigidbody2D>().simulated = true;

        player.transform.position = deathSpawnPoint.position;
    }
}