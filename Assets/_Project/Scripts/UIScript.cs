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

        m_LocationTextStart.text = m_TextToBegin + m_TextWhatIDo;
    }

    private void Start()
    {
        Time.timeScale = 0;
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
            if (isDead)
            {
                LoadingLevel.Restart();
                isDead = false;
            }
            else
            {
                OnPaused();
                DisplayPaused();
            }
        }

        /*if (isDead)
        {
            m_TextWhatIDo = " to Restart";
            m_LocationTextGameOver.text = "Game Over\n" + Scoring.score;
            m_LocationTextGameOver.gameObject.SetActive(true);
        }*/
    }


    private void OnPaused()
    {
        if (Time.timeScale == 1)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    private void DisplayPaused()
    {
        if (!isDebut)
            m_LocationTextPaused.gameObject.SetActive(!m_LocationTextPaused.gameObject.activeSelf);


        m_LocationTextStart.gameObject.SetActive(!m_LocationTextStart.gameObject.activeSelf);
        m_QuitButton.gameObject.SetActive(!m_QuitButton.gameObject.activeSelf);
        isDebut = false;
    }


    private string m_TextToBegin = "Space";
    private string m_TextWhatIDo = " to Start";
}
