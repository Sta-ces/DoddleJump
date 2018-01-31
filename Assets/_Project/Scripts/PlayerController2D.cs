using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour {

    public float m_SpeedPlayer = 5f;


    private void Awake()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_cameraView = Calcul.ScreenSize(Camera.main);
    }

    private void FixedUpdate()
    {
        MovePlayer2D();
    }


    private void MovePlayer2D()
    {
        #if UNITY_ANDROID && !UNITY_EDITOR
            float horizontalMoves = Input.acceleration.x;
        #else
            float horizontalMoves = Input.GetAxisRaw("Horizontal");
        #endif

        Vector2 velocity = m_rigidbody2D.velocity;

        velocity.x = horizontalMoves * m_SpeedPlayer;
        
        m_rigidbody2D.velocity = velocity;
        
        if (transform.position.x >= m_cameraView.x)
            m_rigidbody2D.transform.position = new Vector2(m_cameraView.x, transform.position.y);
        else if (transform.position.x <= -m_cameraView.x)
            m_rigidbody2D.transform.position = new Vector2(-m_cameraView.x, transform.position.y);
    }


    private Rigidbody2D m_rigidbody2D;
    private Vector3 m_cameraView;
}
