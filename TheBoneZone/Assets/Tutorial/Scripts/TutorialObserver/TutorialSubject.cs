using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TutorialSubject : MonoBehaviour
{
    List<ITutorialObserver> tutorialObservers = new List<ITutorialObserver>();
    
    public void AddObserver(ITutorialObserver observer)
    {
        tutorialObservers.Add(observer);
    }

    public void RemoveObserver(ITutorialObserver observer)
    {
        tutorialObservers.Remove(observer);
    }

    protected void NotifyTrigger(string trigger)
    {
        foreach(ITutorialObserver observer in tutorialObservers)
        {
            observer.OnTrigger(trigger);
        }
    }
}
