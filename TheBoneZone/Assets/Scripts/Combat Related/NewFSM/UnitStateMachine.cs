using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitStateMachine : MonoBehaviour
{
    IUnitState currentState;

    Dictionary<Type, List<Transition>> transitions = new Dictionary<Type, List<Transition>>();
    List<Transition> currentTransitions = new List<Transition>();
    List<Transition> anyTransitions = new List<Transition>();

    static List<Transition> EmptyTransitions = new List<Transition>(0);

    public void OnUpdate()
    {
        var transition = GetTransition();
        if(transition != null)
        {
            SetState(transition.To);
        }
        currentState?.OnUpdate();
    }

    public void SetState(IUnitState state)
    {
        if (state == currentState)
            return;

        currentState?.OnExit();
        currentState = state;

        transitions.TryGetValue(currentState.GetType(), out currentTransitions);
        if(currentTransitions == null)
        {
            currentTransitions = EmptyTransitions;
        }

        currentState?.OnEnter();
    }

    public void AddTransition(IUnitState from, IUnitState to, Func<bool> predicate)
    {
        if (transitions.TryGetValue(from.GetType(), out var _transitions) == false)
        {
            _transitions = new List<Transition>();
            transitions[from.GetType()] = _transitions;
        }

        _transitions.Add(new Transition(to, predicate));
    }

    public void AddAnyTransition(IUnitState state, Func<bool> predicate)
    {
        anyTransitions.Add(new Transition(state, predicate));
    }

    private class Transition
    {
        public Func<bool> Condition { get; }
        public IUnitState To { get; }

        public Transition(IUnitState to, Func<bool> condition)
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