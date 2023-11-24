using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : PlayerBaseState
{
    public override void EnterState(PlayerControllerFSM player)
    {
        MonoBehaviour.print("I am Idle");
        player.SetAnimatorTrigger(PlayerControllerFSM.AnimatorTriggerStates.Idle);
    }

    public override void Update(PlayerControllerFSM player)
    {
        if (player.stateMachine.currentBattleState == HeroStateMachine.BattleState.WAITING)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (!player.monsterB[0].isDead)
                {
                    player.enemySelected = 0;
                    player.DestroyGO(GameObject.FindGameObjectWithTag("Cursor"));
                    player.CreateCursor();
                }
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (player.monsterB.Length>=2&&!player.monsterB[1].isDead)
                {
                    player.enemySelected = 1;
                    player.DestroyGO(GameObject.FindGameObjectWithTag("Cursor"));
                    player.CreateCursor();
                }

            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (player.monsterB.Length >= 3 && !player.monsterB[2].isDead)
                {
                    player.enemySelected = 2;
                    player.DestroyGO(GameObject.FindGameObjectWithTag("Cursor"));
                    player.CreateCursor();
                }

            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (player.monsterB.Length >= 4 && !player.monsterB[3].isDead)
                {
                    player.enemySelected = 3;
                    player.DestroyGO(GameObject.FindGameObjectWithTag("Cursor"));
                    player.CreateCursor();
                }
            }
            //Input.GetButton("Fire1");
            if (Input.GetKeyDown("1") && player.enemySelected != -1)
            {
                player.stateMachine.currentBattleState = HeroStateMachine.BattleState.ACTION;
                player.attackSelected = 0;
                player.TransitionToState(player.RunningState);
                //StartCoroutine(Attacking(character.attacks[0], enemies[enemySelected]));
            }
            else if (Input.GetKeyDown("2") && player.enemySelected != -1)
            {
                player.stateMachine.currentBattleState = HeroStateMachine.BattleState.ACTION;
                player.attackSelected = 1;
                player.TransitionToState(player.RunningState);
                //StartCoroutine(Attacking(character.attacks[1], enemies[enemySelected]));
            }
            else if (Input.GetKeyDown("3") && player.enemySelected != -1)
            {
                player.stateMachine.currentBattleState = HeroStateMachine.BattleState.ACTION;
                player.attackSelected = 2;
                player.TransitionToState(player.RunningState);
                //StartCoroutine(Attacking(character.attacks[2], enemies[enemySelected]));
            }
            else if (Input.GetKeyDown("4"))
            {
                player.potions.useHP(player.stateMachine.character);
            }
            else if (Input.GetKeyDown("5"))
            {
                player.potions.useMP(player.stateMachine.character);
            }
            else if (Input.GetKeyDown("6"))
            {
                player.potions.useST(player.stateMachine.character);
            }

        }
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
