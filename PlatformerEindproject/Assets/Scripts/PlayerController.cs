using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float moveSpeed;
  public float jumpForce;
  public float moveAcceleration;

  private Rigidbody2D myRigidbody;

  public bool grounded;
  public LayerMask whatIsGround;

  private Collider2D myCollider;

  void Start()
  {
    myRigidbody = this.gameObject.GetComponent<Rigidbody2D>();
    myCollider = this.gameObject.GetComponent<Collider2D>();

  }

  void Update()
  {
    grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
    moveSpeed += Time.deltaTime * moveAcceleration;

    myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

    if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
    {
      if (grounded == true)
      {
        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
      }
    }
  }
}
