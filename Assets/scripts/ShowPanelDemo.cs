using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowPanelDemo : MonoBehaviour
{

    // флаг состояния
    bool isOpened;
    // ссылка на панель
    public GameObject panel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // меняем состояние
            isOpened = !isOpened;
            // присваиваем
            panel.SetActive(isOpened);
        }
    }
}