
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
  public Transform target;

  public float smoothSpeed = 0.125f;
  public Vector3 offset;

  void LateUpdate (){
    transform.position = target.position + offset;
    }
}
