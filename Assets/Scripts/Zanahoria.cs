using UnityEngine;

public class Zanahoria : Movimientos, IRecolectable
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

    public void Recolectar(GameObject recolector)
    {
        try
        {
            if (control != null)
            {
                control.Aumentar(Puntos);
            }
            else
            {
                Debug.LogWarning("GameManager no asignado en el objeto Zanahoria ");
            }

            Destroy(this.gameObject);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error al recolectar zanahoria: " + ex.Message);
        }
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
        try
        {
            if (collision.CompareTag("Player"))
            {
                Recolectar(collision.gameObject);
            }

            Verdura otraVerdura = collision.GetComponent<Verdura>();
            if (otraVerdura != null)
            {
                Zanahoria resultado = this + otraVerdura;
                this.Puntos = resultado.puntos;
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error en Zanahoria.OnTriggerEnter2D: " + ex.Message);
        }
    }
    #endregion
}
