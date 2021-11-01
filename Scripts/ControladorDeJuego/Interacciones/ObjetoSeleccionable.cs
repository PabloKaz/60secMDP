using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoSeleccionable : MonoBehaviour
{
    public Vector3 posicionInicial;
    public Quaternion rotacionInicial;



    public void Seleccionado(Vector3 focoDePosicion, Vector3 target)
    {
        posicionInicial = transform.position;
        transform.position = focoDePosicion;
        transform.LookAt(target);
    }

    public void Deseleccionado()
    {
        transform.position = posicionInicial;
    }
}
