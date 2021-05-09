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
        GameManager.instance.ResetStarScore();

        player.GetComponent<PlayerMovement>().IsDead = true;
        player.GetComponent<PlayerMovement>().StopRunning();
        player.GetComponent<Rigidbody2D>().simulated = false;
        player.GetComponent<PlayerMovement>().PlayerHasControl = false;

        StartCoroutine(ResetPosition());
    }

    IEnumerator ResetPosition()
    {
        yield return new WaitForSeconds(0);

        player.GetComponent<PlayerMovement>().IsDead = false;
        player.GetComponent<PlayerMovement>().ResumeRunning();
        player.GetComponent<Rigidbody2D>().simulated = true;
        player.GetComponent<PlayerMovement>().PlayerHasControl = true;

        player.transform.position = deathSpawnPoint.transform.position;
    }
}
