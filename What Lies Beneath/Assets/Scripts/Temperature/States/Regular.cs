using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regular : TemperatureBaseState
{
    public override void EnterState(TemperatureFSM player)
    {
        player.RestartStats();
        player.character.currentAttack = player.character.attack * 2;
        player.character.currentDefense = player.character.defense * 2;
    }

    public override void Update(TemperatureFSM player)
    {
        switch (player.character.temperature)
        {
            case >= 70:
                player.TransitionToState(player.ScorchingState);
                break;
            case >= 55 and < 70:
                player.TransitionToState(player.HighState);
                break;
            case >= 40 and < 55:
                player.TransitionToState(player.ModerateState);
                break;
            case >= 30 and < 40:
                break;
            case >= 15 and < 30:
                player.TransitionToState(player.ReducedState);
                break;
            case > 0 and < 15:
                player.TransitionToState(player.LowState);
                break;
            case <= 0:
                player.TransitionToState(player.FreezingState);
                break;
        }
    }

    public override void LateUpdate(TemperatureFSM player)
    {

    }

    public override void OnTriggerEnter(TemperatureFSM player, Collider collider)
    {

    }

    public override void OnCollisionEnter(TemperatureFSM player, Collision collision)
    {

    }
}
