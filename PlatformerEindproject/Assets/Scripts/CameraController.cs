using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  public float cameraSpeed;
  public PlayerController thePlayer;

  private Vector3 lastPlayerPosition;
  private float distanceToMove;


  void Start()
  {
    thePlayer = FindObjectOfType<PlayerController>();
    lastPlayerPosition = thePlayer.transform.position;
  }

  // Update is called once per frame
  void Update()
  {
   // distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;

    transform.position = new Vector3(transform.position.x + cameraSpeed, transform.position.y, transform.position.z);

    
  }
}
