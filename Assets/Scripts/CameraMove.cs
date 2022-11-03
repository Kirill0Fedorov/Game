using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraMove : MonoBehaviour
{
    private Vector2 startPos;
    private Camera cam;


    // �� ����� ������ ��������� ��������
    // ���������� ��� ���������� ��� ���
    public GameObject kvdrR;
    public GameObject kvdrL;
    public GameObject kvdrT;
    public GameObject kvdrB;


    // ���������� ��� ����������� �������� ������, �������� �� ������, ��� ������ ������ ����, ����� �� ���� ������
    float rightS = 10000;
    float leftS = -10000;
    float topS = 10000;
    float bottomS = -10000;
    private void Start()
    {
        cam = GetComponent<Camera>();

    }
    private void Update()
    {
        if (ButtonsScript.menuFlag == true) 
        {
            if (Input.GetMouseButtonDown(0)) 
            { 
                startPos = cam.ScreenToWorldPoint(Input.mousePosition); 
                 
            }
            else if (Input.GetMouseButton(0))
            {
                float posX = cam.ScreenToWorldPoint(Input.mousePosition).x - startPos.x;
                float posY = cam.ScreenToWorldPoint(Input.mousePosition).y - startPos.y;

                //����������� �������� ������ ������������� ������ �� ������� ��������, ������� � ����� ������ �� �� ���� �����, ������ ������ �� �����, � ������� � ������� ������� ��������
                // � ������ �������� 1085
                //����� �� ���� ������ � ����� � ��������� ������, ������������ ����� ����������� ���� �������, ������� � ������� �� 1085, � 1083
                //������ ������
                //����� ������� �������� ���������� ������ 1083
                // �� � ������� ������ ���������� ������� ����� ������� �������� �������� � ��� ������� �������� 
                // �����!!!!!!!!!
                //����������� ����� ������������ ����������� �������� ����� ������ ���, ����� �� ������������ �� ����
                // ����� ��� ����� ���������� ����������� ������� �� ������ ��� ���������
                // ��� ����� ��������� � ���� ��� ��������� ����
                // � � ����������� �� ���� ��� ����� ������� ������ �� �������� ��� ��������
                // �� ���� ����� �� ����� ��������, ���� �� ������ �� ����
                if (kvdrR.transform.position.x > 1083)
                {
                    rightS = transform.position.x + (1085 - kvdrR.transform.position.x);
                }
                else rightS = 10000;

                if (kvdrL.transform.position.x < 0)
                {
                    leftS = transform.position.x - (kvdrL.transform.position.x + 3);
                }
                else leftS = -10000;

                if (kvdrT.transform.position.y > 2338)
                {
                    topS = transform.position.y + (2340 - kvdrT.transform.position.y);
                }
                else topS = 10000;

                if (kvdrB.transform.position.y < 0)
                {
                    bottomS = transform.position.y - (kvdrB.transform.position.y + 3);
                }
                else bottomS = -10000;

                

                Debug.Log(kvdrB.transform.position.y);
                transform.position = new Vector3(Mathf.Clamp(transform.position.x - posX, leftS, rightS), Mathf.Clamp(transform.position.y - posY, bottomS, topS), transform.position.z); 
         
            }

        }

        
    }

}

