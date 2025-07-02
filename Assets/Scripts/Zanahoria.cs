using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Zanahoria : Movimientos
{
    #region Variables
    [SerializeField] private GameObject objetivo;
    [SerializeField] private GameManager control;
    [SerializeField] private float velocidad;
    [SerializeField] private float puntos;

    public float Puntos { get { return puntos; } set { puntos = value; } }
    #endregion

    #region Métodos Unity
    private void Start()
    {
        SetObjetive(objetivo);
    }

    private void Update()
    {
        Mover(velocidad);
    }
    #endregion

    #region Métodos Heredados
    protected override void Mover(float Velocidad)
    {
        base.Mover(Velocidad);
    }

    protected override void SetObjetive(GameObject NewObjetivo)
    {
        base.SetObjetive(NewObjetivo);
    }
    #endregion

    #region Métodos Públicos
    public void LLenar(GameObject NewObjetivo)
    {
        SetObjetive(NewObjetivo);
    }
    #endregion

    #region Operadores
    public static Zanahoria operator +(Zanahoria a, Verdura b)
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

        if (collision.gameObject.GetComponent<Verdura>())
        {
            Verdura otraVerdura = collision.gameObject.GetComponent<Verdura>();
            Zanahoria resultado = this + otraVerdura;
            this.Puntos = resultado.puntos;
        }
    }
    #endregion
}
