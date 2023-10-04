using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.Tilemaps;

public class UIController : MonoBehaviour {
    public UISlider healthBar;
    public UISlider manaBar;
    public UISlider staminaBar;
    public HeroStateMachine heroStateMachine;

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
        healthBar.SetMaxValue(heroStateMachine.character.baseHP);
        healthBar.SetValue(heroStateMachine.character.currentHP);
        manaBar.SetMaxValue(heroStateMachine.character.baseMP);
        manaBar.SetValue(heroStateMachine.character.currentMP);
        staminaBar.SetMaxValue(heroStateMachine.character.baseST);
        staminaBar.SetValue(heroStateMachine.character.currentST);
    }

    private void UpdateHP() {
        healthBar.SetMaxValue(heroStateMachine.character.baseHP);
        healthBar.SetValue(heroStateMachine.character.currentHP);
    }

    private void UpdateMP() {
        manaBar.SetMaxValue(heroStateMachine.character.baseMP);
        manaBar.SetValue(heroStateMachine.character.currentMP);
    }

    private void UpdateStamina() {
        staminaBar.SetMaxValue(heroStateMachine.character.baseST);
        staminaBar.SetValue(heroStateMachine.character.currentST);
    }
}
