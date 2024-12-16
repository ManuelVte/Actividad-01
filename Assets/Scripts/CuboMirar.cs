using UnityEngine;

public class CuboMirar : MonoBehaviour
{
    [Header("Seleccionar Jugador:")]
    public Transform jugador;       // Referencia al Transform del jugador

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //jugador = GameObject.FindGameObjectWithTag("JUGADOR").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(jugador);
    }
}
