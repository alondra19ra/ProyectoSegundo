using UnityEngine;

public class HenoDestroyer : MonoBehaviour
{
    #region Variables
    [SerializeField] GameObject HenoCube;     
    [SerializeField] GameObject CrearHeno;   
    #endregion

    #region Métodos Unity
    void Update()
    {
        RevisarEspacio();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HenoCube")
        {
            HenoCube = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HenoCube")
        {
            HenoCube = null;
        }
    }
    #endregion

    #region Heno Destruir y Crear
    void RevisarEspacio()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (HenoCube != null)
            {
                Destroy(HenoCube); 
            }
            else
            {
                Instantiate(CrearHeno, transform.position, transform.rotation); 
            }
        }
    }
    #endregion
}
