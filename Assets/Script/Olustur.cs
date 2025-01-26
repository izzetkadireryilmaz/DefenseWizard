using UnityEngine;
using UnityEngine.Rendering;

public class Olustur : MonoBehaviour
{
    [Header("Spawn Ayarlar�")]
    public GameObject objectToSpawn; // Olu�turulacak prefab (obje)
    public Transform spawnPoint;    // Olu�turulma pozisyonu ve rotasyonu

    // Animasyon event ile �a�r�lacak method
    public void SpawnObject()
    {
        if (objectToSpawn != null)
        {
            // Obje spawn etme i�lemi
            Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);

            // �ste�e ba�l�: Log mesaj�
            Debug.Log($"{objectToSpawn.name} spawn edildi!");
        }
        else
        {
            Debug.LogWarning("Olu�turulacak obje atanmad�!");
        }
    }
}
