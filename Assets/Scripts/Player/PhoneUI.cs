using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PhoneUI : MonoBehaviour
{
    public GameObject phoneMenu;
    public GameObject menu;
    public GameObject contactMenu;
    public GameObject profileMenu;
    bool isPhone = false;
    public Button btn;
    private EventSystem es;

    void Start()
    {
        phoneMenu.SetActive(false);
        contactMenu.SetActive(false);
        profileMenu.SetActive(false);
        es = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }

    public void ShowPhone()
    {
        isPhone = !isPhone;
        if (isPhone)
        {
            phoneMenu.SetActive(true);
            es.SetSelectedGameObject(btn.gameObject);
            es.SetSelectedGameObject(null);
            es.SetSelectedGameObject(es.firstSelectedGameObject);
        //    btn.Select();
        }
        else
        {
            phoneMenu.SetActive(false);
        }
    }

    public void GoToContact()
    {
        menu.SetActive(false);
        contactMenu.SetActive(true);

    }

    public void GoToProfiler()
    {
        menu.SetActive(false);
        profileMenu.SetActive(true);
    }

}
