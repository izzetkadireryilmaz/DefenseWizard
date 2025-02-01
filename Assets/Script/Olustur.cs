using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Olustur : MonoBehaviour
{
    [Header("Spawn Ayarlar�")]
    public GameObject objectToSpawn, end; // Olu�turulacak prefab (obje)
    public Transform spawnPoint;    // Olu�turulma pozisyonu ve rotasyonu
    public Canvas gameCanvas, deadCanvas;
    Animator animator;
    public AudioSource lose;
    bool enemyDestroy;

    private void Start()
    {
        animator = end.GetComponent<Animator>();
    }

    private void Update()
    {
        if (enemyDestroy == true)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
        }
    }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(Dead());
        }
    }
    IEnumerator Dead()
    {
        enemyDestroy = true;
        animator.Play("EndAnim");
        lose.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        gameCanvas.gameObject.SetActive(false);
        deadCanvas.gameObject.SetActive(true);
    }
}
