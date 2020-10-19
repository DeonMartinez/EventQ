using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cannon : MonoBehaviour
{
    public Text outputText;

    private bool m_IsQuitting;
    void OnEnable()
    {
        EventBus.StartListening("Shoot", Shoot);
    }
    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }
    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Shoot", Shoot);
        }
    }
    void Shoot()
    {
        outputText.text = "Received a shoot event : shooting cannon!";
    }
}

