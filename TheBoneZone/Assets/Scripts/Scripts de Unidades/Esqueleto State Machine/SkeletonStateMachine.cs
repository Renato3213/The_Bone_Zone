using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStateMachine : MonoBehaviour
{
    ISkeletonState currentState;
    [SerializeField]
    Skeleton skeleton;

    Dictionary<Type, List<Transition>> transitions = new Dictionary<Type, List<Transition>>();
    List<Transition> currentTransitions = new List<Transition>();
    List<Transition> anyTransitions = new List<Transition>();

    static List<Transition> EmptyTransitions = new List<Transition>(0);

    public void OnUpdate()
    {
        var transition = GetTransition();
        if (transition != null)
        {
            SetState(transition.To);
        }
        currentState?.OnUpdate();
    }

    public void SetState(ISkeletonState state)
    {
        if (state == currentState)
            return;

        currentState?.OnExit();
        currentState = state;

        transitions.TryGetValue(currentState.GetType(), out currentTransitions);
        if (currentTransitions == null)
        {
            currentTransitions = EmptyTransitions;
        }

        currentState?.OnEnter(skeleton);
    }

    public void AddTransition(ISkeletonState from, ISkeletonState to, Func<bool> predicate)
    {
        if (transitions.TryGetValue(from.GetType(), out var _transitions) == false)
        {
            _transitions = new List<Transition>();
            transitions[from.GetType()] = _transitions;
        }

        _transitions.Add(new Transition(to, predicate));
    }

    public void AddAnyTransition(ISkeletonState state, Func<bool> predicate)
    {
        anyTransitions.Add(new Transition(state, predicate));
    }

    private class Transition
    {
        public Func<bool> Condition { get; }
        public ISkeletonState To { get; }

        public Transition(ISkeletonState to, Func<bool> condition)
        {
            To = to;
            Condition = condition;
        }
    }

    Transition GetTransition()
    {
        foreach (var transition in anyTransitions)
            if (transition.Condition())
                return transition;

        foreach (var transition in currentTransitions)
            if (transition.Condition())
                return transition;

        return null;
    }
}
