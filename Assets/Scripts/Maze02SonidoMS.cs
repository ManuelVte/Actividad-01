using UnityEngine;
using UnityEngine.Timeline;

public class Maze02SonidoMS : MonoBehaviour
{
    //set these in the inspector!
    [Header("Altavoces Maestro-Esclavos")]
    [SerializeField] private AudioSource mastro;
    [SerializeField] private AudioSource esclavo01;
    [SerializeField] private AudioSource esclavo02;
    [SerializeField] private AudioSource esclavo03;
    [SerializeField] private AudioSource esclavo04;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

// Update is called once per frame
    void Update()
    {
        esclavo01.timeSamples = mastro.timeSamples;
        esclavo02.timeSamples = mastro.timeSamples;
        esclavo03.timeSamples = mastro.timeSamples;
        esclavo04.timeSamples = mastro.timeSamples;
    }
}
