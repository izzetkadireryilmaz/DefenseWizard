using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject prefabToSpawn; // Instantiate edilecek prefab
    public GameObject referenceObject; // Pozisyonunu alaca��m�z GameObject
    public float spawnInterval = 0.5f; // Ka� saniyede bir olu�turulacak

    void Start()
    {
        // Prefab olu�turma i�lemini ba�lat
        StartCoroutine(SpawnPrefabLimited());
    }

    private IEnumerator SpawnPrefabLimited()
    {
        for (int i = 0; i < GameLevelController.target; i++)
        {
            // Prefab'� olu�tur
            if (prefabToSpawn != null && referenceObject != null)
            {
                Vector3 spawnPosition = referenceObject.transform.position;
                Quaternion spawnRotation = referenceObject.transform.rotation;

                Instantiate(prefabToSpawn, spawnPosition, spawnRotation);
            }

            // Belirtilen s�re kadar bekle
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
