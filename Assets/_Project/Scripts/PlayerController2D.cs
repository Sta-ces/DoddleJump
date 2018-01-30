using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour {

    public float m_SpeedPlayer = 5f;


    private void Awake()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

	private void FixedUpdate()
    {
        MovePlayer2D();
    }


    private void MovePlayer2D()
    {
        float horizontalMoves = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = m_rigidbody2D.velocity;

        velocity.x = horizontalMoves * m_SpeedPlayer;

        m_rigidbody2D.velocity = velocity;
    }


    private Rigidbody2D m_rigidbody2D;
}
