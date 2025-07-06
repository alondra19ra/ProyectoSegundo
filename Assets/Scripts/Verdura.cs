using UnityEngine;

public class Verdura : MonoBehaviour, IRecolectable
{
    #region Variables
    [SerializeField] private float puntos;
    [SerializeField] private GameManager control;

    public float Puntos { get { return puntos; } set { puntos = value; } }
    #endregion

    #region Operadores
    public static Verdura operator +(Verdura a, Zanahoria b)
    {
        a.Puntos = a.Puntos + 10;
        return a;
    }
    #endregion

    #region Recolectar
    public void Recolectar(GameObject recolector)
    {
        try
        {
            if (control != null)
            {
                control.Aumentar(Puntos);
            }
            else
            {
                Debug.LogWarning("GameManager no asignado en el objeto Verdura");
            }

            Destroy(this.gameObject);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error al recolectar verdura: " + ex.Message);
        }
    }
    #endregion

    #region Colisiones
    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            if (collision.CompareTag("Player"))
            {
                Recolectar(collision.gameObject);
            }

            Zanahoria otraVerdura = collision.GetComponent<Zanahoria>();
            if (otraVerdura != null)
            {
                Verdura resultado = this + otraVerdura;
                this.Puntos = resultado.puntos;
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error en Verdura.OnTriggerEnter2D: " + ex.Message);
        }
    }
    #endregion
}
