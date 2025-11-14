using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputManager inputManager;
    private Transform cameraTransform;

    private Vector2 movementDir;

    public float characterSpeed = 5f;
    public float cameraSpeed = 0.1f;
    [SerializeField] private bool isCameraLocked = true;

    private void Awake()
    {
        inputManager = new InputManager();
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        CharMove();
    }

    private void LateUpdate()
    {
        CameraMove();
    }

    // Movement script for the character
    void CharMove()
    {
        Vector2 move = characterSpeed * Time.deltaTime * movementDir;
        transform.position += new Vector3(move.x, move.y, 0);
        // transform.rotation = Quaternion.LookRotation(Vector3.forward, movementDir);
    }

    void CameraMove()
    {
        if (isCameraLocked)
        {
            Vector3 desiredPosition = Vector3.Slerp(cameraTransform.position, new Vector3(transform.position.x, transform.position.y, cameraTransform.position.z), cameraSpeed * Time.deltaTime);
            cameraTransform.position = desiredPosition;
        }
    }

    private void OnEnable()
    {
        inputManager.Character.Enable();

        // Movement input
        inputManager.Character.Movement.performed += ctx => movementDir = ctx.ReadValue<Vector2>();
        inputManager.Character.Movement.canceled += ctx => movementDir = Vector2.zero;

        inputManager.Character.CameraLock.performed += ctx => isCameraLocked = !isCameraLocked;
    }

    private void OnDisable()
    {
        inputManager.Character.Disable();
    }
}
