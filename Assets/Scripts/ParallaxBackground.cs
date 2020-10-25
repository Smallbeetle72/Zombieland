using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 2f)]
    private float m_multiplier = 0.0f;

    [SerializeField]
    private bool m_horizontalOnly = true;

    private Transform m_cameraTransform;

    private Vector3 m_startCameraPos;
    private Vector3 m_startPos;


    void Start()
    {
        m_cameraTransform = Camera.main.transform;
        m_startCameraPos = m_cameraTransform.position;

        float m_initDx = transform.position.x - m_startCameraPos.x;
        transform.position = new Vector3(transform.position.x - (m_multiplier * m_initDx), transform.position.y, transform.position.z);

        m_startPos = transform.position;
    }


    private void LateUpdate()
    {
        var position = m_startPos;
        if (m_horizontalOnly)
        {
            position.x += m_multiplier * (m_cameraTransform.position.x - m_startCameraPos.x);
        }
        else
        {
            position.x += m_multiplier * (m_cameraTransform.position.x - m_startCameraPos.x);
            position.y += m_multiplier * (m_cameraTransform.position.y - m_startCameraPos.y);
        }
        transform.position = position;
    }

}
