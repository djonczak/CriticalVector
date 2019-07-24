using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    public Button startButton;
    public GameObject menu;
    private EventSystem es;

    void Start()
    {
        StartCoroutine("Blink");
        EventSystem es = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        es.SetSelectedGameObject(null);
        es.SetSelectedGameObject(es.firstSelectedGameObject);
    }

    public void ExitMenu()
    {
        StopCoroutine("Blink");
        GameStart();
    }

    IEnumerator Blink()
    {
        startButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        startButton.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        StartCoroutine("Blink");
    }

    void GameStart()
    {
        menu.SetActive(false);
        this.enabled = false;
    }
}
