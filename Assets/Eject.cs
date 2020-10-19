using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Eject : MonoBehaviour
{
    public Text outputText;

    private bool m_IsQuitting;
    void OnEnable()
    {
        EventBus.StartListening("Eject", EjectAFool);
    }
    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }
    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Eject", EjectAFool);
        }
    }
    void EjectAFool()
    {
        outputText.text = "Received an eject event : Ejecting the imposter!";
    }
}
