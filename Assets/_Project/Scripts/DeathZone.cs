using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DeathZone : MonoBehaviour {

    private void Awake()
    {
        m_cameraScreen = Calcul.ScreenSize(Camera.main);
        GetComponent<BoxCollider2D>().isTrigger = true;
        m_player = FindObjectOfType<PlayerController2D>();
        m_plateform = FindObjectOfType<PlateformBouncing>();
    }

    private void Start()
    {
        transform.localScale = new Vector2(m_cameraScreen.x * 2 + transform.lossyScale.x, 1f);
    }

    private void Update()
    {
        transform.position = new Vector2(0f, ((-m_cameraScreen.y * .5f) - (transform.lossyScale.y * 2)) + Camera.main.transform.position.y);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == m_player.gameObject)
            print("GAME OVER!");
        else if(other.gameObject == m_plateform.gameObject)
            print("PLATFORM DESTROY!");

        Destroy(other.gameObject);

    }

    private Vector3 m_cameraScreen;
    private PlayerController2D m_player;
    private PlateformBouncing m_plateform;
}
