using UnityEngine;

/*
 * cuando el jugador pulsa escape, la aplicacion se cierra
 */

public class quit : MonoBehaviour
{
    void FixedUpdate()
    {
        if (Input.GetKey("escape"))   Application.Quit();
    }
}