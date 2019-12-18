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
        EventSystem es = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        es.SetSelectedGameObject(null);
        es.SetSelectedGameObject(es.firstSelectedGameObject);
    }

    public void ExitMenu()
    {
        menu.SetActive(false);
        this.enabled = false;
    }
}
