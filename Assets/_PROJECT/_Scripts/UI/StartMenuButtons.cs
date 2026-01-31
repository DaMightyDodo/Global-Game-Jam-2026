using System;
using UnityEngine;

public class StartMenuButtons : MonoBehaviour
{
    public event Action OnClickStart;
    public event Action OnClickControl;
    public event Action OnClickQuit;
    public event Action OnClickBack;

    // Called by UI Button
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

    public void ClickBack()
    {
        OnClickBack?.Invoke();
    }
}