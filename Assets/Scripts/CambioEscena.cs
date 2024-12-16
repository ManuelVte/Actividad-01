using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    [Header("Animator:")]
    [SerializeField] private Animator animaciones;
    //[SerializeField] private GameObject AnimacionObjeto;
    [SerializeField] private GameObject esteActivador;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Invoke("iniciarFadeIn", 0);
        //Invoke("iniciarFadeOut", 0);
    }

    public void iniciarFadeIn()
    {
        animaciones.Play("FadeIn");
    }

    public void iniciarFadeOut()
    {
        animaciones.Play("FadeOut");
    }

    void OnTriggerEnter(Collider other)
    {// Comprobar si el jugador colisiona con la llave.
        if (other.transform.tag == "Player")
        {
            Invoke("iniciarFadeOut", 0);
            esteActivador.SetActive(false);
            Invoke(nameof(cambiarEscena), 2);
        }
    }

    void cambiarEscena()
    {
        //SceneManager.LoadScene("Maze02");
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
