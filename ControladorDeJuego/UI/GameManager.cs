using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public enum GameState
{
    menu,
    enLaPartida,
    pausa,
    opcionesDesdeMenu,
    opcionesDesdePausa
}
public class GameManager : MonoBehaviour
{
    public static GameManager instanciaCompartida;


    public Canvas menuCanvas;// Llamo al objeto cavas
    public Canvas pauseCanvas;
    public Canvas optionsCanvas;
    public Canvas inGameCanvas;
   
    public GameState gameState = GameState.menu;


  

    private void Awake()
    {
        instanciaCompartida = this;
    }

    private void Start()
    {
        MainMenu();
    }

    private void Update()
    {
       
    }

    //Main Menu

    public void MainMenu()
    {
        ChangeGameState(GameState.menu);
        
    }

    // Start Game
    public void StartGame()
    {
      ChangeGameState(GameState.enLaPartida);

      
    }

    //Cuando el personaje muere
    public void MenuDePausa()
    {
        ChangeGameState(GameState.pausa);

       
    }

    public void OpcionesDesdeMenu()
    {
        ChangeGameState(GameState.opcionesDesdeMenu);
       
    }




    public void OpcionesDesdePausa()
    {
        ChangeGameState(GameState.opcionesDesdePausa);

    }




    void ChangeGameState(GameState newGameState) {

        if (newGameState == GameState.menu)
        {   //Se muestra la partida y oculta el resto de canvas
            menuCanvas.enabled = true;
            pauseCanvas.enabled = false;
            //optionsCanvas.enabled = false;
            optionsCanvas.gameObject.SetActive(false);
            inGameCanvas.enabled = false;

            //Muestra el cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            //El tiempo avanza
            Time.timeScale = 1f;

            
        }





        else if (newGameState == GameState.enLaPartida)
        {   //Se muestra la partida y oculta el resto de canvas
            menuCanvas.enabled = false;   
            pauseCanvas.enabled = false;
            //optionsCanvas.enabled = false;
            optionsCanvas.gameObject.SetActive(false);
            inGameCanvas.enabled = true;

            //Oculta el cursor
            Cursor.visible = false;
           Cursor.lockState = CursorLockMode.Locked;

            //El tiempo y la musica avanzan
            Time.timeScale = 1f;

            AudioSource[] audios = FindObjectsOfType<AudioSource>();
            foreach (AudioSource audio in audios)
            {
                audio.UnPause();
            }


        }




        else if (newGameState == GameState.pausa)
        {   //Se muestra la pausa y oculta el resto de canvas
            menuCanvas.enabled = false;
            pauseCanvas.enabled = true;
            //optionsCanvas.enabled = false;
            optionsCanvas.gameObject.SetActive(false);
            inGameCanvas.enabled = false;

            //Muestra el cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            //El tiempo y la musica se pausan
            Time.timeScale = 0f;

            AudioSource[] audios = FindObjectsOfType<AudioSource>();
            foreach (AudioSource audio in audios)
            {
                audio.Pause();
            }

          
        }





        else if (newGameState == GameState.opcionesDesdeMenu)
        {   //Se muestra el menu de opciones y oculta el resto de canvas
            menuCanvas.enabled = false;    
            pauseCanvas.enabled = false;
            //optionsCanvas.enabled = true;
            optionsCanvas.gameObject.SetActive(true);
            inGameCanvas.enabled = false;

            //Muestra el cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

      
        }





        else if (newGameState == GameState.opcionesDesdePausa)
        {   //Se muestra la partida y oculta el resto de canvas
            menuCanvas.enabled = false;
            pauseCanvas.enabled = false;
            //optionsCanvas.enabled = true;
            optionsCanvas.gameObject.SetActive(true);
            inGameCanvas.enabled = false;

            //Muestra el cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }



        gameState = newGameState;
    }




    /// <summary>
    /// //////////////////////////////////////////////////////////////////
    /// </summary>
    public void RecargarScena()
    {
        SceneManager.LoadSceneAsync("InGameScene");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        ChangeGameState(GameState.enLaPartida);
    }
}
