using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;

public class BombScript : MonoBehaviour
{
    // счетчики бомб
    public static int bombCount0 = 3;
    public static int bombCount1 = 3;
    public static int bombCount2 = 3;
    public static int bombCount3 = 3;

    // честно, я хз что тут расписывать

    public static void ClickBomb(int i, int j)
    {
        if (Script.trx[i, j].GetComponent<Image>().color == Script.Color1)
        {
            Script.trx[i, j].GetComponent<Image>().color = Script.Color2;
            bombCount0++;
        }
        if (Script.trx[i, j].GetComponent<Image>().color == Script.enemyNationColor)
        {
            Script.trx[i, j].GetComponent<Image>().color = Script.Color1;
            bombCount0--;
        }
    }
    public static void Bomb1(int i, int j)
    {
        for (int k = i - 1; k <= i + 1; k++)
            for (int h = j - 1; h <= j + 1; h++)
            {
                if (k >= 0 && h >= 0 && k < Script.xCount && h < Script.yCount)
                {
                    if (Script.trx[k, h].GetComponent<Image>().color == Script.Color1)
                        Script.trx[k, h].GetComponent<Image>().color = Script.Color2;

                    if (Script.trx[k, h].GetComponent<Image>().color == Script.enemyNationColor)
                        Script.trx[k, h].GetComponent<Image>().color = Script.Color1;
                }
            }

        bombCount1--;
    }
    public static void Bomb2(int i, int j)
    {
        for (int k = i - 3; k <= i + 3; k++)
            for (int h = j - 3; h <= j + 3; h++)
            {
                if (k >= 0 && h >= 0 && k < Script.xCount && h < Script.yCount && (k != i - 3 || h != j + 3) && (k != i + 3 || h != j - 3) && (k != i - 3 || h != j - 3) && (k != i + 3 || h != j + 3))
                {
                    if (Script.trx[k, h].GetComponent<Image>().color == Script.Color1)
                        Script.trx[k, h].GetComponent<Image>().color = Script.Color2;

                    if (Script.trx[k, h].GetComponent<Image>().color == Script.enemyNationColor)
                        Script.trx[k, h].GetComponent<Image>().color = Script.Color1;
                }
            }

        for (int k = i - 1; k <= i + 1; k++)
            for (int h = j - 5; h <= j - 4; h++)
            {
                if (k >= 0 && h >= 0 && k < Script.xCount && h < Script.yCount && (k != i - 1 || h != j - 5) && (k != i + 1 || h != j - 5))
                {
                    if (Script.trx[k, h].GetComponent<Image>().color == Script.Color1)
                        Script.trx[k, h].GetComponent<Image>().color = Script.Color2;

                    if (Script.trx[k, h].GetComponent<Image>().color == Script.enemyNationColor)
                        Script.trx[k, h].GetComponent<Image>().color = Script.Color1;
                }
            }

        for (int k = i - 1; k <= i + 1; k++)
            for (int h = j + 4; h <= j + 5; h++)
            {
                if (k >= 0 && h >= 0 && k < Script.xCount && h < Script.yCount && (k != i - 1 || h != j + 5) && (k != i + 1 || h != j + 5))
                {
                    if (Script.trx[k, h].GetComponent<Image>().color == Script.Color1)
                        Script.trx[k, h].GetComponent<Image>().color = Script.Color2;

                    if (Script.trx[k, h].GetComponent<Image>().color == Script.enemyNationColor)
                        Script.trx[k, h].GetComponent<Image>().color = Script.Color1;
                }
            }

        for (int k = i - 5; k <= i - 4; k++)
            for (int h = j - 1; h <= j + 1; h++)
            {
                if (k >= 0 && h >= 0 && k < Script.xCount && h < Script.yCount && (k != i - 5 || h != j + 1) && (k != i - 5 || h != j - 1))
                {
                    if (Script.trx[k, h].GetComponent<Image>().color == Script.Color1)
                        Script.trx[k, h].GetComponent<Image>().color = Script.Color2;

                    if (Script.trx[k, h].GetComponent<Image>().color == Script.enemyNationColor)
                        Script.trx[k, h].GetComponent<Image>().color = Script.Color1;
                }
            }

        for (int k = i + 4; k <= i + 5; k++)
            for (int h = j - 1; h <= j + 1; h++)
            {
                if (k >= 0 && h >= 0 && k < Script.xCount && h < Script.yCount && (k != i + 5 || h != j + 1) && (k != i + 5 || h != j - 1))
                {
                    if (Script.trx[k, h].GetComponent<Image>().color == Script.Color1)
                        Script.trx[k, h].GetComponent<Image>().color = Script.Color2;

                    if (Script.trx[k, h].GetComponent<Image>().color == Script.enemyNationColor)
                        Script.trx[k, h].GetComponent<Image>().color = Script.Color1;
                }
            }

        bombCount2--;
    }
    public static void Bomb3(int i, int j)
    {
        // счтетчик вражеских полей и счетчик закрашеных клеток
        int enPlane = 0;
        int counter = 0;

        for (int k = i - 4; k <= i + 4; k++)
            for (int h = j - 4; h <= j + 4; h++)
            {
                if (k >= 0 && h >= 0 && k < Script.xCount && h < Script.yCount)
                    if (Script.trx[k, h].GetComponent<Image>().color == Script.enemyNationColor)
                        enPlane++;
            }

        if (enPlane > 40)
        {
            while (counter < 40)
            {
                for (int k = i - 4; k <= i + 4; k++)
                    for (int h = j - 4; h <= j + 4; h++)
                    {
                        if (k >= 0 && h >= 0 && k < Script.xCount && h < Script.yCount)
                        {
                            Script.bomb = Script.rnd.Next(0, 2);
                            if (Script.trx[k, h].GetComponent<Image>().color == Script.enemyNationColor && Script.bomb == 1 && counter < 40)
                            {
                                Script.trx[k, h].GetComponent<Image>().color = Script.Color1;
                                counter++;
                            }
                        }
                    }
            }
        }
        else
        {
            for (int k = i - 4; k <= i + 4; k++)
                for (int h = j - 4; h <= j + 4; h++)
                {
                    if (k >= 0 && h >= 0 && k < Script.xCount && h < Script.yCount)
                    {
                        if (Script.trx[k, h].GetComponent<Image>().color == Script.enemyNationColor)
                            Script.trx[k, h].GetComponent<Image>().color = Script.Color1;
                    }
                }
        }

        bombCount3--;
    }
}



