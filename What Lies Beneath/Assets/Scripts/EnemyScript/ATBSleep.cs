using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATBSleep : EnemyBehavior
{
    public override void EnterState(Enemy enemy)
    {
        enemy.enemyBase.stamina = 0;
    }

    public override void ExitState(Enemy enemy)
    {

    }

    public override void LateUpdate(Enemy enemy)
    {

    }

    public override void Update(Enemy enemy)
    {

    }
    IEnumerator ATB_wait(float stamina, Enemy enemy)
    {
        //yield on a new YieldInstruction that waits for stamina.
        yield return new WaitForSeconds(stamina);
        enemy.ec.ATBcomplete(enemy);
    }
}
