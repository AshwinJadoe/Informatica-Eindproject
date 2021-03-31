using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float moveSpeed;
  public float jumpForce;

  private Rigidbody2D myRigidbody;

  void Start()
  {
    myRigidbody = this.gameObject.GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

    if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
    {
      myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
    }
  }
}
