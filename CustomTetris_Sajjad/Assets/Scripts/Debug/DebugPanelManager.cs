using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugPanelManager : Singleton<DebugPanelManager>
{
    [DevDebugMode] [SerializeField] private bool shouldShow = default;

    [SerializeField] private TextMeshProUGUI player1TowerHeight = default;
    [SerializeField] private TextMeshProUGUI player2TowerHeight = default;
    [SerializeField] private TextMeshProUGUI fps = default;
    [SerializeField] private TextMeshProUGUI blocksLostP1 = default;
    [SerializeField] private TextMeshProUGUI blocksLostP2 = default;

    private void Awake()
    {
        if (!shouldShow)
            gameObject.SetActive(false);
    }

    private void Update()
    {
        fps.text = "FPS: " + (1.0f / Time.smoothDeltaTime).ToString();
    }

    public void UpdatePlayer1TowerHeight(float value)
    {
        player1TowerHeight.text = "P1TowerHeight: " + value.ToString();
    }

    public void UpdatePlayer2TowerHeight(float value)
    {
        player2TowerHeight.text = "P2TowerHeight: " + value.ToString();
    }

    public void BlocksLostP1(int value)
    {
        blocksLostP1.text = "PiecesLostP1: " + value.ToString();
    }

    public void BlocksLostP2(int value)
    {
        blocksLostP2.text = "PiecesLostP2: " + value.ToString();
    }

    public void Reset()
    {
        player1TowerHeight.text = "";
        player2TowerHeight.text = "";
        blocksLostP1.text = "";
        blocksLostP2.text = "";
    }
}
