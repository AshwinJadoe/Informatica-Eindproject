using UnityEngine;

public class Character2dcontroller : MonoBehaviour
{
    public float MovementSpeed = 1;
    void Start()
    {
        
    }

    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
    }
}
