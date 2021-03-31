using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerMovement : MonoBehaviour
{
  public float movementSpeed;
  public Transform feet;
  public float jumpForce = 5f;
  
  public Rigidbody2D rb;
  public LayerMask groundLayers;


  float mx;

  private void Update()
  {
    movementSpeed = 3;
    mx = Input.GetAxisRaw("Horizontal");

    if (Input.GetButtonDown("Jump") && Isgrounded())
    {
      Jump();

    }
  }

  private void FixedUpdate()
  {
    Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);

    rb.velocity = movement; 
  }

  public bool Isgrounded()
  {
    Collider2D groundcheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

    if (groundcheck != null)
    {
      return true; 
    }
    return false; 
  }
  void Jump()
  {
    Vector2 movement = new Vector2(rb.velocity.x, jumpForce);

    rb.velocity = movement;
  }
}
