using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {
    
    public Text m_LocationScore;
    public Text m_LocationHighScore;
    public Transform m_TargetScoring;

    [Header("JSON")]
    public string m_PathJSONFile;


    private void Awake()
    {
        m_LocationScore.text = m_score.ToString();
        m_lastPosition = m_TargetScoring.position;
        
        m_path = Application.dataPath + m_PathJSONFile;
        m_jsonString = File.ReadAllText(m_path);
        HighScore highScore = JsonUtility.FromJson<HighScore>(m_jsonString);

        if (highScore != null)
            m_highScore = highScore.score;

        m_LocationHighScore.text = m_highScore.ToString();
    }

    private void Start()
    {
        File.WriteAllText(m_path, JsonUtility.ToJson(new HighScore(m_score)));
    }

    private void Update()
    {
        if(m_TargetScoring.position.y > m_lastPosition.y)
        {
            m_score++;
            m_lastPosition = m_TargetScoring.position;
        }

        if(m_score > m_highScore)
        {
            m_highScore = m_score;
            m_LocationHighScore.text = m_highScore.ToString();
            File.WriteAllText(m_path, JsonUtility.ToJson(new HighScore(m_score)));
        }

        m_LocationScore.text = m_score.ToString();
    }


    public static float m_score = 0;
    private float m_highScore = 0;
    private Vector2 m_lastPosition;

    private string m_path;
    private string m_jsonString;
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