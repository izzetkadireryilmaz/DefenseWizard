using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronScript : MonoBehaviour
{
    public GameObject Player;
    Animator PlayerAnimator;
    void Start()
    {
        PlayerAnimator = Player.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("CopyBullet"))
        {
            Destroy(collision.gameObject);
            PlayerAnimator.Play("Attack");
            StartCoroutine(PlayIdleAfterDelay(0.5f));
        }
    }

    private IEnumerator PlayIdleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayerAnimator.Play("Idle");
    }
}
