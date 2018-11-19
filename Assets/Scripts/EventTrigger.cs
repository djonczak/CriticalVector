using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public delegate void enterArena();
    public static event enterArena EnterArena;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(EnterArena != null)
            {
                EnterArena();
            }
        }
    }
}
