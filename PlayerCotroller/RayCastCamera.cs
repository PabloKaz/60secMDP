using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastCamera : MonoBehaviour
{
    public static RayCastCamera instanciaCompartida;

    //Layer que reconocerá el rayCast
    LayerMask mask;

    ///Distancia del raycast
    [SerializeField] public float distanciaDelRayCast = 3f;

    //Texto que se mostrará al impactar el rayCast
    public GameObject textoDetectado;

    //Canvas del puntero
    public Canvas cursorBlanco;
    public Canvas cursorVerde;

    public Transform depth;

    public ObjetoSeleccionable obj;
    private void Awake()
    {
        instanciaCompartida = this;  
    }
    void Start()
    {
        mask = LayerMask.GetMask("RaycastDetectado");
        textoDetectado.SetActive(false);

        depth.gameObject.SetActive(false);
    }

  
    void Update()
    {
        RaycastHit hit;

       /* if (GameManager.instanciaCompartida.gameState == GameState.enLaPartida)
        {
            cursorBlanco.enabled = true;
            cursorVerde.enabled = false;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distanciaDelRayCast, mask))
            {
                cursorBlanco.enabled = false;
                cursorVerde.enabled = true;
                cursorBlanco.enabled = false;
                if (hit.collider.tag == "ObjetoInteractuable")
                {
                  
                   // textoDetectado.SetActive(true);
                    if (Input.GetMouseButtonDown(0))
                    {
                       // AbirYCerrarController.instanciaCompartida.CambiarEstadoDePuerta();
                       

                    }
                }
                //else { DoorScript.instanciaCompartida.estaMirandoLaPuerta = false; }
               
            }
            else
            {
                //textoDetectado.SetActive(false);

            }
        }
        else { cursorBlanco.enabled = false;
            cursorVerde.enabled = false;
        }*/

        if (GameManager.instanciaCompartida.gameState == GameState.enLaPartida)
        {
            cursorBlanco.enabled = true;
            cursorVerde.enabled = false;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distanciaDelRayCast, mask))
            {
                cursorBlanco.enabled = false;
                cursorVerde.enabled = true;
                cursorBlanco.enabled = false;
                if (hit.collider.gameObject.GetComponent<ObjetoSeleccionable>())
                {
                    Debug.Log("Hola");
                    // textoDetectado.SetActive(true);
                    if (Input.GetMouseButtonDown(0))
                    {
                        depth.gameObject.SetActive(true);
                        Debug.Log("chao");
                        ObjetoSeleccionable obj = hit.collider.gameObject.GetComponent<ObjetoSeleccionable>();
                        obj.Seleccionado(transform.position + transform.forward * .5f, transform.position);
                        // AbirYCerrarController.instanciaCompartida.CambiarEstadoDePuerta();


                    }
                }
                //else { DoorScript.instanciaCompartida.estaMirandoLaPuerta = false; }

            }
            else
            {
                //textoDetectado.SetActive(false);

            }
        }
        else
        {
            cursorBlanco.enabled = false;
            cursorVerde.enabled = false;
        }

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distanciaDelRayCast, Color.red);
    }

   
}
