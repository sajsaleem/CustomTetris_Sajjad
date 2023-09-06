using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour,IResultManager
{
    public string WinnerName { get; private set; } = default;
    public string LooserName { get; private set; } = default;


    public void UpdateWinner(string name)
    {
        WinnerName = name;

        Debug.Log("WinnerName: " + WinnerName);
    }

    public void UpdateLooser(string name)
    {
        LooserName = name;
    }

    public void Reset()
    {
        WinnerName = "";
        LooserName = "";
    }
}
