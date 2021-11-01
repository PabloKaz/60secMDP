using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewPauseMenu : MonoBehaviour
{
    public static ViewPauseMenu instanciaCompartida;

    private void Awake()
    {
        instanciaCompartida = this;
    }
    
   public void PausarYDespausar()
    {
        if (GameManager.instanciaCompartida.gameState == GameState.enLaPartida)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.instanciaCompartida.MenuDePausa();

            }
         
        }

        else if (GameManager.instanciaCompartida.gameState == GameState.pausa)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            { GameManager.instanciaCompartida.StartGame();
 
            }
        }


    }

}
