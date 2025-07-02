using UnityEngine;

public class JugadorControl : MonoBehaviour
{
    #region Variables SerializeField
    [Header("Velocidad del jugador")]
    [SerializeField] private float velocidad = 5f;

    [Header("HenoDestroyer")]
    [SerializeField] private GameObject HenoDestroyer;
    #endregion

    #region Variables Privadas
    private Rigidbody2D rb;
    private Animator animator;

    private Vector2 input;
    private Vector2 lastDirection = Vector2.down;
    #endregion

    #region Métodos Unity
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        LeerEntrada();
        ActualizarAnimacion();
        ActualizarHenoDestroyer();
    }

    void FixedUpdate()
    {
        MoverJugador();
    }
    #endregion

    #region Métodos de Movimiento
    void LeerEntrada()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W)) moveY = 1f;
        if (Input.GetKey(KeyCode.S)) moveY = -1f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;

        input = new Vector2(moveX, moveY).normalized;

        if (input != Vector2.zero)
        {
            lastDirection = input;
        }
    }

    void MoverJugador()
    {
        rb.linearVelocity = input * velocidad;
    }
    #endregion

    #region Métodos de Animación
    void ActualizarAnimacion()
    {
        animator.SetFloat("Horizontal", input.x);
        animator.SetFloat("Vertical", input.y);
        animator.SetFloat("LastHorizontal", lastDirection.x);
        animator.SetFloat("LastVertical", lastDirection.y);
        animator.SetBool("IsMoving", input.magnitude > 0);
    }
    #endregion

    #region Métodos de HenoDestroyer
    void ActualizarHenoDestroyer()
    {
        if (HenoDestroyer != null)
        {
            Vector2 direccion = lastDirection.normalized;
            HenoDestroyer.transform.localPosition = new Vector2(2f * direccion.x, 2f * direccion.y);
        }
    }
    #endregion
}
