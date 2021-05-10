using UnityEngine;

public class StarCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Star"))
        {
            SoundManager.Play("star");
            Destroy(other.gameObject);
            GameManager.instance.AddStar();
            GameManager.instance.AddScore(200);
        }
    }
}
