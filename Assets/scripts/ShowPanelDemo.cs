using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowPanelDemo : MonoBehaviour
{

    // ���� ���������
    bool isOpened;
    // ������ �� ������
    public GameObject panel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // ������ ���������
            isOpened = !isOpened;
            // �����������
            panel.SetActive(isOpened);
        }
    }
}