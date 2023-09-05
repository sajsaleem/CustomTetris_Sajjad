using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour, IMenuController
{

    [SerializeField] private List<BaseMenu> menusList = new List<BaseMenu>();

    public void Init()
    {
        for (int i = 0; i < menusList.Count; i++)
        {
            menusList[i].Init();
        }
    }

    public void ActivateUi(MenuType menuType)
    {
        for(int i = 0; i < menusList.Count; i++)
        {
            if(menusList[i].MenuType == menuType)
            {
                menusList[i].SetActive(true);
                menusList[i].MyEnable();
            }
        }
    }

    public void DisableUi(MenuType menuType)
    {
        for (int i = 0; i < menusList.Count; i++)
        {
            if (menusList[i].MenuType == menuType)
            {
                menusList[i].SetActive(false);
            }
        }
    }

    public void ResetAllMenus()
    {
        for(int i = 0; i < menusList.Count; i++)
        {
            menusList[i].Reset();
        }
    }
}
