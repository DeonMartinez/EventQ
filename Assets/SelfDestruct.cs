using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelfDestruct : MonoBehaviour
{
    public Text outputText;
    
    private bool m_IsQuitting;
    void OnEnable()
    {
        EventBus.StartListening("SelfDestruct", Boom);
    }
    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }
    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("SelfDestruct", Boom);
        }
    }
    void Boom()
    {
        outputText.text = "Received a Self Destruct event : Congratulations you have died ;p";

    }
}
