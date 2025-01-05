using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour {
    private const int GROUND_LAYER = 3;
    private const int PLAYER_LAYER = 6;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpPower = 2f;
    [SerializeField] private float acceleration = 8f;
    private bool isGrounded;
    private float horizontal;

    private Vector2 inputMovement;
    private void FixedUpdate() {
        if (isGrounded) {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        } else {
            rb.AddForce(inputMovement * acceleration, ForceMode2D.Force);
        }
    }

    public void Move(InputAction.CallbackContext context) {
        horizontal = context.ReadValue<Vector2>().x;
        inputMovement = context.ReadValue<Vector2>();
        inputMovement = inputMovement.normalized;
    }

    public void Jump(InputAction.CallbackContext context) {
        if (context.performed && isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
        if (context.canceled && rb.velocity.y > 0f) {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == GROUND_LAYER) {
            isGrounded = true;
        }
        if (collision.gameObject.layer == PLAYER_LAYER) {
            Debug.Log("Touched Player");
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.layer == GROUND_LAYER) {
            isGrounded = false;
        }
    }

}
