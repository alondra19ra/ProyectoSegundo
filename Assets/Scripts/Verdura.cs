using UnityEngine;

public class Verdura : MonoBehaviour
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

    #region Colisiones
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            control.Aumentar(Puntos);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.GetComponent<Zanahoria>())
        {
            Zanahoria otraVerdura = collision.gameObject.GetComponent<Zanahoria>();
            Verdura resultado = this + otraVerdura;
            this.Puntos = resultado.puntos;
        }
    }
    #endregion
}
