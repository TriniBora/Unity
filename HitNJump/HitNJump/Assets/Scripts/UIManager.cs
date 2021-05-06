using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager obj;

    public Text livesLbl;
    public Text scoreLbl;

    public Transform UIPanel;

    void Awake()
    {
        obj = this;
    }

    public void updateLives()
    {
        // Función para actualizar el contador de vidas
        livesLbl.text = "" + Player.obj.lives;
    }

    public void updateScore()
    {
        // Función para actualizar el marcador de puntaje
        scoreLbl.text = "" + Game.obj.score;
    }

    public void startGame()
    {
        //Muestra el panel ppal al iniciar el juego
        AudioManager.obj.playGui();

        Game.obj.gamePaused = true;
        UIPanel.gameObject.SetActive(true);
    }

    public void hideInitPanel()
    {
        //Función para ocultar el panel de juego
        AudioManager.obj.playGui();

        Game.obj.gamePaused = false;
        UIPanel.gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        obj = null;
    }
}
