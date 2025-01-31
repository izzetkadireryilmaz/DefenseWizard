using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLevelController : MonoBehaviour
{
    public static int target;
    public GameObject[] Levels;
    public GameObject end;
    Animator animator;
    public Canvas gameCanvas, winCanvas;

    void Start()
    {
        animator = end.GetComponent<Animator>();
        Debug.Log("target = " + target);
        Spell.KilledEnemy = 0;
        int activeObjectName = PlayerPrefs.GetInt("ActiveObject");
        for (int i = 0; i < Levels.Length; i++)
        {
            Levels[i].SetActive(false);
            if (PlayerPrefs.GetInt("ActiveObject") == i)
            {
                Levels[i].SetActive(true);
            }
        }
    }

    private void Update()
    {
        if (target == Spell.KilledEnemy)
        {
            animator.Play("EndAnim");
            StartCoroutine(Canvas());
        }
    }

    IEnumerator Canvas()
    {
        yield return new WaitForSeconds(2f);
        gameCanvas.gameObject.SetActive(false);
        winCanvas.gameObject.SetActive(true);
    }

    public void LevelUp()
    {
        int level = PlayerPrefs.GetInt("Levels");
        int newLevel = level + 1;
        PlayerPrefs.SetInt("Levels", newLevel);
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
    }

    public void LevelDefeat()
    {
        SceneManager.LoadScene(0);
    }

}
