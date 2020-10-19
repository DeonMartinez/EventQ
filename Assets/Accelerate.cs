using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Accelerate : MonoBehaviour
{
    public Text outputText;

    private bool m_IsQuitting;
    void OnEnable()
    {
        EventBus.StartListening("Accelerate", SpeedUp);
    }
    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }
    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Accelerate", SpeedUp);
        }
    }
    void SpeedUp()
    {
        outputText.text = "Received an accelerate event : Entering Ludicrous Speed!";
    }
}
