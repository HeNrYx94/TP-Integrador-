using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carControl : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Velocidad del auto
    [SerializeField] private float destroyPositionX = 10f; // Posición en la que se destruye
    [SerializeField] private int type = 1; // Tipo de comportamiento (1 o 2)

    void Update()
    {
        MoveCar();
        HandleDestruction();
    }

    // Método responsable del movimiento del auto
    private void MoveCar()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    // Método encargado de manejar la destrucción según el tipo
    private void HandleDestruction()
    {
        if (ShouldDestroy())
        {
            Destroy(gameObject);
        }
    }

    // Método que determina si el objeto debe ser destruido
    private bool ShouldDestroy()
    {
        if (type == 1)
        {
            return transform.position.x >= destroyPositionX;
        }
        else if (type == 2)
        {
            return transform.position.x <= destroyPositionX;
        }
        else
        {
            Debug.LogWarning("Tipo no reconocido. Asegúrate de configurar 'type' como 1 o 2.");
            return false;
        }
    }
}
