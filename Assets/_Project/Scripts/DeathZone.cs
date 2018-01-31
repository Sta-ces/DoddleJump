using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DeathZone : MonoBehaviour {

    private void Awake()
    {
        m_cameraScreen = Calcul.ScreenSize(Camera.main);
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void Start()
    {
        transform.localScale = new Vector2(m_cameraScreen.x * 2 + transform.lossyScale.x, 1f);
    }

    private void LateUpdate()
    {
        transform.position = new Vector2(0f, (-m_cameraScreen.y + (transform.lossyScale.y * .5f) - .5f) + Camera.main.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController2D>() != null)
        {
            other.gameObject.SetActive(false);

            UIScript.isDead = true;
        }
        else if(other.gameObject.GetComponent<PlateformBouncing>() != null)
        {
            Destroy(other.gameObject);
        }
    }

    private Vector3 m_cameraScreen;
}
