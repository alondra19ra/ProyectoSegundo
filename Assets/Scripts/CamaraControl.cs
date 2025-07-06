using UnityEngine;

public class CamaraControl : MonoBehaviour
{
    #region Variables Públicas
    [Header("Objetivo: Jugador (asignado desde GameManager)")]
    public GameObject Jugador;

    [Header("Límites en X")]
    public float minPositionX;
    public float maxPositionX;
    public float currentPositionX;

    [Header("Límites en Y")]
    public float minPositionY;
    public float maxPositionY;
    public float currentPositionY;

    [Header("Velocidad de seguimiento")]
    public float timeToGetObjetive = 0.2f;
    #endregion

    #region Variables Privadas
    private Vector3 velocity = Vector3.zero;
    private Vector3 realObjetive;
    #endregion

    #region Métodos Unity

    private void Update()
    {
        if (Jugador == null)
        {
            return;
        }

        currentPositionX = Mathf.Clamp(Jugador.transform.position.x, minPositionX, maxPositionX);
        currentPositionY = Mathf.Clamp(Jugador.transform.position.y, minPositionY, maxPositionY);

        realObjetive = new Vector3(currentPositionX, currentPositionY, -10f);
        transform.position = Vector3.SmoothDamp(transform.position, realObjetive, ref velocity, timeToGetObjetive);
    }

    #endregion
}
