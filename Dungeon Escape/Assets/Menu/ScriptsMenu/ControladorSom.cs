using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorSom : MonoBehaviour
{
    [SerializeField] private AudioSource fundo;
    public void Volume(float valor)
    {
        fundo.volume = valor;
    }
}
