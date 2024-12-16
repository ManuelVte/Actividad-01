using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlPrincipal : MonoBehaviour
{

    public void btnInicio()
    {
        //yield return new WaitForSeconds(2);
        Invoke(nameof(cambiarEscena), 1);
        //SceneManager.LoadScene("Maze01");
    }

    public void btnSalir()
    {
        Invoke(nameof(salir), 1);
        //Application.Quit();
    }

    void cambiarEscena()
    {
        //SceneManager.LoadScene("Maze01");
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void salir()
    {
        Application.Quit();
    }
}
