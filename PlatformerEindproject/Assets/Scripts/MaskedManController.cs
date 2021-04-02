using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskedManController : MonoBehaviour
{

  public float movementSpeed;
  public float jumpForce;


  private Rigidbody2D myRigidbody;

  public bool grounded;
  public bool isFalling;
  public LayerMask whatIsGround;

  

  private Collider2D myCollider;

  private Animator myAnimator;

  void Start()
  {
    myRigidbody = GetComponent<Rigidbody2D>();

    myCollider = GetComponent<Collider2D>();

    myAnimator = GetComponent<Animator>();
  }

  void Update()
  {

    grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

    myRigidbody.velocity = new Vector2(movementSpeed, myRigidbody.velocity.y);

    if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
    {
      if (grounded)
      {
        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
      }
    }

    if (myRigidbody.velocity.y < -0.1)
    {
      isFalling = true;
    }
    else
    {
      isFalling = false;
    }

    myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
    myAnimator.SetBool("Grounded", grounded);
    myAnimator.SetBool("Fall", isFalling);


  }
}
