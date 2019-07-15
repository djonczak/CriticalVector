using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Options")]
    public float playerRunSpeed;
    public float dashSpeed;
    public float dashCooldown;

    private bool canDash = true;
    private bool isDashing = false;
    public bool isFighting;

    private Animator anim;
    Rigidbody2D body;
    public Vector2 playerMove = Vector2.zero;

    void Start()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Movement(playerMove);
        PlayerDash();
    }

    private void Movement(Vector2 move)
    {
        if (isFighting == false || isDashing == true)
        {
            Vector2 movement = new Vector2(move.x, move.y);
            var moveVelocity = movement * playerRunSpeed;
            body.MovePosition(body.position + moveVelocity * Time.fixedDeltaTime);

            if (movement.x < 0)
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
            else if (movement.x > 0)
            {
                transform.eulerAngles = new Vector2(0, 0);
            }

            anim.SetFloat("Speed", Mathf.Abs(movement.magnitude));
        }
    }

    public void Dash()
    {
        if (canDash == true && isDashing == false)
        {
            Debug.Log("Dash");
            isDashing = true;
            canDash = false;
            StartCoroutine("EndDash",0.1f);
        }
    }

    public void PlayerDash()
    {
        if (isDashing == true)
        {
           var step =  (new Vector2(playerMove.x, playerMove.y) * dashSpeed) * Time.fixedDeltaTime;
           body.MovePosition(body.position + step);
        }
    }

    IEnumerator EndDash(float time)
    {
        yield return new WaitForSeconds(time);
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        Debug.Log("Może znowu");
        canDash = true;
    }
}
