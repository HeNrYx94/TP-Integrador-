using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CarFactoryBase : MonoBehaviour
{
    private float timer = 3f; // Temporizador interno

    void Update()
    {
        UpdateTimer();
        TrySpawnCar();
    }

    private void UpdateTimer()
    {
        timer += Time.deltaTime;
    }

    private void TrySpawnCar()
    {
        if (timer >= GetSpawnInterval()) // Llama a GetSpawnInterval implementado en subclases
        {
            GameObject car = CreateCar();
            if (car != null)
            {
                Instantiate(car, transform.position, transform.rotation);
            }
            else
            {
                Debug.LogWarning("No se pudo crear un auto.");
            }
            timer = 0f; // Reinicia el temporizador
        }
    }

    // Método abstracto para que las subclases definan el intervalo de generación
    public abstract float GetSpawnInterval();

    // Método abstracto para que las subclases definan qué auto crear
    public abstract GameObject CreateCar();
}