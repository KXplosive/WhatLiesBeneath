using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehavior 
{
    public abstract void EnterState(Enemy enemy);
    public abstract void Update(Enemy enemy);
    public abstract void LateUpdate(Enemy enemy);
    public abstract void ExitState(Enemy enemy);
}
