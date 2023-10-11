using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Default : EnemyBehavior
{
    public override void EnterState(Enemy enemy)
    {
        // buscar target para ataque
        // para el demo solo ataca al player1
        // tras encontrarlo sacar duracion de la corutina
        // activa animacion de moving
    }

    public override void ExitState(Enemy enemy)
    {
        
    }

    public override void LateUpdate(Enemy enemy)
    {
        
    }

    public override void Update(Enemy enemy)
    {
        // ir de spawn point a posicion de enemigo y regresar a spawn point tras regresar a spawn llamar funcion
        // Animcacion: Idle -> Movimiento -> Attaque -> Movimiento -> Idle -> EndOfEnemyTurn
        // if (moving) {
            // if (lista en punto del target) llamar corutina
            // if (lista en punto de spawn) EndOfEnemyTurn
    }
    IEnumerator Attack(float stamina, Enemy enemy)
    {
        // yield on a new YieldInstruction that waits for stamina.
        // moving = false;
        // activa animacion y al mismo tiempo llamas a la corutina con la duracion obtenida
        yield return new WaitForSeconds(stamina);
        // moving = true;
        // activa animacion de moving
    }
}
