using UnityEngine;

public class JugadorControl : MonoBehaviour
{
    #region Private
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private GameObject HenoDestroyer;

    private int direccionX = 0;
    private int direccionY = 1;
    #endregion

    #region Métodos 
    void Update()
    {
        MoverJugador();
        ActualizarHenoDestroyer();
    }
    #endregion

    #region Movimiento
    void MoverJugador()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * velocidad * Time.deltaTime;
            direccionX = 0;
            direccionY = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * velocidad * Time.deltaTime;
            direccionX = 0;
            direccionY = -1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * velocidad * Time.deltaTime;
            direccionX = -1;
            direccionY = 0;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * velocidad * Time.deltaTime;
            direccionX = 1;
            direccionY = 0;
        }
    }
    #endregion

    #region HenoDestroyer
    void ActualizarHenoDestroyer()
    {
        if (HenoDestroyer != null)
        {
            HenoDestroyer.transform.localPosition = new Vector2(2f * direccionX, 2f * direccionY);
        }
    }
    #endregion
}
