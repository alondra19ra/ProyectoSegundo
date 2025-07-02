using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : Movimientos
{
    public GameObject objetivo;
    public GameManager control;
    public CambiarEscena escena;
    public float Velocidad;

    private void Start()
    {
        SetObjetive(objetivo);
    }

    private void Update()
    {
        Mover(Velocidad);
    }

    protected override void Mover(float Velocidad)
    {
        base.Mover(Velocidad);
    }

    protected override void SetObjetive(GameObject NewObjetivo)
    {
        base.SetObjetive(NewObjetivo);
    }
    public void LLenar(GameObject NewObjetivo)
    {
        SetObjetive(NewObjetivo);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            escena.Escena("Perdiste");
        }
    }

}
