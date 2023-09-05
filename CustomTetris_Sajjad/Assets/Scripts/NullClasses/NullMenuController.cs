using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullMenuController : IMenuController
{
    private static NullMenuController _instance;

    public static NullMenuController Instance
    {
        get
        {
            if (_instance == null)
                return new NullMenuController();

            return _instance;
        }
    }

    public void Init()
    {

    }

    public void ActivateUi(MenuType menuType)
    {

    }

    public void DisableUi(MenuType menuType)
    {

    }

    public void ResetAllMenus()
    {

    }

}
