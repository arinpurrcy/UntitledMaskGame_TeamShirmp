using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 3.5f;
    public float rotationSpeed = 10f;

    [Header("Animation")]
    public Animator animator;
    public string speedParam = "Speed";
    public float animDampTime = 0.1f;

    [Header("Jumping")]
    public float jumpHeight = 1.5f;
    public float gravity = -9.81f;

    private float verticalVelocity;

    private CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        if (!animator) animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 input = new Vector3(h, 0f, v);
        input = Vector3.ClampMagnitude(input, 1f);

        Vector3 move = input * moveSpeed;

        bool isGrounded = controller.isGrounded;

        if (isGrounded && verticalVelocity < 0f) verticalVelocity = -2f;

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
            //animator.SetBool("IsJumping", true);
        }

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 velocity = move;
        velocity.y = verticalVelocity;

        controller.Move(velocity * Time.deltaTime);

        if (input.sqrMagnitude > 0.001f)
        {
            Quaternion targetRot = Quaternion.LookRotation(input, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
        }

        float speed01 = input.magnitude;
        animator.SetFloat(speedParam, speed01, animDampTime, Time.deltaTime);
    }
}
