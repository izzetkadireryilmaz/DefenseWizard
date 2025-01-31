using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class LevelsScript : MonoBehaviour
{
    public Button[] buttons;
    public static int LoadLevel;
    public Canvas startCanvas, levelCanvas;
    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            if (i == PlayerPrefs.GetInt("Levels", 0))
            {
                Debug.Log("asd" + i);
                buttons[i].interactable = true;
            }
        }
    }

    public void SetActiveObject(int index)
    {
        GameLevelController.target = (index + 5) * 3;
        PlayerPrefs.SetInt("ActiveObject", index);
        SceneManager.LoadScene(1);
    }

    public void PlayButton()
    {
        Menu(levelCanvas, startCanvas);
    }

    public void HomeButton()
    {
        Menu(startCanvas, levelCanvas);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    void Menu(Canvas open, Canvas close)
    {
        open.gameObject.SetActive(true);
        close.gameObject.SetActive(false);
    }
}
