using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : Movimientos
{
    #region Variables
    [SerializeField] private GameObject objetivo;
    [SerializeField] private GameManager control;
    [SerializeField] private CambiarEscena escena;
    [SerializeField] private float velocidad;
    #endregion

    #region M�todos Unity
    private void Start()
    {
        SetObjetive(objetivo);
    }

    private void Update()
    {
        Mover(velocidad);
    }
    #endregion

    #region M�todos Heredados
    protected override void Mover(float Velocidad)
    {
        base.Mover(Velocidad);
    }

    protected override void SetObjetive(GameObject NewObjetivo)
    {
        base.SetObjetive(NewObjetivo);
    }
    #endregion

    #region M�todos P�blicos
    public void LLenar(GameObject NewObjetivo)
    {
        SetObjetive(NewObjetivo);
    }
    #endregion

    #region Colisiones
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            escena.Escena("Perdiste");
        }
    }
    #endregion
}
