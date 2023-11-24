using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameUI : MonoBehaviour
{
    public TMP_Text displayText;
    public HeroStateMachine heroStateMachine;
    private string characterName = "???";

    // Start is called before the first frame update
    void Start() {
        heroStateMachine = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroStateMachine>();
        characterName = heroStateMachine.character.nombre;
        SetCharacterName(characterName);
    }

    public void SetCharacterName(string charName) {
        displayText.text = charName;
    }
}
