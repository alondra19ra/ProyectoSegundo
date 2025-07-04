using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControl : MonoBehaviour
{
    #region Variables
    [Header("Objetive Variable")]
    public GameObject Jugador;

    [Header("Posiciones en X")]
    public float minPositionX;
    public float maxPositionX;
    public float currentPositionX;

    [Header("Posiciones en Y")]
    public float minPositionY;
    public float maxPositionY;
    public float currentPositionY;

    public float timeToGetOBjetive;
    #endregion

    #region Variables Privadas
    private Vector3 Velocity = new Vector3(0, 0, 0);
    private Vector3 realObjetive;
    #endregion

    #region M�todos Unity
    private void Update()
    {
        currentPositionX = Math.Clamp(Jugador.transform.position.x, minPositionX, maxPositionX);
        currentPositionY = Math.Clamp(Jugador.transform.position.y, minPositionY, maxPositionY);
        realObjetive = new Vector3(currentPositionX, currentPositionY, -10);
        transform.position = Vector3.SmoothDamp(transform.position, realObjetive, ref Velocity, timeToGetOBjetive);
    }
    #endregion
}
