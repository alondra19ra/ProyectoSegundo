using UnityEngine;

public abstract class Movimientos : MonoBehaviour
{
    #region Variables Protegidas
    protected GameObject Objetivo;
    #endregion

    #region Métodos Protegidos
    protected virtual void Mover(float Velocidad)
    {
        transform.position = Vector2.MoveTowards(transform.position, Objetivo.transform.position, Velocidad * Time.deltaTime);
    }

    protected virtual void SetObjetive(GameObject NewObjetivo)
    {
        Objetivo = NewObjetivo;
    }
    #endregion
}

