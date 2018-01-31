using System;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {
    
    public Text m_LocationScore;
    public Text m_LocationHighScore;
    public Transform m_TargetScoring;
    
    
    public static float score = 0;
    public static float m_highScore = 0;


    private void Awake()
    {
        m_LocationScore.text = score.ToString();
        m_lastPosition = m_TargetScoring.position;

        m_highScore = PlayerPrefs.GetFloat("HighScore");
        PlayerPrefs.SetFloat("HighScore", m_highScore);

        m_LocationHighScore.text = PlayerPrefs.GetFloat("HighScore").ToString();
    }

    private void Update()
    {
        if(m_TargetScoring.position.y > m_lastPosition.y)
        {
            score++;
            m_lastPosition = m_TargetScoring.position;
        }

        if(score > m_highScore)
        {
            m_highScore = score;
            PlayerPrefs.SetFloat("HighScore", m_highScore);
            m_LocationHighScore.text = PlayerPrefs.GetFloat("HighScore").ToString();
        }

        m_LocationScore.text = score.ToString();
    }


    private Vector2 m_lastPosition;
}


[Serializable]
public class HighScore
{
    public float score;

    public HighScore(float _score)
    {
        score = _score;
    }
}