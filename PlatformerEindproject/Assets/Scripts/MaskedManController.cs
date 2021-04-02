using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskedManController : MonoBehaviour
{

  public float movementSpeed;
  private float movementSpeedStore;
  public float speedMultiplier;

  public float speedIncreaseMilestone;
  private float speedIncreaseMilestoneStore;

  public float location;
  private float speedMilestoneCount;
  private float speedMilestoneCountStore;

  public float jumpForce;

  public float jumpTime;
  private float jumpTimeCounter;

  private Rigidbody2D myRigidbody;

  public bool grounded;
  public bool isFalling;
  public LayerMask whatIsGround;
  public Transform groundCheck;
  public float groundCheckRadius;

  //private Collider2D myCollider;

  private Animator myAnimator;

  public GameManager theGameManager;

  void Start()
  {
    myRigidbody = GetComponent<Rigidbody2D>();

    // myCollider = GetComponent<Collider2D>();

    myAnimator = GetComponent<Animator>();

    jumpTimeCounter = jumpTime;
    speedMilestoneCount += speedIncreaseMilestone;

    movementSpeedStore = movementSpeed;
    speedMilestoneCountStore = speedMilestoneCount;
    speedIncreaseMilestoneStore = speedIncreaseMilestone;
  }



  void Update()
  {
    location = transform.position.x;

    if (location > speedMilestoneCount)
    {
      speedMilestoneCount += speedIncreaseMilestone;
      movementSpeed = movementSpeed * speedMultiplier;
    }

    //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

    grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);


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

    if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
    {
      if (jumpTimeCounter > 0)
      {
        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
        jumpTimeCounter -= Time.deltaTime;
      }
    }

    if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
    {
      jumpTimeCounter = 0;
    }

    if (grounded)
    {
      jumpTimeCounter = jumpTime;
    }

    myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
    myAnimator.SetBool("Grounded", grounded);
    myAnimator.SetBool("Fall", isFalling);

  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "killbox")
    {
      
      theGameManager.RestartGame();
      movementSpeed = movementSpeedStore;
      speedMilestoneCount = speedMilestoneCountStore;
      speedIncreaseMilestone = speedIncreaseMilestoneStore;
    }
  }
}
