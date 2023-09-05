using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullResultManager : IResultManager
{
    public static NullResultManager _instance;

    public static NullResultManager Instance
    {
        get
        {
            if (_instance == null)
                return new NullResultManager();

            return _instance;
        }
    }

    public string WinnerName { get; private set; }
    public string LooserName { get; private set; }


    public void UpdateWinner(string name)
    {

    }

    public void UpdateLooser(string name)
    {

    }

    public void Reset()
    {

    }
}
