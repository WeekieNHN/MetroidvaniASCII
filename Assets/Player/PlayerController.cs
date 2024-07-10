using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Jump")]
    public int maxJumpCount = 1;
    public float coyoteTime = 0.2f;
    private int jumpCount = 0;

    [Header("Falling")]
    public float gravity = 9.81f;
    public float gravityDownModifier = 1.5f;
    public float maxFallSpeed = 20.0f;

    private Rigidbody rb;
    [SerializeField] private bool isGrounded;
    private Collider coll;

    private void Awake()
    {
        // Fetch Components
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        // Turn off normal gravity
        rb.useGravity = false;
    }

    public bool IsGrounded () => isGrounded || Time.time - coyoteTimeStart < coyoteTime;
    [SerializeField] private bool prevIsGrounded = false;
    [SerializeField] private float coyoteTimeStart = 0f;
    private void FixedUpdate()
    {
        // If we overlap on the bottom, we're grounded
        isGrounded = Physics.OverlapBox(transform.position - new Vector3(0f, coll.bounds.extents.y, 0f), coll.bounds.extents * 0.9f, Quaternion.identity).Length > 1;

        // If we just left the ground, save timestamp for coyote time
        if (!isGrounded && prevIsGrounded)
            coyoteTimeStart = Time.time;
        
        // Save previous isGrounded
        prevIsGrounded = isGrounded;

        // Handle vertical velocity
        float vertical = rb.velocity.y;
        // Apply gravity if not on the ground
        if (!isGrounded) {
            // Clamp the fall speed
            if (rb.velocity.y <= -maxFallSpeed) 
                vertical = -maxFallSpeed;
            else
                vertical -= (vertical > 0) ? gravity : gravity * gravityDownModifier;
        }

        // Calcuate the horizontal movement
        float horizontal = _movement * moveSpeed;
        // Check if we need to cancel out the movement (Either right or left)
        if (Physics.OverlapBox(transform.position + new Vector3((horizontal > 0) ? coll.bounds.extents.x : -coll.bounds.extents.x, 0f, 0f), coll.bounds.extents * 0.9f, Quaternion.identity).Length > 1)
            horizontal = 0f;

        // Handle Jump
        if (_jump)
        {
            // Reset jump count if necessary
            if (IsGrounded()) jumpCount = 0;
            // Check if we're grounded, or we can jump again in the air
            if (IsGrounded() || (!isGrounded && jumpCount < maxJumpCount))
            {
                // Increment the jump count
                jumpCount += 1;
                // Set the vertical velocity
                vertical = Mathf.Max(vertical, jumpForce);
            }
        }
        // "Consume" the jump, regardless of if it was set or not
        _jump = false;
        
        // Update Velocity
        rb.velocity = new Vector3(horizontal, vertical, 0);
    }

    bool _jump = false;
    public void OnJump (InputAction.CallbackContext context)
    {
        // Jump if the context is started and we're grounded
        if (context.started)
            _jump = true;
    }

    float _movement = 0f;
    public void OnMovement(InputAction.CallbackContext context)
    {
        // Get the horizontal component
        _movement = context.ReadValue<Vector2>().x;
    }

    #region ITEM (ASCII MODE)

    [Header("Item")]
    public bool hasItem = false;

    bool mode = false;
    public void OnItem(InputAction.CallbackContext context)
    {
        // Only run input once
        if (!context.started || !hasItem) return;
        // Change the mode value
        mode = !mode;
        // Update the mode globally
        AsciiMode.SetMode(mode);
    }

    #endregion
}
