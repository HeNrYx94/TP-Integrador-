using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera playerCamera;
    private Transform playerTransform;  // Para saber dónde está el jugador
    [SerializeField] private float cameraYOffset = 0.4f;  // Para ajustar la posición Y de la cámara
    [SerializeField] private float smoothingSpeed = 10f;   // Para suavizar el movimiento de la cámara

    // Este método lo llama el PlayerController o GameManager para decirle al CameraController
    // a qué jugador debe seguir.
    public void Initialize(Transform playerTransform)
    {
        this.playerTransform = playerTransform;  // Guardamos la referencia al jugador
        playerCamera = Camera.main;  // Usamos la cámara principal

        // Inicializamos la posición de la cámara, para que empiece a seguir al jugador
        playerCamera.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + cameraYOffset, -10f);
        playerCamera.transform.SetParent(playerTransform);  // Hacemos que la cámara sea hija del jugador (opcional)
    }

    void Update()
    {
        if (playerTransform != null)
        {
            // La posición de la cámara se actualiza constantemente
            Vector3 targetPosition = new Vector3(playerTransform.position.x, playerTransform.position.y + cameraYOffset, -10f);
            
            // Usamos Lerp para hacer que el movimiento de la cámara sea suave
            playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, targetPosition, smoothingSpeed * Time.deltaTime);
        }
    }
}