using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        GoBall();
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Bat"))
        {
            Vector2 vel;
            vel.y = rb2d.velocity.y;
            vel.x = (rb2d.velocity.x) + (coll.collider.attachedRigidbody.velocity.x);
            print(vel.x);
            print(vel.y);
            rb2d.velocity = vel;
        }
        else if (coll.collider.CompareTag("Block"))
        {
            Destroy(coll.collider.gameObject);
            //Add Score
        }
        //Else If Ground
        //ResetGameFunction
    }

    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(30, -15));
        }
        else
        {
            rb2d.AddForce(new Vector2(-30, -15));
        }
    }
}
