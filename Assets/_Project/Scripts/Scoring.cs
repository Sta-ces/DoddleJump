using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

    public Text m_LocationText;
    public Transform m_TargetScoring;


    private void Awake()
    {
        m_LocationText.text = m_score.ToString();
        m_lastPosition = m_TargetScoring.position;
    }

    private void Update()
    {
        if(m_TargetScoring.position.y > m_lastPosition.y)
        {
            m_score++;
            m_lastPosition = m_TargetScoring.position;
        }

        m_LocationText.text = m_score.ToString();
    }


    private float m_score = 0;
    private Vector2 m_lastPosition;
}
