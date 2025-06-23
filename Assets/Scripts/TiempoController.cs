using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TiempoControler : MonoBehaviour
{
    #region Variables
    TextMeshProUGUI textito;
    [SerializeField] private CambiarEscena escena; 
    private float tiempo = 120f;

    private float minutos = 0f;
    private float segundos = 0f;
    #endregion

    #region Métodos Unity

    private void Awake()
    {
        textito = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        tiempo -= Time.deltaTime;

        if (tiempo <= 0)
        {
            escena.Escena("Perdiste");
        }

        MostrarTiempo(tiempo);
    }
    #endregion

    #region Métodos de Funcionalidad
    private void MostrarTiempo(float tiempoRestante)
    {
        minutos = Mathf.Floor(tiempoRestante / 60);
        segundos = Mathf.Floor(tiempoRestante % 60);
        textito.text = minutos + ":" + segundos;
    }
    #endregion
}
