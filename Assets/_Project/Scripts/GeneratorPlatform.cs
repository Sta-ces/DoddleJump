using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorPlatform : MonoBehaviour {

    public GameObject m_PrefabsPlatform;
    public int m_NumberOfPlatformsToSpawn = 100;


    private void Awake()
    {
        cameraViewSize = Calcul.ScreenSize(Camera.main);

        SpawnPlatform();
    }

    private void Start()
    {
        m_minSpaceBetweenPlatform = PlateformBouncing.Jump / 10f;
        m_maxSpaceBetweenPlatform = m_minSpaceBetweenPlatform + .5f;
    }

    private void Update()
    {
        if (m_lastPlateform.y - cameraViewSize.y <= Camera.main.transform.position.y)
            SpawnPlatform();
    }


    private void SpawnPlatform()
    {
        for (int i = 0; i < m_NumberOfPlatformsToSpawn; i++)
        {
            spawnPosition.y += Random.Range(m_minSpaceBetweenPlatform, m_maxSpaceBetweenPlatform);
            spawnPosition.x = Random.Range(-cameraViewSize.x, cameraViewSize.x);
            GameObject platform = Instantiate(m_PrefabsPlatform, spawnPosition, Quaternion.identity);
            if (i == m_NumberOfPlatformsToSpawn - 1)
                m_lastPlateform = platform.transform.position;
        }
    }


    private Vector3 cameraViewSize;
    private Vector3 spawnPosition = new Vector3();
    private float m_minSpaceBetweenPlatform = .2f;
    private float m_maxSpaceBetweenPlatform = 1f;
    private Vector3 m_lastPlateform;
}
