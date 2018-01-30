using UnityEngine;

public class PlateformBouncing : MonoBehaviour {

    public float m_JumpHigher = 5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rigidbody = collision.collider.GetComponent<Rigidbody2D>();

        if(rigidbody != null)
        {
            Vector2 velocity = rigidbody.velocity;
            velocity.y = m_JumpHigher;
            rigidbody.velocity = velocity;
        }
    }
}
