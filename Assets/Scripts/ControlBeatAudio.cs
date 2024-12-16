using UnityEngine;

public class ControlBeatAudio : MonoBehaviour
{
    // Referencia al Componente de Audio con el audio seleccionado.
    [SerializeField] private AudioSource recursoAudio;
    // Intervalo de tiempo en segundos entre actualizaciones del análisis de audio. (0.1f = 0.1seg.)
    [SerializeField] private float actualizarPaso = 0.1f;
    // Número de muestras del audio que se analizarán en cada actualización. (Más alto = más precisión, pero más recursos.)
    [SerializeField] private int longitudDatosMuestra = 1024;

    // Tiempo acumulado desde la última actualización del análisis.
    private float actualActualizacionTiempo = 0f;

    // Almacena el sonido procesado hasta el momento. (Usado para mostrar el número de la Intensidad Emisiva, o para cambiar valores en sí.)
    [SerializeField] private float clipSonoridad;
    // Datos obtenidos de las muestras de audio de AudioSource.
    private float[] clipDatosMuestra;

    //public GameObject sprite;

    // Referencia al material emisivo que vamos a cambiar.
    [SerializeField] private Material materialEmisivo;
    //[SerializeField] private Renderer objetoACambiar;
    // Variable que almacena un color que aplicaremos al material emisivo de ser necesario. 
    private Color color;
    [SerializeField] private float intensidad = 0.1f;

    //public Texture Texture1;
    //public Texture Texture2;
    // Factor de Escala para ajustar la intensidad del audio y su impacto visual.
    [SerializeField] private float factorEscala = 1;
    // Límites Mínimos y Máximos para evitar unos valores muy bajos o altos. (Intensidad, tamaños...)
    [SerializeField] private float escalaMinima = 0.1f;
    [SerializeField] private float escalaMaxima = 10;

    // Nada más iniciar el objeto, crear la array de la Longitud de Muestra de Datos.
    private void Awake()
    {
        clipDatosMuestra = new float[longitudDatosMuestra];
    }

    private void Start()
    {
        //materialEmisivo = objetoACambiar.GetComponent<Renderer>().material;
        color = materialEmisivo.GetColor("_EmissionColor");
    }

    private void Update()
    {
        //miMaterial.mainTexture = Texture1;
        
        // Va acumulando el tiempo desde la última actualización para hacer el cálculo idóneo con el Delta Time.
        actualActualizacionTiempo += Time.deltaTime;
        // Si el tiempo que ha pasado en la Actual supera al de la Actualización...
        if (actualActualizacionTiempo > actualizarPaso)
        {
            // Poner la Actual a 0 de nuevo.
            actualActualizacionTiempo = 0f;
            // Obtener datos del clip actual desde el punto de reproducción.
            recursoAudio.clip.GetData(clipDatosMuestra, recursoAudio.timeSamples);
            // Reinicia la sonoridad (Intensidad o Tamaños).
            clipSonoridad = 0f;
            // Calcula la Intensidad con la media de los valores absolutos de las muestras.
            foreach (var sample in clipDatosMuestra)
            {
                clipSonoridad += Mathf.Abs(sample);     // Operación de Valores Absolutos.
            }
            clipSonoridad /= longitudDatosMuestra;

            // Ajusta la Intensidad con el Factor Escala y los Límites.
            clipSonoridad *= factorEscala;
            clipSonoridad = Mathf.Clamp(clipSonoridad, escalaMinima, escalaMaxima);
            //sprite.transform.localScale = new Vector3(clipLoudness, clipLoudness, clipLoudness);

            // Cambia el Color de emisión del material y su Intensidad. (Evitar que cambie el color u obtener el del objeto Rojo/Azul).
            //color = Color.red;
            //color = materialEmisivo.GetColor("_EmissionColor");
            materialEmisivo.SetColor("_EmissionColor", color * clipSonoridad);
            //materialEmisivo.SetColor("_EmissionColor", color * intensidad);
        }
    }
}
