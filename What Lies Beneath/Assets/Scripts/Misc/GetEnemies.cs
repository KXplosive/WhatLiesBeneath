using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Battle")
        {
            Variables.contEnemigos = 4;
        }
        else if (scene.name == "Horda")
        {
            Variables.contEnemigos = 12;
        }
        else if (scene.name == "Elite")
        {
            Variables.contEnemigos = 2;
        }
        else
        {
            Variables.contEnemigos = 1;
        }
    }
}
