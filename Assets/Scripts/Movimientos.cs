using UnityEngine;

public abstract class Movimientos : MonoBehaviour
{
    protected GameObject Objetivo;
    protected virtual void Mover(float Velocidad)
    {
        transform.position = Vector2.MoveTowards(transform.position, Objetivo.transform.position, Velocidad * Time.deltaTime);
    }
    protected virtual void SetObjetive(GameObject NewObjetivo)
    {
        Objetivo = NewObjetivo;
    }
}
