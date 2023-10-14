using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : PlayerBaseState
{
    public override void EnterState(PlayerControllerFSM player)
    {
        MonoBehaviour.print("I Won :)");
        player.SetAnimatorTrigger(PlayerControllerFSM.AnimatorTriggerStates.Win);
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
