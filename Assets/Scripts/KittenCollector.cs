using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKittenCollector // Interfaz para recoger gatitos
{
    void PickUpKitten(GameObject kitten);
}
public interface IKittenPlacer // Interfaz para colocar gatitos en la caja
{
    void PlaceKittenInBox(GameObject kitten);
}

public class KittenCollector : MonoBehaviour, IKittenCollector, IKittenPlacer
{
    private GameObject currentKitten = null; // Gatito actualmente rescatado
    private List<GameObject> rescuedKittens = new List<GameObject>(); // Lista de gatitos rescatados

    [SerializeField] public Transform rescueBoxPlacementPoint; // Punto base de la cajita
    [SerializeField] private float kittenSpacing = 1f; // Espaciado entre gatitos en la cajita
    private int kittenCount = 0; // Contador de gatitos en la cajita

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Kitten") && currentKitten == null)
        { 
            PickUpKitten(collision.gameObject); // Recoger el gatito
        }

        if (collision.CompareTag("RescueBox") && currentKitten != null)
        {
            PlaceKittenInBox(currentKitten); // Colocar el gatito en la cajita
        }
    }
    public void PickUpKitten(GameObject kitten)  // Implementación de IKittenCollector: recoger el gatito
    {
        currentKitten = kitten;
        currentKitten.SetActive(false); // Desactivar mientras lo "carga"
        Debug.Log("Gatito recogido");
    }
  
    public void PlaceKittenInBox(GameObject kitten) // Implementación de IKittenPlacer: colocar el gatito en la caja
    {
        // Calcular la posición en la cajita
        Vector2 kittenPosition = new Vector2(rescueBoxPlacementPoint.position.x + kittenCount * kittenSpacing, rescueBoxPlacementPoint.position.y);

        kitten.transform.position = kittenPosition;
        kitten.SetActive(true);

        // Deshabilitar el Collider2D del gatito para evitar que sea recogido nuevamente
        var kittenCollider = kitten.GetComponent<Collider2D>();
        if (kittenCollider != null)
        {
            kittenCollider.enabled = false;
        }

        Debug.Log("Gatito colocado en la cajita");
        kittenCount++;
        currentKitten = null; // Liberar el gatito para que pueda ser recogido otro
    }
}