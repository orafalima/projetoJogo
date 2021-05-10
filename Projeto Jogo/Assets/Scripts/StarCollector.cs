using UnityEngine;

public class StarCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is CircleCollider2D)
        {
                SoundManager.Play("star");
                this.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, -999);
                GameManager.instance.AddStar();
                GameManager.instance.AddScore(200);
        }
    }
}
