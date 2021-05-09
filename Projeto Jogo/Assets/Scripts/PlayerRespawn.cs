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

        player.GetComponent<PlayerMovement>().Died = true;
        player.GetComponent<PlayerMovement>().StopWalking();
        player.GetComponent<Rigidbody2D>().simulated = false;
        player.GetComponent<PlayerMovement>().PlayerHasControl = false;

        StartCoroutine(ResetPosition());
    }

    IEnumerator ResetPosition()
    {
        yield return new WaitForSeconds(1.5f);

        player.GetComponent<PlayerMovement>().Died = false;
        player.GetComponent<PlayerMovement>().ResumeWalking();
        player.GetComponent<Rigidbody2D>().simulated = true;
        player.GetComponent<PlayerMovement>().PlayerHasControl = true;

        player.transform.position = deathSpawnPoint.position;
    }
}
