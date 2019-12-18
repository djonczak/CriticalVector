using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [Header("Player Dash Options")]
    [SerializeField] private float dashSpeed = 5f;
    [SerializeField] private float dashCooldown = 2f;
    [SerializeField] private float dashTime = 0.1f;
    [SerializeField] private bool canDash = true;
    [SerializeField] private bool isDashing = false;

    private Rigidbody2D rb;
    private Vector2 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Dash();
    }

    public void ActivateDash()
    {
        if (canDash == true && isDashing == false)
        {
            isDashing = true;
            canDash = false;
            StartCoroutine("EndCooldown", dashTime);
            direction = GetComponent<PlayerMovement>().playerMove;
            GetComponent<PlayerMovement>().isFighting = true;
        }
    }

    private void Dash()
    {
        if (isDashing == true)
        {
            var step = (new Vector2(direction.x, direction.y) * dashSpeed) * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + step);
        }
    }

    private IEnumerator EndCooldown(float time)
    {
        yield return new WaitForSeconds(time);
        isDashing = false;
        GetComponent<PlayerMovement>().isFighting = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
