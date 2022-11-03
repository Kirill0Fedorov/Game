using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraControl : MonoBehaviour
{
    public float ZoomMax;
    public float ZoomMin;
    public float Sensitivity;

    private Camera _mainCamera;

    // обработка тачей
    private Touch _touchA;
    private Touch _touchB;
    // направление движений пальцев от стартовых позиций
    private Vector2 _touchADirection;
    private Vector2 _touchBDirection;
    // дистанция между пальцами и направление изменения дистанции
    private float _dstBtwTouchesPosition;
    private float _dstBtwTouchesDirection;
    // коэф. зума
    private float _zoom;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }


    private void Update()
    {
        if (ButtonsScript.menuFlag == true) 
        {
            if (Input.touchCount == 2)
            {
                _touchA = Input.GetTouch(0);
                _touchB = Input.GetTouch(1);
                _touchADirection = _touchA.position - _touchA.deltaPosition;
                _touchBDirection = _touchB.position - _touchB.deltaPosition;

                _dstBtwTouchesPosition = Vector2.Distance(_touchA.position, _touchB.position);
                _dstBtwTouchesDirection = Vector2.Distance(_touchADirection, _touchBDirection);

                _zoom = _dstBtwTouchesPosition - _dstBtwTouchesDirection;

                var currentZoom = _mainCamera.orthographicSize - _zoom * Sensitivity;

                _mainCamera.orthographicSize = Mathf.Clamp(currentZoom, ZoomMin, ZoomMax);
            }
        }
        
    }
}