using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class DeathZone : MonoBehaviour {

    public Text m_LocationGameOver;
    public string m_TextGameOver;
    public Button m_ButtonStart;
    public Button m_ButtonQuit;


    private void Awake()
    {
        m_cameraScreen = Calcul.ScreenSize(Camera.main);
        GetComponent<BoxCollider2D>().isTrigger = true;
        m_LocationGameOver.text = "";
    }

    private void Start()
    {
        transform.localScale = new Vector2(m_cameraScreen.x * 2 + transform.lossyScale.x, 1f);
    }

    private void LateUpdate()
    {
        transform.position = new Vector2(0f, (-m_cameraScreen.y + (transform.lossyScale.y * .5f)) + Camera.main.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController2D>() != null)
        {
            m_LocationGameOver.text = m_TextGameOver+"\n"+Scoring.score;
            other.gameObject.SetActive(false);
            m_ButtonQuit.gameObject.SetActive(true);
            m_ButtonStart.gameObject.SetActive(true);
            m_ButtonStart.gameObject.GetComponentInChildren<Text>().text = "Again";
        }
        else if(other.gameObject.GetComponent<PlateformBouncing>() != null)
        {
            Destroy(other.gameObject);
        }
    }

    private Vector3 m_cameraScreen;
}
