using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventPublisher : MonoBehaviour
{
    public Text qText;


    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            EventBus.AddToQueue("Shoot");
        }
        if (Input.GetKeyDown("w"))
        {
            EventBus.TriggerEvent("Launch");
        }
        if (Input.GetKeyDown("e"))
        {
            EventBus.TriggerEvent("Eject");
        }
        if (Input.GetKeyDown("r"))
        {
            EventBus.TriggerEvent("Accelerate");
        }
        if (Input.GetKeyDown("t"))
        {
            EventBus.AddToQueue("SelfDestruct");
        }

        qText.text = "Events in queue: " + EventBus.Instance.qCount;
    }
}

