using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Hareket Ayarlarý")]
    public float speed = 1f; // Objenin hareket hýzý
    public Vector3 direction; // Hareket yönü (varsayýlan: ileri)

    void Update()
    {
        transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
    }
}
