using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMenuController
{
    void Init();
    void ActivateUi(MenuType menuType);
    void DisableUi(MenuType menuType);
    void ResetAllMenus();
}
