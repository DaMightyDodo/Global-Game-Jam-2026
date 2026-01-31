using UnityEngine;
using Unity.Cinemachine;

public class CameraManager : MonoBehaviour
{
    [Header("Cameras")]
    [SerializeField] private CinemachineCamera titleCamera;
    [SerializeField] private CinemachineCamera controlCamera;

    private CinemachineCamera _currentCamera;

    private void Awake()
    {
        _currentCamera = titleCamera;
        EnableOnly(_currentCamera);
    }

    private void OnEnable()
    {
        StartMenuManager.OnControlMenuOpened += ShowControlCamera;
        StartMenuManager.OnReturnedToTitle += ShowTitleCamera;
    }

    private void OnDisable()
    {
        StartMenuManager.OnControlMenuOpened -= ShowControlCamera;
        StartMenuManager.OnReturnedToTitle -= ShowTitleCamera;
    }


    public void ShowTitleCamera()
    {
        _currentCamera = titleCamera;
        EnableOnly(_currentCamera);
    }

    public void ShowControlCamera()
    {
        _currentCamera = controlCamera;
        EnableOnly(_currentCamera);
    }

    private void EnableOnly(CinemachineCamera activeCam)
    {
        if (titleCamera != null)
            titleCamera.enabled = activeCam == titleCamera;

        if (controlCamera != null)
            controlCamera.enabled = activeCam == controlCamera;
    }
}