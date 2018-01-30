using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorPlatform : MonoBehaviour {

    public GameObject m_PrefabsPlatform;


    private void Awake()
    {
        cameraViewSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -Camera.main.transform.position.z));
        print(cameraViewSize);

        m_MaxSpaceBetweenPlatform = PlateformBouncing.JumpHigher;

        SpawnPlatform();
    }


    private void SpawnPlatform()
    {
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < 10; i++)
        {
            spawnPosition.y += Random.Range(m_MinSpaceBetweenPlatform, m_MaxSpaceBetweenPlatform);
            spawnPosition.x = Random.Range(-cameraViewSize.x, cameraViewSize.x);
            Instantiate(m_PrefabsPlatform, spawnPosition, Quaternion.identity);
        }
    }


    private Vector3 cameraViewSize;
    private float m_MinSpaceBetweenPlatform = .2f;
    private float m_MaxSpaceBetweenPlatform = 1f;

    /*public GameObject platformPrefab;

    public int numberOfPlatforms = 200;
    public float levelWidth = 3f;
    public float minY = .2f;
    public float maxY = 1.5f;

    // Use this for initialization
    void Start()
    {

        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
    }*/
}
