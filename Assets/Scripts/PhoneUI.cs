using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneUI : MonoBehaviour
{
    public GameObject phoneMenu;
    public GameObject contactMenu;
    public GameObject profileMenu;
    void Start()
    {
        phoneMenu.SetActive(false);
        contactMenu.SetActive(false);
        profileMenu.SetActive(false);
    }

   
    void Update()
    {
        
    }

    void PlayerInput()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {

        }
    }
}
