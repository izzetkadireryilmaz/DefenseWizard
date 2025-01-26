using UnityEngine;

public class Spell : MonoBehaviour
{
    [Header("Hareket Ayarlarý")]
    public float speed = 5f; // Objenin hareket hýzý
    public Vector3 direction = Vector3.forward; // Hareket yönü (varsayýlan: ileri)

    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
