using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour, IDamage
{
    [SerializeField] private float maxHP = 5f;
    [SerializeField] private float currentHP = 0f;

    private void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(float amount)
    {
        currentHP -= amount;
        Debug.Log(amount);
        PlayerUI.instance.Damaged();
        GetComponent<IEffect>().ShowEffect();
        if (currentHP <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
