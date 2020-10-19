using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventBus : Singleton<EventBus>
{
    private Dictionary<string, UnityEvent> m_EventDictionary;


    public int qCount = 0;
    public float qDelay = 1f;
    private Queue<string> eventQueue;
    public bool qKey = false;

    public override void Awake()
    {
        base.Awake();
        Instance.Init();
    }

    private void Init()
    {
        if (Instance.m_EventDictionary == null)
        {
            Instance.m_EventDictionary = new Dictionary<string,
            UnityEvent>();
        }

        if (Instance.eventQueue == null)
        {
            Instance.eventQueue = new Queue<string>();
        }
    }

    public static void  AddToQueue(string eventName)
    {
        Instance.eventQueue.Enqueue(eventName);
        Instance.qCount++;
    }

    public IEnumerator runEvents()
    {
        yield return new WaitForSeconds(qDelay);

        while (qCount > 0)
        {
            TriggerEvent(Instance.eventQueue.Dequeue());
            Instance.qCount--;
            yield return new WaitForSeconds(qDelay);
        }
        qKey = false;
    }

    public static void StartListening(string eventName, UnityAction
    listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.m_EventDictionary.TryGetValue(eventName, out
        thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Instance.m_EventDictionary.Add(eventName, thisEvent);
        }
    }
    public static void StopListening(string eventName, UnityAction
    listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.m_EventDictionary.TryGetValue(eventName, out
        thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }
    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (Instance.m_EventDictionary.TryGetValue(eventName, out
        thisEvent))
        {
            thisEvent.Invoke();
        }
    }

    void Update()
    {
        if (qKey == false && qCount > 0)
        {
            StartCoroutine("runEvents");
            qKey = true;
        }
    }
}
