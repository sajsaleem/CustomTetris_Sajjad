using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    public void OnStartCallBack()
    {
        Managers.GameManager.StartPlay(LevelType.SinglePlayer);
        startButton.SetActive(false);
    }
}
