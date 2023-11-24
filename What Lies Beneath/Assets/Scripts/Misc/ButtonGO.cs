using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonGO : MonoBehaviour
{
    public GameObject player;
    public GameObject[] players;
    public GameObject aaa;
    public GameObject fondo1;
    public GameObject fondo2;
    // Start is called before the first frame update
    void Start()
    {
        if (Variables.contNivel == 2)
        {
            fondo1.SetActive(false);
            fondo2.SetActive(true);
        }
    }

    public void LoadNewLevel()
    {
        int escenaPosNeg = Random.Range(0, 2);
        int escenaNum = Random.Range(0, 3);
        //instanciar gameobject player

        

        if (Variables.contEventos == 0 && Variables.contNivel == 0)
        {
            aaa = Instantiate(player);
            DontDestroyOnLoad(aaa);
        }

        if (Variables.contEventos == 0)
        {
            Variables.contNivel++;
            players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject p in players)
            {
                p.GetComponent<HeroStateMachine>().character.currentHP = p.GetComponent<HeroStateMachine>().character.baseHP;
            }
            //asignar currenthp = basehp
            //es regenerar la vida
        }

        if(Variables.contEventos == 5 && Variables.auxEventoPasado == 0)
        {
            SceneManager.LoadScene(Variables.arrNeg[(Variables.contNivel - 1), escenaNum]);
            escenaPosNeg = 1;
        }

        else if(Variables.contEventos == 5 && Variables.auxEventoPasado == 1)
        {
            Variables.contEventos++;
            SceneManager.LoadScene("Rest");
            escenaPosNeg = 0;
        }

        else if(Variables.contEventos == 6)
        {
            SceneManager.LoadScene("Boss");
            Variables.contEventos = 0;
            Variables.contPosNeg = 2;
        }
        
        else if(Variables.contPosNeg == 2)
        {
            SceneManager.LoadScene(Variables.arrNeg[(Variables.contNivel - 1),escenaNum]);
            Variables.contPosNeg--;
            Variables.contEventos++;
            escenaPosNeg = 1;
        }
        
        else if(Variables.contPosNeg == 0)
        {
            SceneManager.LoadScene(Variables.arrPos[(Variables.contNivel - 1), escenaNum]);
            Variables.contPosNeg++;
            Variables.contEventos++;
            escenaPosNeg = 0;
        }

        else
        {
            if(escenaPosNeg == 0)
            {
                SceneManager.LoadScene(Variables.arrPos[(Variables.contNivel - 1), escenaNum]);
                Variables.contPosNeg++;
                Variables.contEventos++;
            }
            else
            {
                SceneManager.LoadScene(Variables.arrNeg[(Variables.contNivel - 1), escenaNum]);
                Variables.contPosNeg--;
                Variables.contEventos++;
            }
        }
        if (Variables.contNivel == 3)
        {
            SceneManager.LoadScene("Win");
        }

        Debug.Log("Positivo o Negativo: " + escenaPosNeg + "\n" +
                  "Eventos: " + Variables.contEventos + "\n" +
                  "Cont Posi o Nega: " + Variables.contPosNeg + "\n" +
                  "Nivel: " + Variables.contNivel + "\n" +
                  "Pasado: " + Variables.auxEventoPasado + "\n");
        Variables.auxEventoPasado = escenaPosNeg;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
