using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateScript : MonoBehaviour
{
    public GameObject copy;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (CompareTag("0x"))
            {
                Destroy(collision.gameObject);
            }
            if (CompareTag("2x"))
            {
                GameObject newCopy2x = Instantiate(copy, (Vector2)collision.transform.position + new Vector2(0.1f, 0), Quaternion.identity);
                newCopy2x.tag = "CopyBullet";
            }
            else if (CompareTag("3x"))
            {
                for (int i = 0; i < 2; i++)
                {
                    GameObject newCopy3x = Instantiate(copy, (Vector2)collision.transform.position + new Vector2(0.1f * i, 0), Quaternion.identity);
                    newCopy3x.tag = "CopyBullet";
                }
            }
        }
        if (collision.gameObject.CompareTag("CopyBullet"))
        {
            if (CompareTag("0x"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
