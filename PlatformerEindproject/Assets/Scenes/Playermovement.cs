using UnityEngine;

public class Playermovement : MonoBehaviour
{
  public float moveSpeed = 4f;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    //Jump();
    Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
    transform.position += movement * Time.deltaTime * moveSpeed;
  }


  
}
