using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Returning : PlayerBaseState
{
    float posX, posY,distX,distY;
    public override void EnterState(PlayerControllerFSM player)
    {
        distX = Mathf.Abs(player.gameObject.transform.position.x - player.startingPosition.x) * 5;
        distY = Mathf.Abs(player.gameObject.transform.position.y - player.startingPosition.y) * 5;
        MonoBehaviour.print("I am returning");
        player.SetAnimatorTrigger(PlayerControllerFSM.AnimatorTriggerStates.Return);
    }

    public override void Update(PlayerControllerFSM player)
    {
        // mover de regreso a posicion origihal
        if (player.gameObject.transform.position.x != player.startingPosition.x && player.gameObject.transform.position.y != player.startingPosition.y)
        {
            posX = player.gameObject.transform.position.x - distX * Time.deltaTime;
            if (posX < player.startingPosition.x)
            {
                posX = player.startingPosition.x;
            }
            if (player.gameObject.transform.position.y > player.startingPosition.y)
            {
                posY = player.gameObject.transform.position.y - distY * Time.deltaTime;
                if (posY < player.startingPosition.y)
                {
                    posY = player.startingPosition.y;
                }
            }
            else if (player.gameObject.transform.position.y < player.startingPosition.y)
            {
                posY = player.gameObject.transform.position.y + distY * Time.deltaTime;
                if (posY > player.startingPosition.y)
                {
                    posY = player.startingPosition.y;
                }
            }
            else
            {
                posY = player.startingPosition.y;
            }
            player.gameObject.transform.position = new Vector3(posX, posY);
        }
        else
        {
            if (player.stateMachine.currentBattleState != HeroStateMachine.BattleState.TIRED)
            {
                player.stateMachine.currentBattleState = HeroStateMachine.BattleState.WAITING;
            }
            player.TransitionToState(player.IdleState);
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
