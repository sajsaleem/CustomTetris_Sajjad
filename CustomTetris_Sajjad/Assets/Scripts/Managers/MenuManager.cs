using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private Camera miniMapCamera;
    [SerializeField] private GameObject miniMap;

    public void OnStartCallBack()
    {
        Managers.GameManager.StartPlay(GameModeType.TwoPlayer);
        miniMapCamera.gameObject.SetActive(true);
        miniMap.gameObject.SetActive(true);
        startButton.SetActive(false);
    }
}
