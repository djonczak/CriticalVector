using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement Options")]
    [SerializeField] private float playerRunSpeed = 1f;

    public bool isFighting;

    private Rigidbody2D rb;
    public Vector2 playerMove = Vector2.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
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
