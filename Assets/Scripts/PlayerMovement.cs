using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Options")]
    public float playerWalkSpeed;
    public float playerRunSpeed;
    public float dashSpeed;
    public float dashRange;
  //  public float minDashAmount;

   // private float maxDashAmount;
    private float timer = 0;
    private SpriteRenderer characterSprite;
    public bool isDashing;
    private Vector3 mousePosition;
    private Animator anim;
    public bool isFighting;
    private float distance;
    Rigidbody2D body;

    void Start()
    {
        characterSprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        PlayerMove();
        PlayerDash();
        distance = Vector3.Distance(this.transform.position, mousePosition);
    }

    public void PlayerMove()
    {
        if (distance >= 0.1f && GameManager.instance.isPause == false)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position = Vector3.MoveTowards(transform.position, mousePosition, playerRunSpeed * Time.deltaTime);
                anim.ResetTrigger("isWalking");
                anim.ResetTrigger("isIdle");
                anim.SetTrigger("isRunning");
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, mousePosition, playerWalkSpeed * Time.deltaTime);
                anim.ResetTrigger("isRunning");
                anim.ResetTrigger("isIdle");
                anim.SetTrigger("isWalking");
            }

            if (mousePosition.x > transform.position.x)
            {
                characterSprite.flipX = false;
            }
            else
            {
                characterSprite.flipX = true;
            }


            if (distance <= 0.1f)
            {
                anim.ResetTrigger("isRunning");
                anim.ResetTrigger("isWalking");
                anim.SetTrigger("isIdle");
            }
        }
    }

    public void PlayerDash()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && timer > 0.5f && GameManager.instance.isPause == false)
        {
            isDashing = true;
            StartCoroutine("EndDash");
            timer = 0;
        }

        if (isDashing)
        {
            float step = (playerWalkSpeed * dashSpeed) * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, mousePosition, step / dashRange);
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    private IEnumerator EndDash()
    {
        yield return new WaitForSeconds(0.1f);
        isDashing = false;
    }
}
