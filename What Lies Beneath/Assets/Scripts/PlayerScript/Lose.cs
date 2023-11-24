using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : PlayerBaseState
{
    public override void EnterState(PlayerControllerFSM player)
    {
        MonoBehaviour.print("I Lost :(");
        player.SetAnimatorTrigger(PlayerControllerFSM.AnimatorTriggerStates.Faint);
    }

    public override void Update(PlayerControllerFSM player)
    {

    }

    public override void LateUpdate(PlayerControllerFSM player)
    {

    }

    public override void OnTriggerEnter(PlayerControllerFSM player, Collider collider)
    {

    }

    public override void OnCollisionEnter(PlayerControllerFSM player, Collision collision)
    {

    }
}