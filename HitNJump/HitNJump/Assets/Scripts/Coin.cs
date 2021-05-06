using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreGive = 100;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Game.obj.addScore(scoreGive);

            AudioManager.obj.playCoin();

            // Se actualiza el puntaje en la UI
            UIManager.obj.updateScore();

            FXManager.obj.showPop(transform.position);
            gameObject.SetActive(false); // una vez que el objeto fue tomado, se destruye
        }
    }
}
