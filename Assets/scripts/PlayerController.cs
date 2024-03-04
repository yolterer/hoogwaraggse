using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float gravity =   9.8f;
    private float _fallVelocity =   0;
    public float speed =   10f;
    private CharacterController _characterController;
  

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
    }

    void Update()
    {
        // Mouse look
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        // Movement
        float horizontalMove =   0f;
        float verticalMove =   0f;

        if (Input.GetKey(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }

        if (Input.GetKey(KeyCode.W))
        {
            verticalMove =   1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            verticalMove = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            horizontalMove = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalMove =   1f;
        }
        Vector3 moveDirection = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y,  0) * new Vector3(horizontalMove,   0, verticalMove).normalized;
        _characterController.Move(moveDirection * speed * Time.deltaTime);
    }

}
