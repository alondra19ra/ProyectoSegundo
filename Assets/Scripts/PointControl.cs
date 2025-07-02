using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointControl : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject NexPoint;
    #endregion

    #region Colisiones
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemigo")
        {
            collision.gameObject.GetComponent<EnemyControl>().LLenar(NexPoint);
        }

        if (collision.gameObject.tag == "Zanahoria")
        {
            collision.gameObject.GetComponent<Zanahoria>().LLenar(NexPoint);
        }
    }
    #endregion
}