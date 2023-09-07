using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameOver : BaseMenu
{
    [SerializeField] private TextMeshProUGUI resultMsg;

    public override void Init()
    {
        base.Init();
        SetSelectablesActiveStatus(false);
    }

    public void OnReplayCallback()
    {
        Managers.MenuController.DisableUi(MenuType);
        Managers.GameManager.ResetAll();
        Managers.GameManager.StartLevelSequence(Managers.GameManager.ActiveGameMode);
        Time.timeScale = 1;

    }

    public void OnHomeButtonCallBack()
    {
        Managers.MenuController.ActivateUi(MenuType.StartMenu);
        Managers.MenuController.DisableUi(MenuType);
        Managers.GameManager.ResetAll();
        Time.timeScale = 1;
    }

    public override void SetSelectablesActiveStatus(bool value)
    {
        base.SetSelectablesActiveStatus(value);
    }

    public override void MyEnable()
    {
        base.MyEnable();

        SetSelectablesActiveStatus(true);
        HandleResultMsg();
        Time.timeScale = 0;
    }

    public override void Reset()
    {
        throw new System.NotImplementedException();
    }

    private void HandleResultMsg()
    {
        string winner = Managers.ResultManager.WinnerName;
        string looser = Managers.ResultManager.LooserName;

        Debug.Log("<color=green>Winner Name: </color>" + winner);

        if (winner == PlayerTags.Player1.ToString())
        {
            resultMsg.text = "You Won !!!";
        }
        else if(looser == PlayerTags.Player1.ToString())
        {
            resultMsg.text = "You were not able to win :(";
        }
    }
}
