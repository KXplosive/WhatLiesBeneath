using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TemperatureUI : MonoBehaviour
{

    public TMP_Text displayText;
    public HeroStateMachine heroStateMachine;
    private float currentTemperature;

    // Start is called before the first frame update
    void Start() {
        heroStateMachine = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroStateMachine>();
        currentTemperature = Mathf.Round(heroStateMachine.character.temperature);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTemperature();
    }

    public void UpdateTemperature() {
        currentTemperature = Mathf.Round(heroStateMachine.character.temperature);
        displayText.text = currentTemperature.ToString();
    }
}
