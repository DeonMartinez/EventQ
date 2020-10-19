using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Rocket : MonoBehaviour
{
    public Text outputText;

    private bool m_IsQuitting;
    private bool m_IsLaunched = false;
    void OnEnable()
    {
        EventBus.StartListening("Launch", Launch);
    }
    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }
    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Launch", Launch);
        }
    }
    void Launch()
    {
        if (m_IsLaunched == false)
        {
            m_IsLaunched = true;
            outputText.text = "Received a launch event : rocket launching!";
        }
    }
}

