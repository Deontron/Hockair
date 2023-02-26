using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameManager gm;
    public AudioSource bounce;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.rotation = Quaternion.identity;

        if (collision.CompareTag("Goal1"))
        {
            gm.Goal("Goal1");
            transform.position = new Vector2(0, 1);
        }

        if (collision.CompareTag("Goal2"))
        {
            gm.Goal("Goal2");
            transform.position = new Vector2(0, -1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bounce.Play();
    }
}
