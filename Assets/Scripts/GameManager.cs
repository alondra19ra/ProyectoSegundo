using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Variables
    [Header("Referencias")]
    [SerializeField] private CambiarEscena escena;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private PuntosControl puntosControl;
    [SerializeField] private CamaraControl camara; 

    [Header("Jugador")]
    [SerializeField] private GameObject jugadorPrefab;
    [SerializeField] private Vector3 posicionInicial = Vector3.zero;

    [Header("Condiciones de victoria")]
    [SerializeField] private float puntosFinales = 50f;
    #endregion

    #region Métodos Unity
    void Start()
    {
        GameObject nuevoJugador = Instantiate(jugadorPrefab, posicionInicial, Quaternion.identity);

        if (camara != null)
        {
            camara.Jugador = nuevoJugador;
        }
        else
        {
            Debug.LogWarning("No se asignó la cámara en el GameManager.");
        }

        Time.timeScale = 1;
    }

    void Update()
    {
        VerificarVictoria();
    }
    #endregion

    #region Lógica del juego
    void VerificarVictoria()
    {
        if (puntosFinales <= puntosControl.puntitos)
        {
            escena.Escena("Ganaste");
        }
    }
    public void Aumentar(float puntitos)
    {
        try
        {
            if (puntosControl != null)
            {
                puntosControl.MasPuntos(puntitos);
            }
            else
            {
                Debug.LogWarning("PuntosControl no está asignado en el GameManager");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error al intentar aumentar los puntos: " + ex.Message);
        }
    }


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
        if (audioSource.mute)
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