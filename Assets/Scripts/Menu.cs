using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject space;
    public GameObject menu;
    bool isBlink;

    void Start()
    {
        StartCoroutine("Blink");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isBlink)
        {
            space.SetActive(false);
        }
        else
        {
            space.SetActive(true);
        }
    }

    public void ExitMenu()
    {
        StopCoroutine("Blink");
        StartCoroutine("GameStart");
    }


    IEnumerator Blink()
    {
        isBlink = false;
        yield return new WaitForSeconds(1f);
        isBlink = true;
        yield return new WaitForSeconds(1f);
        StartCoroutine("Blink");
    }

    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(1f);
        menu.SetActive(false);
        this.enabled = false;
    }
}
