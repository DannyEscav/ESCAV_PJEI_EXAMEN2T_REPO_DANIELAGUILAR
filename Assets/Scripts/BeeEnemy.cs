using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeEnemy : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        // Comprueba si el enemigo ha colisionado con el jugador
        if (other.CompareTag("Player")) {
            // Fin de la partida
            GameManager.GameOver();
        }
    }
}
