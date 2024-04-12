using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodPos : MonoBehaviour
{
    private Camera cam;  
    private void Awake()
    {
        cam = Camera.main;
    }

    private void LateUpdate()
    {
        syncBloodUI();
    }

    private void syncBloodUI()
    {
        Vector3 worldPos =this. transform.position;
        //世界坐标转屏幕坐标
        Vector3 ScreenPos = cam.WorldToScreenPoint(worldPos);

        UIManager.MainInstance.stateBarUI.ShowAt(ScreenPos,worldPos);
    }
}
