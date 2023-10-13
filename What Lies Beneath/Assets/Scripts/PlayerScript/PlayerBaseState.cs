using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void EnterState(PlayerControllerFSM player);
    public abstract void Update(PlayerControllerFSM player);
    public abstract void LateUpdate(PlayerControllerFSM player);
    public abstract void OnTriggerEnter(PlayerControllerFSM player, Collider collider);
    public abstract void OnCollisionEnter(PlayerControllerFSM player, Collision collider);
}