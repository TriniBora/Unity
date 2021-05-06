using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game obj;

    public int maxLives = 3;

    public bool gamePaused = false;
    public int score = 0;

    void Awake()
    {
        obj = this;    
    }

        // Start is called before the first frame update
    void Start()
    {
        gamePaused = false;
        UIManager.obj.startGame(); // Llamamos a la función que muestra el panel de inicio del juego
    }

    public void addScore(int scoreGive)
    {
        score += scoreGive;
    }

    public void gameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Con esta escena se reinicia la escena actual
    }

    void OnDestroy()
    {
        obj = null;
    }
}
