using UnityEngine;
using UnityEngine.InputSystem;

public class Shootingbase : MonoBehaviour
{
    [Header("ScriptableObjects")]
    [SerializeField] private SO_BulletStatistics so_bulletStatistics;
    
    [SerializeField] private Camera mainCam;
    [SerializeField] private Transform rotatePoint;
    
    private Vector3 mousePos;

    [Header("New Input System")] private InputSystem_Actions actions;

    [Header("Relating to Bullets (mask)")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firepoint;
    void Awake()
    {
        actions = new InputSystem_Actions();
    }

    void OnEnable()
    {
        actions.Player.Enable();
        actions.Player.Attack.performed += OnLeftClick;
        actions.Player.Attack.canceled += OnLeftClick;
    }

    void OnDisable()
    {
        actions.Player.Disable();
        actions.Player.Attack.performed -= OnLeftClick;
        actions.Player.Attack.canceled -= OnLeftClick;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        // mousePos = mainCam.ScreenToViewportPoint(Mouse.current.position.ReadValue());
        // Debug.Log(mousePos);
        MousePosition_and_Rotation();
    
    }

    private void MousePosition_and_Rotation()
    {
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

    private void OnLeftClick(InputAction.CallbackContext context)
    {
        //mousePos = context.ReadValue<Vector3>();
        if (!context.performed)
        {
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, rotatePoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        //FAILSAFE
        if (rb != null)
        {
            // Vector3 direction = new Vector3(rotatePoint.forward.x, rotatePoint.forward.y, rotatePoint.forward.z);

            rb.linearVelocity = rotatePoint.forward * so_bulletStatistics.speed;
        }

    }
}
