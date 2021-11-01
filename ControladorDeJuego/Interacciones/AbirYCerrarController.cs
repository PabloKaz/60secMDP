using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class AbirYCerrarController : MonoBehaviour
{
   

      public static AbirYCerrarController instanciaCompartida;

      public bool sePuedeAbrir = false;
      public float anguloDeApertura = -95f;
      public float anguloDeCierre = 0.0f;
      public float velocidadDeRotacion = 3.0f;



      private void Awake()
      {
          instanciaCompartida = this;

      }

      private void Start()
      {
         
      }


     
      public void CambiarEstadoDePuerta()
      {
          sePuedeAbrir = !sePuedeAbrir;

      }


      void Update()
      {
         
          if (sePuedeAbrir)
          {
              Quaternion rotacion = Quaternion.Euler(0, anguloDeApertura, 0);
              transform.localRotation = Quaternion.Slerp(transform.localRotation, rotacion, velocidadDeRotacion * Time.deltaTime);

          }
          else
          {
              Quaternion rotacion2 = Quaternion.Euler(0, anguloDeCierre, 0);
              transform.localRotation = Quaternion.Slerp(transform.localRotation, rotacion2, velocidadDeRotacion * Time.deltaTime);

          }


      }


     

}
