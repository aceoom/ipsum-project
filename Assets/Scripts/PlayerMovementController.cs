using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private CharacterController characterController;

    private PlayerInput playerInput;
    private InputAction movementInputAction;

    private Vector3 moveDirection;

    private void OnValidate()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        movementInputAction = playerInput.actions["Movement"];
    }

    // Start is called before the first frame update
    void Start()
    {
        movementInputAction.started += HandleMovement;
        movementInputAction.performed += HandleMovement;
        movementInputAction.canceled += HandleMovement;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateRotation();
    }

    private void HandleMovement(InputAction.CallbackContext context)
    {
        var curentMovement = context.ReadValue<Vector2>();
        moveDirection = new Vector3(curentMovement.x, 0, curentMovement.y);
    }

    private void UpdateMovement()
    {
        characterController.Move(moveDirection * 2f * Time.deltaTime);
    }

    private void UpdateRotation()
    {
        Vector3 direct = Vector3.RotateTowards(transform.forward, moveDirection, 0.5f, 0.0f);
        transform.rotation = Quaternion.LookRotation(direct);
    }
}
