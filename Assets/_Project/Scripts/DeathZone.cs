using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DeathZone : MonoBehaviour {



    private void Awake()
    {
        m_cameraScreen = Calcul.ScreenSize(Camera.main);
        GetComponent<BoxCollider2D>().isTrigger = true;
        transform.localScale = new Vector2(m_cameraScreen.x *2 + transform.lossyScale.x, 1f);
    }

    private void Update()
    {
        transform.position = new Vector2(0f, ((-m_cameraScreen.y * .5f) - (transform.lossyScale.y * 2)) + Camera.main.transform.position.y);
    }


    private Vector3 m_cameraScreen;
}
