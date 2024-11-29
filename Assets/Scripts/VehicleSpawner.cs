using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    public GameObject[] vehicles;  // Prefabs de vehículos
    public float spawnInterval = 5f;  // Intervalo entre spawns
    public Transform[] spawnPoints;  // Puntos de spawn

    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points assigned! Please assign spawn points in the Inspector.");
            return;
        }

        InvokeRepeating(nameof(SpawnVehicle), 0f, spawnInterval); // Inicia la generación repetitiva de vehículos
    }

    void SpawnVehicle()
    {
        if (spawnPoints.Length == 0) return;

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)]; // Selecciona un punto de spawn aleatorio

        GameObject vehicle = vehicles[Random.Range(0, vehicles.Length)]; // Selecciona un vehículo aleatorio
 
        GameObject spawnedVehicle = Instantiate(vehicle, spawnPoint.position, spawnPoint.rotation); // Instancia el vehículo

        VehicleMovement vehicleMovement = spawnedVehicle.GetComponent<VehicleMovement>(); // Configura la dirección del vehículo según su posición

        if (spawnPoint.position.x > 0)  // Si el punto está a la derecha
        {
            vehicleMovement.direction = Vector2.left;  // Mueve hacia la izquierda
        }
        else  // Si el punto está a la izquierda
        {
            vehicleMovement.direction = Vector2.right;  // Mueve hacia la derecha
        }
    }
}
