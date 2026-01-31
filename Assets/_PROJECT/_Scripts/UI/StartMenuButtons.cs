using System;
using UnityEngine;

public class StartMenuButtons : MonoBehaviour
{
    public event Action OnClickStart;
    public event Action OnClickControl;
    public event Action OnClickQuit;

    // Called by UI Button (Inspector)
    public void ClickStart()
    {
        OnClickStart?.Invoke();
    }

    public void ClickControl()
    {
        OnClickControl?.Invoke();
    }

    public void ClickQuit()
    {
        OnClickQuit?.Invoke();
    }
}