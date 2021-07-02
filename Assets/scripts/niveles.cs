using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * para agilizar el acceso a los niveles en el apartado de menu de los niveles
 */
public class niveles : MonoBehaviour
{
    public void nivel0()
    {
        SceneManager.LoadScene("Scenes/menu/levels/0");
    }
    public void nivel1()
    {
        SceneManager.LoadScene("Scenes/menu/levels/1");
    }
    public void nivel2()
    {
        SceneManager.LoadScene("Scenes/menu/levels/2");
    }
    public void nivel3()
    {
        SceneManager.LoadScene("Scenes/menu/levels/3");
    }
    public void nivel4()
    {
        SceneManager.LoadScene("Scenes/menu/levels/4");
    }
    public void nivel5()
    {
        SceneManager.LoadScene("Scenes/menu/levels/5");
    }

    public void nivel6()
    {
        SceneManager.LoadScene("Scenes/menu/levels/6");
    }
    public void atras()
    {
        SceneManager.LoadScene("Scenes/menu/jugar");

    }
   
}