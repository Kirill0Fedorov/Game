using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopScript : MonoBehaviour
{
    public GameObject bombCount0Text;
    public GameObject bombCount1Text;
    public GameObject bombCount2Text;
    public GameObject bombCount3Text;
    public GameObject _cash;

    int cash = 1000;

    void Start()
    {
        _cash.GetComponent<TMP_Text>().text = "Cash: " + cash;
        bombCount0Text.GetComponent<TMP_Text>().text = "Количество: " + BombScript.bombCount0;
        bombCount1Text.GetComponent<TMP_Text>().text = "Количество: " + BombScript.bombCount1;
        bombCount2Text.GetComponent<TMP_Text>().text = "Количество: " + BombScript.bombCount2;
        bombCount3Text.GetComponent<TMP_Text>().text = "Количество: " + BombScript.bombCount3;
    }

    public void Bomb0 ()
    {
        int price = 10;

        if (cash >= price && BombScript.bombCount0 < 10)
        {
            BombScript.bombCount0++;
            bombCount0Text.GetComponent<TMP_Text>().text = "Количество: " + BombScript.bombCount0;
            cash -= price;
            _cash.GetComponent<TMP_Text>().text = "Cash: " + cash;
        }
    }

    public void Bomb1()
    {
        int price = 50;

        if (cash >= price && BombScript.bombCount1 < 10)
        {
            BombScript.bombCount1++;
            bombCount1Text.GetComponent<TMP_Text>().text = "Количество: " + BombScript.bombCount1;
            cash -= price;
            _cash.GetComponent<TMP_Text>().text = "Cash: " + cash;
        }
    }

    public void Bomb2()
    {
        int price = 250;

        if (cash >= price && BombScript.bombCount2 < 10)
        {
            BombScript.bombCount2++;
            bombCount2Text.GetComponent<TMP_Text>().text = "Количество: " + BombScript.bombCount2;
            cash -= price;
            _cash.GetComponent<TMP_Text>().text = "Cash: " + cash;
        }  
    }

    public void Bomb3()
    {
        int price = 300;

        if (cash >= price && BombScript.bombCount3 < 10)
        {
            BombScript.bombCount3++;
            bombCount3Text.GetComponent<TMP_Text>().text = "Количество: " + BombScript.bombCount3;
            cash -= price;
            _cash.GetComponent<TMP_Text>().text = "Cash: " + cash;
        }
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
