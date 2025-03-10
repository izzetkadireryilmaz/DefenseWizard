using UnityEngine;

public class Spell : MonoBehaviour
{
    [Header("Hareket Ayarlar�")]
    public float speed = 5f; // Objenin hareket h�z�
    public Vector3 direction = Vector3.forward; // Hareket y�n� (varsay�lan: ileri)
    public static int KilledEnemy;

    private void Start()
    {
    }
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            KilledEnemy++;
            Debug.Log(KilledEnemy);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
