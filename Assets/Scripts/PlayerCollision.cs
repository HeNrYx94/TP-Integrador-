using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int lives = 3;  // Vidas del jugador
    public Transform spawnPoint;  // Punto de respawn del jugador

    // Este evento se activa cuando el jugador colisiona con otro objeto
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Vehicle"))
        {
            // Si el jugador colisiona con un vehículo, pierde una vida
            lives--;

            // Si el jugador se queda sin vidas, puedes reiniciar el juego o mostrar un mensaje
            if (lives <= 0)
            {
                Debug.Log("¡Game Over!");
                // Aquí puedes agregar lógica para reiniciar el juego
            }
            else
            {
                // Si todavía tiene vidas, respawnea al jugador
                transform.position = spawnPoint.position;
                Debug.Log("¡Perdiste una vida! Vidas restantes: " + lives);
            }
        }
    }
}
