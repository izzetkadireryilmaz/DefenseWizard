using UnityEngine;
using UnityEngine.Rendering;

public class Olustur : MonoBehaviour
{
    [Header("Spawn Ayarlarý")]
    public GameObject objectToSpawn; // Oluþturulacak prefab (obje)
    public Transform spawnPoint;    // Oluþturulma pozisyonu ve rotasyonu

    // Animasyon event ile çaðrýlacak method
    public void SpawnObject()
    {
        if (objectToSpawn != null)
        {
            // Obje spawn etme iþlemi
            Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);

            // Ýsteðe baðlý: Log mesajý
            Debug.Log($"{objectToSpawn.name} spawn edildi!");
        }
        else
        {
            Debug.LogWarning("Oluþturulacak obje atanmadý!");
        }
    }
}
