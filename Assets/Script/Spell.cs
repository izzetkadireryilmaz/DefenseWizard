using UnityEngine;

public class Spell : MonoBehaviour
{
    [Header("Hareket Ayarlar�")]
    public float speed = 5f; // Objenin hareket h�z�
    public Vector3 direction = Vector3.forward; // Hareket y�n� (varsay�lan: ileri)

    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
