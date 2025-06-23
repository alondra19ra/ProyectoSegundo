using UnityEngine;

public class JugadorControl : MonoBehaviour
{
    #region Private
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private GameObject HenoDestroyer;

    [SerializeField] private int direccionX;
    [SerializeField] private int direccionY;
    private Animator animator;
    #endregion

    #region Métodos 
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        MoverJugador();
        ActualizarHenoDestroyer();
    }
    #endregion

    #region Movimiento
    void MoverJugador()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveY = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
        }

        Vector3 movimiento = new Vector3(moveX, moveY, 0f).normalized;

        transform.position += movimiento * velocidad * Time.deltaTime;

        if (movimiento.magnitude > 0)
        {
            direccionX = (int)moveX;
            direccionY = (int)moveY;
        }

        animator.SetFloat("DirX", direccionX);
        animator.SetFloat("DirY", direccionY);
        animator.SetBool("Caminando", movimiento.magnitude > 0);
    }
    #endregion

    #region HenoDestroyer
    void ActualizarHenoDestroyer()
    {
        if (HenoDestroyer != null)
        {
            HenoDestroyer.transform.localPosition = new Vector2(2f * direccionX, 2f * direccionY);
        }
    }
    #endregion
}