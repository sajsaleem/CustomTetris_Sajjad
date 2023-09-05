using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResultManager
{
    string WinnerName { get; }
    string LooserName { get; }

    void UpdateWinner(string name);
    void UpdateLooser(string name);
    void Reset();
}
