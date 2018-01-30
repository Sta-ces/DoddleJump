using UnityEngine;

public class PlateformBouncing : MonoBehaviour {
    
    public float JumpHigher = 5f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rigidbody = collision.collider.GetComponent<Rigidbody2D>();

        if(rigidbody != null)
        {
            Vector2 velocity = rigidbody.velocity;
            velocity.y = JumpHigher;
            rigidbody.velocity = velocity;
        }
    }
}
