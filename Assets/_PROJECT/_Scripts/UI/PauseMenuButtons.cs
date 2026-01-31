using System;
using UnityEngine;

public class PauseMenuButtons : MonoBehaviour
{
    public event Action OnClickResume;
    public event Action OnClickRestart;
    public event Action OnClickBacktoMenu;
    public void ClickResume()
    {
        OnClickResume?.Invoke();
    }

    public void ClickRestart()
    {
        OnClickRestart?.Invoke();
    }

    public void ClickBacktoMenu()
    {
        OnClickBacktoMenu?.Invoke();
    }
}
