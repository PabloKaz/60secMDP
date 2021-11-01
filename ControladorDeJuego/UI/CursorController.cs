using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{


    //Texturas y ubicacion del Cursor
    public Texture2D cursorNormal;
    [SerializeField]public Vector2 cursorNormalSpot;

    public Texture2D cursorOnButton;
    [SerializeField]public Vector2 onButtonCursorSpot;


    public void CursorInteractuaConBoton()
    {
        Cursor.SetCursor(cursorOnButton, onButtonCursorSpot, CursorMode.Auto);
    }
    public void CursorNoInteractuaConBoton()
    {
        Cursor.SetCursor(cursorNormal, cursorNormalSpot, CursorMode.Auto);
    }
}
