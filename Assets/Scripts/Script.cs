using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;


public class Script : MonoBehaviour
{
    [SerializeField]

    public static int xCount = 35;

    [SerializeField]

    public static int yCount = 50;

    public GameObject cellPrefab;
    public static GameObject[,] trx;

    // цвета
    public static Color enemyNationColor;

    private Color Russia = Color.red;
    private Color USA = Color.blue;

    public static Color Color1;
    public static Color Color2;
    //
    
    // Рандомайзер
    public static System.Random rnd = new System.Random();
    public static int bomb;
    //

    // переменная для выбора бомбы
    public static int selectBomb = 0;
    //

    // переменная для реализации задержки
    public static bool boomFlag = true;
    //

    void Start()
    {
        ButtonsScript.menuFlag = false;

        if (MenuSCR.nation == 1)
        {
            Color1 = Color.white;
            Color2 = Color.red;
            enemyNationColor = USA;
        }

        if (MenuSCR.nation == 2)
        {
            Color1 = Color.white;
            Color2 = Color.blue;
            enemyNationColor = Russia;
        }

        trx = new GameObject[xCount, yCount];
        for (int i = 0; i < xCount; i++)
        {
            for (int j = 0; j < yCount; j++)
            {
                trx[i, j] = Instantiate(cellPrefab, Vector3.zero, Quaternion.identity, transform);
                RectTransform rt = trx[i, j].GetComponent<RectTransform>();
                rt.anchorMin = new Vector2(i * 1.0f / xCount, j * 1.0f / yCount);
                rt.anchorMax = new Vector2((i * 1.0f + 1) / xCount, (j * 1.0f + 1) / yCount);
                rt.offsetMin = rt.offsetMax = Vector2.zero;
                if (j >= (yCount / 2))
                    trx[i, j].GetComponent<Image>().color = Russia;
                else
                    trx[i, j].GetComponent<Image>().color = USA;
            }

        }

        ButtonsScript.MenuBar();
    }

    // корутина для задержки между использованием бомб
    IEnumerator timer()
    {
        yield return new WaitForSeconds(1f);
        boomFlag = true;
    }

    public void OnPointerDown(BaseEventData data)
    {
        var _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        PointerEventData pntr = (PointerEventData)data;
        int i = (int)(_mousePosition.x / 1080 * xCount);
        int j = (int)(_mousePosition.y / 2340 * yCount);

        //Debug.Log("clicked on [" + i + "," + j + "]");
        //Debug.Log("clicked on [" + _mousePosition.x + "," + _mousePosition.y + "]");

        if (ButtonsScript.menuFlag == false)
        {
            switch (selectBomb)
            {

                // хз что тут расписывать
                // просто проверяем остались ли бомбы и истек ли таймер задержки
                // потом вызываем скрипт бомбы и включаем таймер
                case 0:
                    if (BombScript.bombCount0 > 0 && boomFlag == true)
                    {
                        BombScript.ClickBomb(i, j); 
                        boomFlag = false;
                        StartCoroutine(timer());
                    }
                    break;
                case 1:
                    if (BombScript.bombCount1 > 0 && boomFlag == true)
                    {
                        BombScript.Bomb1(i, j);
                        boomFlag = false;
                        StartCoroutine(timer());
                    }
                    break;
                case 2:
                    if (BombScript.bombCount2 > 0 && boomFlag == true)
                    {
                        BombScript.Bomb2(i, j);
                        boomFlag = false;
                        StartCoroutine(timer());
                    }
                    break;
                case 3:
                    if (BombScript.bombCount3 > 0 && boomFlag == true)
                    {
                        BombScript.Bomb3(i, j);
                        boomFlag = false;
                        StartCoroutine(timer());
                    }
                    break;
            }
        }
    }

    /// ///////////////////////////////////
    
    public void ButtonClear()
    {
        for (int i = 0; i < xCount; i++)
            for (int j = 0; j < yCount; j++)
            {
                if (j >= (yCount / 2))
                    trx[i, j].GetComponent<Image>().color = Russia;
                else
                    trx[i, j].GetComponent<Image>().color = USA;
            }

        BombScript.bombCount0 = 3;
        BombScript.bombCount1 = 3;
        BombScript.bombCount2 = 3;
        BombScript.bombCount3 = 3;
    }
}

