using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public float speed = 5f;  // Velocidad del vehículo
    public Vector2 direction = Vector2.left;  // Dirección predeterminada

    void Update()
    {
        // Movimiento continuo en la dirección especificada
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
