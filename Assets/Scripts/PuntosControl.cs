using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Importante para usar TextMeshProUGUI

public class PuntosControl : MonoBehaviour
{
    #region Variables
    public float puntitos = 0f;
    private TextMeshProUGUI textoTMP;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        textoTMP = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        ActualizarTexto();
    }
    #endregion

    #region M�todos P�blicos
    public void MasPuntos(float puntos)
    {
        puntitos += puntos;
        ActualizarTexto();
    }
    #endregion

    #region M�todos Privados
    private void ActualizarTexto()
    {
        if (textoTMP != null)
        {
            textoTMP.text = "PUNTOS: " + puntitos;
        }
    }
    #endregion
}
