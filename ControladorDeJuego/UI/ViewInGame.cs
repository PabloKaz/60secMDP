using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewInGame : MonoBehaviour
{
    public static ViewInGame instanciaCompartida;

    public GameObject fadeEffect;
    public GameObject cinematica;

    private void Start()
    {
       
    }
    private void Update()
    {
        if (GameManager.instanciaCompartida.gameState == GameState.enLaPartida)
        {
            fadeEffect.SetActive(true);
            cinematica.SetActive(true);
            StartCoroutine("DesactivarCinematica");

        }
    }

    IEnumerator DesactivarCinematica()
    {
        yield return new WaitForSeconds(3);

        Destroy(cinematica.gameObject);
       
    }

   
    
}
