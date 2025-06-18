using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private CambiarEscena escena;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private PuntosControl puntosControl;
    [SerializeField] private float puntosFinales = 50f;
    #endregion

    #region Metodos
    void Start()
    {
        Time.timeScale = 1; 
    }

    void Update()
    {
        VerificarVictoria();
    }
    #endregion

    #region Puntos y Condición de Victoria
    void VerificarVictoria()
    {
        if (puntosFinales <= puntosControl.puntitos)
        {
            escena.Escena("Ganaste");
        }
    }

    public void Aumentar(float puntitos)
    {
        if (puntosControl != null)
        {
            puntosControl.MasPuntos(puntitos);
        }
    }
    #endregion

    #region Control del Juego
    public void Pausar()
    {
        Time.timeScale = 0;
    }

    public void Continuar()
    {
        Time.timeScale = 1;
    }
    #endregion

    #region Audio
    public void Mute(Image image)
    {
        if (audioSource.mute == true)
        {
            image.color = Color.white;
            audioSource.mute = false;
        }
        else
        {
            image.color = Color.red;
            audioSource.mute = true;
        }
    }
    #endregion
}
