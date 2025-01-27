using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Hareket Ayarlar�")]
    public float speed = 1f; // Objenin hareket h�z�
    public Vector3 direction; // Hareket y�n� (varsay�lan: ileri)

    void Update()
    {
        transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
    }
}
