using UnityEngine;
using UnityEngine.InputSystem;

public class Shootingbase : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private Transform rotatePoint;

    private Vector3 mousePos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // mousePos = mainCam.ScreenToViewportPoint(Mouse.current.position.ReadValue());
        // Debug.Log(mousePos);

        // 1. Get mouse position
        Vector2 screenPos = Mouse.current.position.ReadValue();
        Ray ray = mainCam.ScreenPointToRay(screenPos);

        // 2. Create a plane that faces the camera at the player's position
        // This allows the mouse to "aim" up, down, left, and right relative to the screen.
        Plane aimPlane = new Plane(-mainCam.transform.forward, transform.position);

        if (aimPlane.Raycast(ray, out float distance))
        {
            // 3. Find where the mouse hits that 3D plane
            Vector3 worldMousePos = ray.GetPoint(distance);

            // 4. Calculate the direction from player to the mouse point
            Vector3 direction = worldMousePos - transform.position;

            // 5. Point the rotatePoint at that position
            // This handles all axes (X, Y, and Z) automatically
            if (direction != Vector3.zero)
            {
                rotatePoint.rotation = Quaternion.LookRotation(direction);
            }
        }
    }
}
