//using Unity.Android.Gradle.Manifest;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;
using static UnityEngine.UI.GridLayoutGroup;
//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;


[RequireComponent(typeof(CharacterController))]
public class JugadorMovimiento : MonoBehaviour
{

    public Camera camaraJugador;
    public float gravedad = 20f;    //10f
    public float VelocidadCaminando = 5f;
    public float VelocidadCorriendo = 10f;
    public float velocidadAgachado = 2.5f;

    private float caminar = 5f;
    private float correr = 10f;
    public float saltar = 5f;       //7f

    public float agacharse = 1f;
    public float alzarse = 2f;

    private Vector3 moverDireccion = Vector3.zero;
    private CharacterController ControladorPersonaje;

    private bool moviendose = true;

    public float sensivilidad = 2f;          // Sensibilidad del ratón
    public float limiteVisionVertical = 65f;   // Límite superior e inferior para mirar arriba/abajo

    private float rotacionX = 0;              // Rotación en el eje X (mirar arriba/abajo)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ControladorPersonaje = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        camaraJugador = Camera.main;        // Asignar la Cámara fuera del código, pero aquí se tomará por defecto, por si se olvida.

        caminar = VelocidadCaminando;
        correr = VelocidadCorriendo;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = moviendose ? (isRunning ? correr : caminar) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = moviendose ? (isRunning ? correr : caminar) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moverDireccion.y;
        moverDireccion = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && moviendose && ControladorPersonaje.isGrounded)
        {
            //velocidadY = Mathf.Sqrt(alturaSalto * -2f * gravedad); // Fórmula para el salto
            //moverDireccion = Mathf.Sqrt(saltar * -2f * gravedad); // Fórmula para el salto
            moverDireccion.y = saltar;
        }
        else
        {
            moverDireccion.y = movementDirectionY;
        }

        if (!ControladorPersonaje.isGrounded)
        {
            moverDireccion.y -= gravedad * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftControl) && moviendose)
        {
            ControladorPersonaje.height = agacharse;
            caminar = velocidadAgachado;
            correr = velocidadAgachado;
        }
        else
        {
            ControladorPersonaje.height = alzarse;
            caminar = VelocidadCaminando;
            correr = VelocidadCorriendo;
        }

        ControladorPersonaje.Move(moverDireccion * Time.deltaTime);

        // Movimiento de la cámara (mirar arriba y abajo)
        rotacionX -= Input.GetAxis("Mouse Y") * sensivilidad;
        rotacionX = Mathf.Clamp(rotacionX, -limiteVisionVertical, limiteVisionVertical);
        camaraJugador.transform.localRotation = Quaternion.Euler(rotacionX, 0, 0);

        // Rotación del personaje (mirar hacia los lados)
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * sensivilidad);
    }
}