using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConditionalEvent : MonoBehaviour
{
    public List<Lamp> lamps = new List<Lamp>();
    public UnityEvent onConditionTrue, onConditionFalse;

    private void Update()
    {
        bool conditionFull = true;

        foreach (Lamp lamp in lamps)
        {
            if (!lamp.on)
            {
                conditionFull = false;
            }
        }

        if(conditionFull) 
        {
            onConditionTrue.Invoke();
        }
        else
        {
            onConditionFalse.Invoke();
        }
    }
}
