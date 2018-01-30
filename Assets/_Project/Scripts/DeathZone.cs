﻿using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class DeathZone : MonoBehaviour {

    public Text m_GameOverText;


    private void Awake()
    {
        m_cameraScreen = Calcul.ScreenSize(Camera.main);
        GetComponent<BoxCollider2D>().isTrigger = true;
        m_GameOverText.text = "";
    }

    private void Start()
    {
        transform.localScale = new Vector2(m_cameraScreen.x * 2 + transform.lossyScale.x, 1f);
    }

    private void LateUpdate()
    {
        transform.position = new Vector2(0f, ((-m_cameraScreen.y * .5f) - (transform.lossyScale.y * 2)) + Camera.main.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController2D>() != null)
        {
            print("GAME OVER!");
            m_GameOverText.text = "Game Over";
            other.gameObject.SetActive(false);
        }
        else if(other.gameObject.GetComponent<PlateformBouncing>() != null)
        {
            print("PLATFORM DESTROY!");
            Destroy(other.gameObject);
        }
    }

    private Vector3 m_cameraScreen;
}
