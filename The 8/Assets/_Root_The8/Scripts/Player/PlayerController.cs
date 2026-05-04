using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement & Look")]
    [SerializeField] float speed = 5f;
    [SerializeField] float crouchSpeed = 3f;
    [SerializeField] bool isCrouching;
    [SerializeField] float sensitivity;
    [SerializeField] float maxForce;
    [SerializeField] GameObject camHolder;


    //General References
    Rigidbody rb;
    Animator anim;
    //Private Variables
    Vector2 moveInput;
    Vector2 lookInput;
    float lookRotation;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void FixedUpdate()
    {
        Movement();
    }

    private void LateUpdate()
    {
        CameraLook();
    }
    void Movement()
    {
        float actualSpeed;
        actualSpeed = isCrouching ? crouchSpeed : speed;

        Vector3 currentVelocity = rb.linearVelocity;
        Vector3 targetVelocity = new Vector3(moveInput.x, 0, moveInput.y);
        targetVelocity *= actualSpeed;

        targetVelocity = transform.TransformDirection(targetVelocity);

        Vector3 velocityChange = (targetVelocity - currentVelocity);
        velocityChange = new Vector3(velocityChange.x, 0, velocityChange.z);

        Vector3.ClampMagnitude(velocityChange, maxForce);

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    void CameraLook()
    {
        transform.Rotate(Vector3.up * lookInput.x * sensitivity);

        lookRotation += (-lookInput.y * sensitivity);
        lookRotation = Mathf.Clamp(lookRotation, -90f, 90f);
        camHolder.transform.eulerAngles = new Vector3(lookRotation, camHolder.transform.eulerAngles.y, camHolder.transform.eulerAngles.z);
    }

    void Crouch()
    {
        isCrouching = !isCrouching;
        anim.SetBool("isCrouching", isCrouching);
    }
    #region Input Methods

    public void OnMove(InputAction.CallbackContext context)
    {
                moveInput = context.ReadValue<Vector2>();
    }


    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Crouch();
        }
    }

    #endregion

}

