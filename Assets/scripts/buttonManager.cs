
using UnityEngine;
using UnityEngine.SceneManagement;
    /*
     *para hacer mas agil los cambios de nivel
     */
    
public class buttonManager : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Scenes/menu/jugar");
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Scenes/menu/Tutorial");
    }
    public void Ranking()
    {
        SceneManager.LoadScene(2);
    }
    public void Atras()
    {
        SceneManager.LoadScene(0);
    }

    public void menu()
    { 
        SceneManager.LoadScene("Scenes/menu/Start Menu");
    }
    
    public void Game()
    {
        SceneManager.LoadScene("Scenes/niveles/nivel0Transicion");
    }

    public void niveles()
    {
        SceneManager.LoadScene("Scenes/menu/niveles");  
    }

    public void lastLevel()
    {
        
    }
}
