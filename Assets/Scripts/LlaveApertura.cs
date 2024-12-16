using UnityEngine;

public class LlaveApertura : MonoBehaviour
{
    [Header("Activacion Apertura")]
    [SerializeField] private GameObject esteActivador;
    [SerializeField] private GameObject AnimacionObjeto;
    [SerializeField] private AudioSource SonidoAperturaPuerta;

    void OnTriggerEnter(Collider other)
    {
        // Comprobar si el jugador colisiona con la llave.
        if (other.transform.tag == "Player") 
        {
            // Realizar la animación de rotación de 90º que se ha creado con anterioridad en el Animator.
            AnimacionObjeto.GetComponent<Animator>().Play("AbrirPuerta");
            // Reproducir el sonido de apertura de puerta.
            SonidoAperturaPuerta.Play();
            // Poner el objeto que ha activado, en este caso la llave, a False para que desaparezca. (Disable object).
            esteActivador.SetActive(false);
        }
    }
}