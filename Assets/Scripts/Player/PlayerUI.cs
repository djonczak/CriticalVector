using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI instance;

    public Image ammoBar;
    public GameObject[] hpBars;
    private int i = -1;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        foreach(GameObject bar in hpBars)
        {
            bar.GetComponent<Animator>().enabled = false;
        }
    }

    public void Damaged()
    {
        i++;
        hpBars[i].GetComponent<Animator>().enabled = true;
    }

    public void AmmunitionUpdate(float currentAmmo, float maxAmmo)
    {
        ammoBar.fillAmount = currentAmmo / maxAmmo;
    }
}
