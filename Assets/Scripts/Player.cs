using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    float speed;
    float damage;

    bool wantsJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            wantsJump = true;
        }
    }

    void FixedUpdate()
    {
        float verticalVel = 0;
        if (Input.GetKey(KeyCode.A))
        {
            verticalVel -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            verticalVel += 1;
        }
        if (wantsJump)
        {
            rb.AddForce(new Vector2(0, 20), ForceMode2D.Impulse);
            wantsJump = false;
        }
        rb.AddForce(new Vector2(verticalVel * 40 * rb.mass, 0));
    }
}
