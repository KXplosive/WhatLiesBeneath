using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : PlayerBaseState
{
    MonsterB enemyState;
    Attack attack;

    public override void EnterState(PlayerControllerFSM player)
    {
        enemyState = player.monsterB[player.enemySelected];
        attack = player.stateMachine.character.attacks[player.attackSelected];
        MonoBehaviour.print("I am Attacking");
        player.SetAnimatorTrigger(PlayerControllerFSM.AnimatorTriggerStates.Attack);
        player.StartCoroutine(WaitForAnimationOfAttack(player, this, player.Animator.GetCurrentAnimatorClipInfo(0)[0].clip.length));
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

    IEnumerator WaitForAnimationOfAttack(PlayerControllerFSM player, Attacking state,float length)
    {
        yield return new WaitForSeconds(length);
        player.stateMachine.character.currentST -= attack.ST;
        player.stateMachine.character.currentMP -= attack.MP;
        enemyState.enemyBase.currentHP -= DamageCalc(player.stateMachine.character.currentAttack, enemyState.enemyBase.currentDefense, attack.baseDamage);
        yield return null;
        if (enemyState.enemyBase.currentHP<=0)
        {
            player.enemySelected = -1;
            player.DestroyGO(GameObject.FindGameObjectWithTag("Cursor"));

        }
        player.TransitionToState(player.ReturnState);
        // hacer algo al terminar la animacion
        // cambiar estado y destruir
    }

    float DamageCalc(float attack, float defense, int baseAttack)
    {
        Debug.Log(baseAttack * (defense / 100) / (attack / 50));
        return baseAttack * (defense / 100) / (attack / 50);
    }
}
