using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatScreenController : MonoBehaviour
{
    public PlayerControllerFSM player;
    public Potions potions;
    public TMP_Text level, hp, mp, st, attack, defense;
    public PersonajeBase stats;
    public Image hpPotSprite, mpPotSprite, stPotSprite;
    public TMP_Text hpPotText, mpPotText, stPotText;
    public Image[] itemsImg;

    Inventory inventory;

    private void Start()
    {
        potions = player.gameObject.GetComponent<Potions>();
        inventory = player.inventory;
        UpdateInventory();
    }

    private void Update()
    {
        stats = player.stateMachine.character;
        level.text = stats.level.ToString();
        hp.text = ((int)stats.currentHP).ToString() + "/" + stats.baseHP.ToString();
        mp.text = ((int)stats.currentMP).ToString() + "/" + stats.baseMP.ToString();
        st.text = ((int)stats.currentST).ToString() + "/" + stats.baseST.ToString();
        attack.text = stats.currentAttack.ToString();
        defense.text = stats.currentDefense.ToString();

        hpPotText.text = "x"+potions.quantityHP.ToString();
        if (potions.quantityHP > 0) {
            changeImageWhite(hpPotSprite);
        }
        else
        {
            changeImageGray(hpPotSprite);
        }
        mpPotText.text = "x" + potions.quantityMP.ToString();
        if (potions.quantityMP > 0)
        {
            changeImageWhite(mpPotSprite);
        }
        else
        {
            changeImageGray(mpPotSprite);
        }
        stPotText.text = "x" + potions.quantityST.ToString();
        if (potions.quantityST > 0)
        {
            changeImageWhite(stPotSprite);
        }
        else
        {
            changeImageGray(stPotSprite);
        }
    }

    void changeImageGray(Image image)
    {
        image.color = new Color(0.25f, 0.25f, 0.25f);
    }

    void changeImageWhite(Image image)
    {
        image.color = new Color(1f, 1f, 1f);
    }

    public void UpdateInventory()
    {
        for(int i = 0; i < itemsImg.Length; i++)
        {
            if (i < inventory.getSize())
            {
                itemsImg[i].sprite = inventory.items[i].sprite;
                itemsImg[i].gameObject.SetActive(true);
            }
            else
            {
                itemsImg[i].gameObject.SetActive(false);
            }
        }
    }
}
