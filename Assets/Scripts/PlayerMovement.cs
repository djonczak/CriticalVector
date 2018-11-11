using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Options")]
    public float playerSpeed;
    public float dashSpeed;
    public float dashRange;
  //  public float minDashAmount;

   // private float maxDashAmount;
    private float timer = 0;
    private SpriteRenderer characterSprite;
    public bool isDashing;
    public Vector3 mousePosition;

    void Start()
    {
        characterSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        PlayerMove();
        PlayerDash();
    }

    public void PlayerMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, mousePosition, playerSpeed * Time.deltaTime);

        if (mousePosition.x > transform.position.x)
        {
            characterSprite.flipX = false;
        }
        else
        {
            characterSprite.flipX = true;
        }
    }

    public void PlayerDash()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && timer > 0.5f)
        {
            isDashing = true;
            StartCoroutine("EndDash");
            timer = 0;
        }

        if (isDashing)
        {
            float step = (playerSpeed * dashSpeed) * Time.deltaTime;
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
