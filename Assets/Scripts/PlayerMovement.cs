using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody2D rb;
   
    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        rb.linearVelocity = new Vector2(horizontal, vertical) * speed;
    }
}
