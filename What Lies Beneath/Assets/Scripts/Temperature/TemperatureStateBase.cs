using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TemperatureBaseState
{
    public abstract void EnterState(TemperatureFSM player);
    public abstract void Update(TemperatureFSM player);
    public abstract void LateUpdate(TemperatureFSM player);
    public abstract void OnTriggerEnter(TemperatureFSM player, Collider collider);
    public abstract void OnCollisionEnter(TemperatureFSM player, Collision collider);
}
