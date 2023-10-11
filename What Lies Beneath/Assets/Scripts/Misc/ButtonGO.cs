using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonGO : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void LoadNewLevel()
    {
        int escenaPosNeg = Random.Range(0, 2);
        int escenaNum = Random.Range(0, 3);
        if(Variables.contEventos == 0)
        {
            Variables.contNivel++;
        }

        if(Variables.contEventos == 5 && Variables.auxEventoPasado == 0)
        {
            SceneManager.LoadScene(Variables.arrNeg[(Variables.contNivel - 1), escenaNum]);
            escenaPosNeg = 1;
        }

        else if(Variables.contEventos == 5 && Variables.auxEventoPasado == 1)
        {
            Variables.contEventos++;
            SceneManager.LoadScene("Descanso");
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
