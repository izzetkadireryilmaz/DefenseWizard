using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject prefabToSpawn; // Instantiate edilecek prefab
    public GameObject referenceObject; // Pozisyonunu alacaðýmýz GameObject
    public float spawnInterval = 0.5f; // Kaç saniyede bir oluþturulacak
    public int spawnCount = 10; // Toplam kaç defa spawn iþlemi gerçekleþecek

    void Start()
    {
        // Prefab oluþturma iþlemini baþlat
        StartCoroutine(SpawnPrefabLimited());
    }

    private IEnumerator SpawnPrefabLimited()
    {
        for (int i = 0; i < spawnCount; i++) // Belirtilen sayýda tekrar yap
        {
            // Prefab'ý oluþtur
            if (prefabToSpawn != null && referenceObject != null)
            {
                Vector3 spawnPosition = referenceObject.transform.position;
                Quaternion spawnRotation = referenceObject.transform.rotation;

                Instantiate(prefabToSpawn, spawnPosition, spawnRotation);
            }

            // Belirtilen süre kadar bekle
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
