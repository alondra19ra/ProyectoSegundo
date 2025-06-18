using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointControl : MonoBehaviour
{
    [SerializeField] private GameObject NexPoint;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemigo")
        {
            //collision.gameObject.GetComponent<EnemyControl>().LLenar(NexPoint);
        }
        if (collision.gameObject.tag == "Sandia")
        {
            //collision.gameObject.GetComponent<Sandia>().LLenar(NexPoint);
        }
    }
}
