using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CameraController cameraController; // Asignado en el Inspector
    [SerializeField] private PlayerController playerController; // Asignado en el Inspector

    void Start()
    {
        // Verificamos que ambas dependencias estén asignadas
        if (cameraController == null)
        {
            Debug.LogError("CameraController no está asignado en el Inspector.");
            return;
        }

        if (playerController == null)
        {
            Debug.LogError("PlayerController no está asignado en el Inspector.");
            return;
        }

        // Inicializamos el PlayerController con la cámara
        playerController.Initialize(cameraController);
    }
}