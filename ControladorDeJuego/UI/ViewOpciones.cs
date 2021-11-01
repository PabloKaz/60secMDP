using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using TMPro;
public class ViewOpciones : MonoBehaviour
{
    public static ViewOpciones instanciaCompartida;

    //DropDown Resoluciones
    public TMP_Dropdown dropDownResoluciones;
    Resolution[] resoluciones;

    //DropDown Resolucion
    public TMP_Dropdown dropDownCalidad;
    public int calidad;

    //Toggle de la pantalla completa
    public Toggle toggle;


    //Slider de la sensi del mouse
    public Slider sliderSensibilidad;
    public float sensibilidadDelMouse;

    //Slider Volumen General música del juego
    public Slider sliderVolumenMusica;
    public float volumenMusica;

    //Slider del Brillo
    public Slider sliderBrillo;
    public float intencidadDelBrillo;
    public Image panelDeBrillo;


    //Bool para cambiar entre el panel de las opciones y el de inGame
    [SerializeField] bool sePuedecambiarDePanel = false;
   
    private void Awake()
    {
        instanciaCompartida = this;

    }

    private void Start()
    {
        //Guardar y asignar un valor al slider de Sensi
        sliderSensibilidad.value = PlayerPrefs.GetFloat("sensiMouse", 6f);
        sensibilidadDelMouse = sliderSensibilidad.value;

        //Guardar y asignar un valor al slider de la musica
        sliderVolumenMusica.value = PlayerPrefs.GetFloat("VolumenMusica", 0.5f);
        AudioListener.volume = sliderVolumenMusica.value;

        //Guardar y asignar un valor al brillo
        sliderBrillo.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        panelDeBrillo.color = new Color(panelDeBrillo.color.r, panelDeBrillo.color.g, panelDeBrillo.color.b, sliderBrillo.value);

        //Comprobar si está en pantalla completa
        if (Screen.fullScreen) toggle.isOn = true;
        else toggle.isOn = false;

        //Comprobar las resoluciones
        ComprobarResoluciones();

        //Guardad y asignar el valor de la calidad
        calidad = PlayerPrefs.GetInt("numeroDeCalidad", 3);
        dropDownCalidad.value = calidad;
        AjustarCalidad();
    }

    private void Update()
    {
        

       SalirDelMenuDeOpciones();
    }



   
    public void CambiarSensibilidadDelMouse(float nuevaSensi)
    {
        if (GameManager.instanciaCompartida.gameState == GameState.opcionesDesdeMenu || GameManager.instanciaCompartida.gameState == GameState.opcionesDesdePausa)
        {
            sensibilidadDelMouse = nuevaSensi;
            PlayerPrefs.SetFloat("sensiMouse", sensibilidadDelMouse);
        }

    }


    public void CambiarVolumenDeLaMusica(float nuevoVolumen)
    {
         
            volumenMusica = nuevoVolumen;
            PlayerPrefs.SetFloat("VolumenMusica", volumenMusica);
            AudioListener.volume = sliderVolumenMusica.value;
        

    }

   
    void SalirDelMenuDeOpciones()
    {
        if (GameManager.instanciaCompartida.gameState == GameState.opcionesDesdeMenu )

            if (Input.GetKeyDown(KeyCode.Escape))
            {


                GameManager.instanciaCompartida.MainMenu();


            }

        if (GameManager.instanciaCompartida.gameState == GameState.opcionesDesdePausa )

            if (Input.GetKeyDown(KeyCode.Escape))
            {


                GameManager.instanciaCompartida.MenuDePausa();
               

            }
    }
    
   public void ActivarPantallaCompleta(bool pantallaCompleta)
    {
            Screen.fullScreen = pantallaCompleta;
        
    }

     void ComprobarResoluciones()
    {
       
            resoluciones = Screen.resolutions;
            dropDownResoluciones.ClearOptions();
            List<string> opciones = new List<string>();
            int resolucionActual = 0;

            for (int i = 0; i < resoluciones.Length; i++)
            {

                string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
                opciones.Add(opcion);

                if (Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height)

                    resolucionActual = i;
            }

            dropDownResoluciones.AddOptions(opciones);
            dropDownResoluciones.value = resolucionActual;
            dropDownResoluciones.RefreshShownValue();

            dropDownResoluciones.value = PlayerPrefs.GetInt("numeroResolucion", 0);
        
    }   

    public void CambiarResolucion(int indiceResolucion)
    {
       
            PlayerPrefs.SetInt("numeroResolucion", dropDownResoluciones.value);

            Resolution resolucion = resoluciones[indiceResolucion];
            Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);

       
    }

    public void CambiarBrillo(float valorDeBrillo)
    {
       
            sePuedecambiarDePanel = true;
            intencidadDelBrillo = valorDeBrillo;
            PlayerPrefs.SetFloat("brillo", intencidadDelBrillo);
            panelDeBrillo.color = new Color(panelDeBrillo.color.r, panelDeBrillo.color.g, panelDeBrillo.color.b, sliderBrillo.value);
        
    }

    public void AjustarCalidad()
    {
        QualitySettings.SetQualityLevel(dropDownCalidad.value);
        PlayerPrefs.SetInt("numeroDeCalidad", dropDownCalidad.value);
        calidad = dropDownCalidad.value;
    }

}
