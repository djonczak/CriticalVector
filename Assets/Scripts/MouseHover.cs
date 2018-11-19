using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    public Texture2D normalMouse;
    public Texture2D interactiveMouse;
    public Texture2D attackMouse;

    private Vector2 spot = Vector2.zero;
    private CursorMode auto = CursorMode.Auto;

    private void Start()
    {
        Cursor.SetCursor(normalMouse, spot, auto);
    }

    private void OnMouseOver()
    {
        if (gameObject.tag == "PewNews"|| gameObject.tag == "LinkedIn" || gameObject.tag == "Git")
        {
            Cursor.SetCursor(interactiveMouse, spot, auto);
        }
        if(gameObject.tag == "Enemy")
        {
            Cursor.SetCursor(attackMouse, spot, auto);
        }
    }

    private void OnMouseUpAsButton()
    {
        if (gameObject.tag == "PewNews")
        {
            Application.OpenURL("https://www.youtube.com/channel/UC-lHJZR3Gqxm24_Vd_AJ5Yw");
        }
        if (gameObject.tag == "LinkedIn")
        {
            Application.OpenURL("https://pl.linkedin.com/in/dawid-jonczak-725553157");
        }
        if (gameObject.tag == "Git")
        {
            Application.OpenURL("https://github.com/Sanchez4561");
        }
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(normalMouse, spot, auto);
    }
}
