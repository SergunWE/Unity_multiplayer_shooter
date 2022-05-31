using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    
    [SerializeField] private Menu[] menus;
    [SerializeField] private Menu backButton;
    [SerializeField] private Menu nickname;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenMenu(string menuName)
    {
        foreach (var menu in menus)
        {
            if (menu.menuName == menuName)
            {
                menu.Open();
            }
            else if (menu.IsOpen)
            {
                CloseMenu(menu);
            }
        }
    }

    public void OpenMenu(Menu menu)
    {
        foreach (var m in menus)
        {
            if (m.IsOpen)
            {
                CloseMenu(m);
            }
        }
        menu.Open();
    }

    public void ShowBackButton()
    {
        if (!backButton.gameObject.activeSelf)
        {
            backButton.Open();
        }
    }

    public void ShowNickname()
    {
        if (!nickname.gameObject.activeSelf)
        {
            nickname.Open();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void CloseMenu(Menu menu)
    {
        menu.Close();
        backButton.Close();
        nickname.Close();
    }
}