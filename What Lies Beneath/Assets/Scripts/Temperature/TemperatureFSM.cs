using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureFSM : MonoBehaviour
{
    private TemperatureBaseState currentState;
    public TemperatureBaseState CurrentState
    {
        get { return currentState; }
    }

    public PersonajeBase character;

    public readonly Freezing FreezingState = new Freezing();
    public readonly High HighState = new High();
    public readonly Low LowState = new Low();
    public readonly Reduced ReducedState = new Reduced();
    public readonly Regular RegularState = new Regular();
    public readonly Scorching ScorchingState = new Scorching();
    public readonly Moderate ModerateState = new Moderate();

    // Start is called before the first frame update
    void Start()
    {
        character = gameObject.GetComponent<HeroStateMachine>().character;
        switch (character.temperature)
        {
            case >=70:
                TransitionToState(ScorchingState);
                break;
            case >= 55 and < 70:
                TransitionToState(HighState);
                break;
            case >= 40 and < 55:
                TransitionToState(ModerateState);
                break;
            case >= 30 and < 40:
                TransitionToState(RegularState);
                break;
            case >= 15 and < 30:
                TransitionToState(ReducedState);
                break;
            case > 0 and < 15:
                TransitionToState(LowState);
                break;
            case <= 0:
                TransitionToState(FreezingState);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(this, other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }

    internal void TransitionToState(TemperatureBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public void RestartStats()
    {
        character.currentAttack = character.attack;
        character.currentDefense = character.defense;
    }
}
