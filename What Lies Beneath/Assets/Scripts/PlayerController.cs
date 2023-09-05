using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour {
    public UISlider healthBar;
    public UISlider manaBar;
    public UISlider staminaBar;
    public BasePlayer player;

    // Start is called before the first frame update
    void Start()
    {
        SetStartingValues();
    }

    // Update is called once per frame
    void Update() {
        UpdateHP();
        UpdateMP();
        UpdateStamina();
    }

    private void SetStartingValues() {
        healthBar.SetMaxValue(player.maxHP);
        healthBar.SetValue(player.HP);
        manaBar.SetMaxValue(player.maxMP);
        manaBar.SetValue(player.MP);
        staminaBar.SetMaxValue(100);
        staminaBar.SetValue(player.stamina);
    }

    private void UpdateHP() {
        healthBar.SetMaxValue(player.maxHP);
        healthBar.SetValue(player.HP);
    }

    private void UpdateMP() {
        manaBar.SetMaxValue(player.maxMP);
        manaBar.SetValue(player.MP);
    }

    private void UpdateStamina() {
        staminaBar.SetValue(player.stamina);
    }
}
