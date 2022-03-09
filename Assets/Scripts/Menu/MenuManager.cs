using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    
    [SerializeField] private Menu[] menus;

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

    private static void CloseMenu(Menu menu)
    {
        menu.Close();
    }
}