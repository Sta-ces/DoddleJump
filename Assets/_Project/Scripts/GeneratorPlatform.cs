using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorPlatform : MonoBehaviour {

    public GameObject m_PrefabsPlatform;
    public int m_NumberOfPlatformsToSpawn = 100;
    public float m_SpaceBetweenPlatform = .5f;
    /*public float m_MinSpaceBetweenPlatform = .2f;
    public float m_MaxSpaceBetweenPlatform = .8f;*/


    private void Awake()
    {
        cameraViewSize = Calcul.ScreenSize(Camera.main);

        SpawnPlatform();
    }

    private void Update()
    {
        if (m_lastPlateform.y - cameraViewSize.y <= Camera.main.transform.position.y)
        {
            m_SpaceBetweenPlatform += .5f;
            SpawnPlatform();
        }
    }


    private void SpawnPlatform()
    {
        for (int i = 0; i < m_NumberOfPlatformsToSpawn; i++)
        {
            spawnPosition.y += m_SpaceBetweenPlatform;
            spawnPosition.x = Random.Range(-cameraViewSize.x, cameraViewSize.x);
            GameObject platform = Instantiate(m_PrefabsPlatform, spawnPosition, Quaternion.identity);
            if (i == m_NumberOfPlatformsToSpawn - 1)
                m_lastPlateform = platform.transform.position;
        }
    }


    private Vector3 cameraViewSize;
    private Vector3 spawnPosition = new Vector3();
    private Vector3 m_lastPlateform;
}
