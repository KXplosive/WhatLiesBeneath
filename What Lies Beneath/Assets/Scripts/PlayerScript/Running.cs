using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : PlayerBaseState
{
    float posX;
    float posY;

    public override void EnterState(PlayerControllerFSM player)
    {
        MonoBehaviour.print("I am running");
        player.SetAnimatorTrigger(PlayerControllerFSM.AnimatorTriggerStates.DashNoMovement);
    }

    public override void Update(PlayerControllerFSM player)
    {
        // mover hacia el enemigo
        if(player.gameObject.transform.position.x < player.enemySelectedGO.transform.position.x && player.gameObject.transform.position.y != player.enemySelectedGO.transform.position.y)
        {
            if (player.gameObject.transform.position.x < player.enemySelectedGO.transform.position.x)
            {
                posX = player.gameObject.transform.position.x + 10f * Time.deltaTime;
            }
            else
            {
                posX = player.gameObject.transform.position.x;
            }
            if (player.gameObject.transform.position.y < player.enemySelectedGO.transform.position.y)
            {
                posY = player.gameObject.transform.position.y + 10f * Time.deltaTime;
            }
            else if (player.gameObject.transform.position.y > player.enemySelectedGO.transform.position.y)
            {
                posY = player.gameObject.transform.position.y - 10f * Time.deltaTime;
            }
            else
            {
                posY = player.gameObject.transform.position.y;
            }
            player.gameObject.transform.position = new Vector3(posX, posY);
        }
        else
        {
            player.TransitionToState(new Attacking());
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
