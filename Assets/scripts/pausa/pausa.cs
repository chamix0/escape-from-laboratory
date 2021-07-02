using UnityEngine;

/*
 *controla la pausa poniendo la escala de tiempo a 0
 */
public class pausa : MonoBehaviour
{
    // Start is called before the first frame update
    private bool pau;
    private GameObject cuadro;

    private void Start()
    {
        pau = false;
        cuadro = GameObject.FindGameObjectWithTag("pause");
        cuadro.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        pause();
    }

    void pause()
        //si se presiona la p, el tiempo se pausa y por lo tanto el juego
    {
        if (Input.GetKeyDown(KeyCode.P) && !pau)
        {
            Time.timeScale = 0;
            pau = true;
            cuadro.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.P) && pau)
        {
            Time.timeScale = 1;
            pau = false;
            cuadro.SetActive(false);
        }
    }
}