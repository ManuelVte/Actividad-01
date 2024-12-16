using UnityEngine;

public class LlaveMovimiento : MonoBehaviour
{
    // Mover la llave girando sobre sí misma.
    [Header("Giro de la llave")]
    public float velocidadRotacion = 90f;   // Velocidad de rotación en grados por segundo

    // Mover la llave arriba y abajo.
    private Vector3 posicionInicial;        // Para guardar la posición inicial hasta donde volver.
    [Header("Subida y Bajada")]
    public float velocidad = 1f;            // La velocidad del movimiento a la que irá la llave.
    public float amplitud = 0.25f;          // La distancia que se moverá arriba y abajo.



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // El movimiento circular sobre "Y" deberá ser forward, porque el objeto importado estaba tumbado.
        transform.Rotate(Vector3.fwd, velocidadRotacion * Time.deltaTime);

        // Movimiento de arriba a abajo usando Mathf.Sin.
        float desplazamiento = Mathf.Sin(Time.time * velocidad) * amplitud;
        transform.position = new Vector3(posicionInicial.x, posicionInicial.y + desplazamiento, posicionInicial.z);
    }
}
