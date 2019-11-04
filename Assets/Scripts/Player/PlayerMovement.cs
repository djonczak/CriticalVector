using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement Options")]
    public float playerRunSpeed;

    public bool isFighting;

    private Rigidbody2D rb;
    public Vector2 playerMove = Vector2.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Movement(playerMove);
    }

    private void Movement(Vector2 move)
    {
        if (isFighting == false)
        {
            Vector2 movement = new Vector2(move.x, move.y);
            var moveVelocity = movement * playerRunSpeed;
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

            if (movement.x < 0)
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
            else if (movement.x > 0)
            {
                transform.eulerAngles = new Vector2(0, 0);
            }

            GetComponent<IAnimation>().MoveAnim(movement.magnitude);
        }
    }

}
