using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * almacena el ultimo nivel que se ha jugado, es basicamente parta ene l apartado del menu de niveles, poder volver a jugar sin necesidad de volver al menu
 */
public class lastPlayeableLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private static String level;
    public bool isLevel = false;

    void Start()
    {
        if (isLevel) level = SceneManager.GetActiveScene().path;
    }

    public void goLastLevel()
    {
        SceneManager.LoadScene(level);
    }
}
