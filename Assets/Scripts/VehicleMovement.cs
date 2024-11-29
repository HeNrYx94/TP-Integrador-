using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public float speed = 5f;  // Velocidad del veh�culo
    public Vector2 direction = Vector2.left;  // Direcci�n predeterminada

    void Update()
    {
        // Movimiento continuo en la direcci�n especificada
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
