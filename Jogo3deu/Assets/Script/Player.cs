using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float rotationSpeed = 720.0f;
    public float jumpSpeed = 8.0f;
    public float jumpButtonGracePeriod = 0.2f;

    private Animator animator;
    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;
    private PlayerStun playerStun;


    private Quaternion initialRotationOffset; // Store the initial rotation offset applied to the player model

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;

        // Store the initial rotation offset applied to the player model
        initialRotationOffset = Quaternion.Euler(0, 180, 0); // Adjust the values if the rotation offset is different

        playerStun = GetComponent<PlayerStun>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = -Input.GetAxis("Horizontal"); // Inverted horizontal input
        float verticalInput = -Input.GetAxis("Vertical"); // Inverted vertical input

        Vector3 movementDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;

        // Apply gravity
        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            lastGroundedTime = Time.time;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpButtonPressedTime = Time.time;
        }

        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;

            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
            {
                ySpeed = jumpSpeed;
                jumpButtonPressedTime = null;
                lastGroundedTime = null;
            }
        }
        else
        {
            characterController.stepOffset = 0;
        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        // Update rotation based on input
        if (movementDirection != Vector3.zero)
        {
            if (animator != null) animator.SetBool("IsMoving", true);

            // Calculate target direction based on input
            Vector3 targetDirection = transform.forward * verticalInput + transform.right * horizontalInput;

            // Skip rotation if there's no input
            if (targetDirection == Vector3.zero)
            {
                return;
            }

            // Create target rotation based on target direction
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            // Apply the initial rotation offset to the target rotation
            targetRotation *= initialRotationOffset;

            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            if (animator != null) animator.SetBool("IsMoving", false);
        }

        if (!playerStun.IsStunned())
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }
        else
        {
            Debug.Log("Player is stunned, cannot move");
        }

    }
}