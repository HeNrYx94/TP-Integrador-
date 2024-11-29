using UnityEngine;
using FishNet.Object;

public class PlayerController : NetworkBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 5.0f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    private CameraController cameraController;

    // Inyectamos la cámara
    public void Initialize(CameraController cameraController)
    {
        this.cameraController = cameraController;

        // Verificamos que la cámara no sea null antes de usarla
        if (this.cameraController == null)
        {
            Debug.LogError("CameraController no ha sido asignado en PlayerController.");
            return;
        }
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (IsOwner)
        {
            if (cameraController != null)
            {
                cameraController.Initialize(transform); // Inicializamos la cámara solo para el jugador propietario
            }
        }
        else
        {
            // Deshabilitamos el controlador de movimiento en los clientes que no sean propietarios
            gameObject.GetComponent<PlayerController>().enabled = false;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!IsOwner) return; // Solo permite mover al propietario del objeto

        // Entrada de movimiento en 2D
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // Aplica el movimiento al Rigidbody2D
        rb.velocity = moveInput * moveSpeed;
    }
}