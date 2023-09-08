using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TemperatureUI : MonoBehaviour
{

    public TMP_Text displayText;
    public PlayerController playerController;
    [SerializeField] private int temperature = 35;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateTemperature();
    }

    public void UpdateTemperature() {
        temperature = playerController.player.temperature;
        displayText.text = temperature.ToString();
    }
}
