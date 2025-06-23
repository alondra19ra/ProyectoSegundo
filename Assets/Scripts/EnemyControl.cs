using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyControl : Movimientos
{
    [SerializeField] private GameObject objetivo;
    [SerializeField] private GameManager control;
    [SerializeField] private CambiarEscena escena;
    [SerializeField] private float velocidad;

    private void Start()
    {
        SetObjetive(objetivo);
    }

    private void Update()
    {
        Mover(velocidad);
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
