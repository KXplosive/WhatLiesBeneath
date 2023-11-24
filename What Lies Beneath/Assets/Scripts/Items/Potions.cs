using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions: MonoBehaviour
{
    public int quantityHP, quantityMP, quantityST;

    public void useHP(PersonajeBase player)
    {
        if (quantityHP > 0 && player.currentHP < player.baseHP)
        {
            player.currentHP += 20;
            if (player.currentHP > player.baseHP)
            {
                player.currentHP = player.baseHP;
            }
            quantityHP--;
        }
    }

    public void addHP(int num)
    {
        quantityHP += num;
    }

    public void useMP(PersonajeBase player){
        if (quantityMP > 0 && player.currentMP < player.baseMP)
        {
            player.currentMP += 50;
            if (player.currentMP > player.baseMP)
            {
                player.currentMP = player.baseMP;
            }
            quantityMP--;
        }
    }

    public void addMP(int num)
    {
        quantityMP += num;
    }

    public void useST(PersonajeBase player)
    {
        if (quantityST > 0 && player.currentST < player.baseST)
        {
            player.currentST += 50;
            if (player.currentST > player.baseST)
            {
                player.currentST = player.baseST;
            }
            quantityST--;
        }
    }

    public void addST(int num)
    {
        quantityST += num;
    }
}
