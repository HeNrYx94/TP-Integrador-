using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCarFactory : CarFactoryBase
{
    [SerializeField] private GameObject carPrefab; // Prefab del auto básico
    [SerializeField] private float spawnInterval = 5f; // Intervalo de generación específico

    // Define el intervalo de generación
    public override float GetSpawnInterval()
    {
        return spawnInterval;
    }

    // Define qué auto crear
    public override GameObject CreateCar()
    {
        return carPrefab;
    }
}