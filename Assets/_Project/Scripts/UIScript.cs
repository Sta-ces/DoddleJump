using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    public GameObject m_Player;
    public Text m_LocationTextStart;
    public Text m_LocationTextGameOver;
    public Text m_LocationTextPaused;
    public Button m_QuitButton;

    public static bool isDead = false;
    public static bool isDebut = true;


    public void ChangeColorText(string _hexColor)
    {
        _hexColor = _hexColor.Replace("#", "");

        Color myColor = new Color();
        ColorUtility.TryParseHtmlString("#" + _hexColor, out myColor);

        gameObject.GetComponent<Text>().color = myColor;
    }


    private void Awake()
    {
        #if UNITY_ANDROID && !UNITY_EDITOR
            m_TextToBegin = "Tap";
        #else
            m_TextToBegin = "Space";
        #endif
    }

    private void Start()
    {
        Time.timeScale = 0;
        m_TextWhatIDo = " to Start";
        m_LocationTextStart.text = m_TextToBegin + m_TextWhatIDo;
    }

    private void Update()
    {
        #if UNITY_ANDROID && !UNITY_EDITOR
            bool input = Input.touchPressureSupported;
        #else
            bool input = Input.GetKeyDown(KeyCode.Space);
        #endif

        if (input)
        {
            // If the game is paused
            if (m_LocationTextStart.gameObject.activeSelf)
            {
                print("Hello");
                if (m_LocationTextGameOver.gameObject.activeSelf)
                {
                    print("Coucou");
                    m_LocationTextGameOver.gameObject.SetActive(false);
                    m_QuitButton.gameObject.SetActive(true);
                    LoadingLevel.Restart();
                }
                else
                {
                    Time.timeScale = 1;
                    m_LocationTextPaused.gameObject.SetActive(false);
                    m_QuitButton.gameObject.SetActive(false);
                    m_LocationTextStart.gameObject.SetActive(false);
                }
            }
            // If the game is running
            else
            {
                Time.timeScale = 0;
                m_LocationTextPaused.gameObject.SetActive(true);
                m_QuitButton.gameObject.SetActive(true);
                m_LocationTextStart.gameObject.SetActive(true);
            }
        }

        if (isDead)
        {
            Time.timeScale = 0;
            m_TextWhatIDo = " to Restart";
            m_LocationTextStart.text = m_TextToBegin + m_TextWhatIDo;
            m_LocationTextGameOver.text = "Game Over\n" + Scoring.score;

            m_LocationTextGameOver.gameObject.SetActive(true);
            m_QuitButton.gameObject.SetActive(true);
            m_LocationTextStart.gameObject.SetActive(true);
        }
    }


    private string m_TextToBegin = "Space";
    private string m_TextWhatIDo = " to Start";
}
