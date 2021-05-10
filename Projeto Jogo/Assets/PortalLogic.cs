using UnityEngine;

public class PortalLogic : MonoBehaviour
{
    private GameObject player;
    private GameObject deathSpawnPoint;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        deathSpawnPoint = GameObject.Find("Spawn");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Portal"))
        {
            if(GameManager.instance.GetStarsRequired() > GameManager.instance.GetStar())
            {
                GameManager.instance.SetFailedStar(true);
                player.transform.position = deathSpawnPoint.transform.position;
                GameManager.instance.ResetStarScore();
                GameManager.instance.AddDeath();
            }
            else
            {
                SoundManager.Play("star");
                GameManager.instance.NextLevel();
            }

        }
    }
}
