using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float movementSpeed;

  public float jumpForce = 5f; 
  public Rigidbody2D rb;

  float mx;

  private void Update()
  {
    movementSpeed = 3;
    mx = Input.GetAxisRaw("Horizontal");

    if (Input.GetButtonDown("Jump"))
    {
      Jump();
    }
  }

  private void FixedUpdate()
  {
    Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);

    rb.velocity = movement; 
  }

  void Jump()
  {
    Vector2 movement = new Vector2(rb.velocity.x, jumpForce);

    rb.velocity = movement;
  }
}
