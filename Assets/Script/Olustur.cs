using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Olustur : MonoBehaviour
{
    [Header("Spawn Ayarlarý")]
    public GameObject objectToSpawn, end; // Oluþturulacak prefab (obje)
    public Transform spawnPoint;    // Oluþturulma pozisyonu ve rotasyonu
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
