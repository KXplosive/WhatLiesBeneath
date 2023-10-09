using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{

    public static string[,] arrNeg = new string[6, 3] { { "Battle", "Battle", "Battle" }
        , { "Battle", "Battle", "Horda" }
        , { "Battle", "Horda", "Elite" }
        , { "Horda", "Horda", "Elite" }
        , { "Horda", "Elite", "Elite" }
        , { "Elite", "Elite", "Elite" } };

    public static string[,] arrPos = new string[6, 3] { { "Descanso", "Descanso", "Cofre" }
        , { "Descanso", "Descanso", "Cofre" }
        , { "Descanso", "Cofre", "Tienda" }
        , { "Descanso", "Cofre", "Tienda" }
        , { "Descanso", "Cofre", "Tienda" }
        , { "Descanso", "Descanso", "Tienda" } };

    public static int contPosNeg = 2;
    public static int contNivel = 0;
    public static int contEventos = 0;
    public static int auxEventoPasado;
    public static int contEnemigos = 0;

}
