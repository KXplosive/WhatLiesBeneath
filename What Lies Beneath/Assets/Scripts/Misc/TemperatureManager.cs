using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureManager : MonoBehaviour
{
    public float environmentTemperature;
    public HeroStateMachine player;

    // Update is called once per frame
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroStateMachine>();
    }
    void Update()
    {
        
        if (player.character.temperature > environmentTemperature)
        {
            player.character.temperature -= 0.2f * Time.deltaTime;
        } else if (player.character.temperature < environmentTemperature)
        {
            player.character.temperature += 0.2f * Time.deltaTime;
        }
    }
}
