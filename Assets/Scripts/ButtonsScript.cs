using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{

    // кнопки
    public GameObject ClearA;
    public GameObject LVL1A;
    public GameObject LVL2A;
    public GameObject LVL3A;


    public static GameObject Clear;
    public static GameObject LVL1;
    public static GameObject LVL2;
    public static GameObject LVL3;

    public static bool menuFlag = false;

    void Start()
    {
        // присваиваем кнопки в статичные переменные
        Clear = ClearA;
        LVL1 = LVL1A;
        LVL2 = LVL2A;
        LVL3 = LVL3A;
    }

    public static void MenuBar()
    {
        if (menuFlag == false)
        {
            Clear.SetActive(false);
            LVL1.SetActive(false);
            LVL2.SetActive(false);
            LVL3.SetActive(false);
        }
        else
        {
            Clear.SetActive(true);
            LVL1.SetActive(true);
            LVL2.SetActive(true);
            LVL3.SetActive(true);
        }
    }

    public void ButtonBomb1()
    {
        if (Script.selectBomb != 1)
            Script.selectBomb = 1;
        else Script.selectBomb = 0;

        menuFlag = false;
        MenuBar();
    }

    public void ButtonBomb2()
    {
        if (Script.selectBomb != 2)
            Script.selectBomb = 2;
        else Script.selectBomb = 0;

        menuFlag = false;
        MenuBar();
    }


    public void ButtonBomb3()
    {
        if (Script.selectBomb != 3)
            Script.selectBomb = 3;
        else Script.selectBomb = 0;

        menuFlag = false;
        MenuBar();
    }

    public void AtackModeButton()
    {
        if (menuFlag == false)
            menuFlag = true;
        else menuFlag = false;

        MenuBar();
    }

    public void Shop()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
