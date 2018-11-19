using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneUI : MonoBehaviour
{
    public GameObject phoneMenu;
    public GameObject contactMenu;
    public GameObject profileMenu;
    bool isPhone = false;

    void Start()
    {
        phoneMenu.SetActive(false);
        contactMenu.SetActive(false);
        profileMenu.SetActive(false);
    }

   
    void Update()
    {
        PlayerInput();
        Show();
    }

    void PlayerInput()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            isPhone = !isPhone;
            GameManager.instance.isPause = isPhone;
        }
    }

    void Show()
    {
        if (isPhone)
        {
            phoneMenu.SetActive(true);
        }
        else
        {
            phoneMenu.SetActive(false);
        }
    }

    public void GoToContact()
    {
        phoneMenu.SetActive(false);
        contactMenu.SetActive(true);

    }

    public void GoToProfiler()
    {
        phoneMenu.SetActive(false);
        profileMenu.SetActive(true);
    }

    public void Back()
    {
        profileMenu.SetActive(true);
        contactMenu.SetActive(false);
        profileMenu.SetActive(false);
    }

    public void LinkedIn()
    {
        Application.OpenURL("https://pl.linkedin.com/in/dawid-jonczak-725553157");
    }

    public void Git()
    {
        Application.OpenURL("https://github.com/Sanchez4561");
    }
}
