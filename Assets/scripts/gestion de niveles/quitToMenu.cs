using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * cuando el jugador pulsa escape, se va al menu principal
 */

public class quitToMenu : MonoBehaviour
{
    private stats _stats;

    private void Start()
    {
        _stats = GetComponent<stats>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey("escape"))
        {
            _stats.sethp(_stats.vidas);
            _stats.setPoints(0);
            SceneManager.LoadScene("Scenes/menu/Start Menu");
        }
    }
}