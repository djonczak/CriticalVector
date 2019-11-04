using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [Header("Player Dash Options")]
    public float dashSpeed;
    public float dashCooldown;
    [SerializeField]
    public float dashTime = 0.1f;
    [SerializeField]
    private bool canDash = true;
    [SerializeField]
    private bool isDashing = false;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Dash();
    }

    public void ActivateDash()
    {
        if (canDash == true && isDashing == false)
        {
            Debug.Log("Dash");
            isDashing = true;
            canDash = false;
            StartCoroutine("EndCooldown", dashTime);
            direction = GetComponent<PlayerMovement>().playerMove;
            GetComponent<PlayerMovement>().isFighting = true;
        }
    }

    public void Dash()
    {
        if (isDashing == true)
        {
            var step = (new Vector2(direction.x, direction.y) * dashSpeed) * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + step);
        }
    }

    IEnumerator EndCooldown(float time)
    {
        yield return new WaitForSeconds(time);
        isDashing = false;
        GetComponent<PlayerMovement>().isFighting = false;
        yield return new WaitForSeconds(dashCooldown);
        Debug.Log(".Can again");
        canDash = true;
    }
}
