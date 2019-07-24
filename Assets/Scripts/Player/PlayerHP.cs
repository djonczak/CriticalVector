using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour, IDamage
{
    [SerializeField] private int playerHP = 4;
    private SpriteRenderer playerColor;
    [SerializeField] private GameObject[] hpBars;
    public Color playerNormalState;
    private Color playerDamage = Color.red;
    bool isDamaged = false;
    private int i = -1;

    void Start()
    {
        playerColor = GetComponent<SpriteRenderer>();
        playerNormalState = playerColor.color;
        foreach(GameObject bar in hpBars)
        {
            bar.GetComponent<Animator>().enabled = false;
        }
    }

    public void Update()
    {
        if (isDamaged)
        {
            playerColor.color = Color.Lerp(playerDamage, playerNormalState, Time.deltaTime);
        }
        else
        {
            playerColor.color = Color.Lerp(playerNormalState, playerDamage, Time.deltaTime);
        }
    }

    public void TakeDamage(float amount)
    {
        i++;
        hpBars[i].GetComponent<Animator>().enabled = true;
        playerHP--;

        StartCoroutine("DamageEffect", 1f);
        if (playerHP <= 0)
        {
            gameObject.SetActive(false);
        }
    }


    IEnumerator DamageEffect(float time)
    {
        isDamaged = true;
        yield return new WaitForSeconds(time);
        isDamaged = false;
    }
}
