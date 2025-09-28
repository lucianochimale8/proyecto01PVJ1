using UnityEngine;
/// <summary>
/// Permite el comportamiento del movimiento del jugador
/// </summary>

public class PlayerMovement : MonoBehaviour
{
    #region Atributos
    /// <summary>
    /// Fuerza utilizada para aplicar el movimiento
    /// </summary>
    private Vector3 fuerzaPorAplicar;
    /// <summary>
    /// Representa el tiempo que ha transcurrido 
    /// desde la ultima aplicacion de fuerzas
    /// </summary>
    private float tiempoDesdeUltimaFuerza;
    /// <summary>
    /// Indica cada cuanto tiempo debe aplicarse
    /// la fuerza
    /// </summary>
    private float intervaloTiempo;
    /// <summary>
    /// indica la velocidad aplicada en el movimiento lateral
    /// </summary>
    private float velocidadLateral;
    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fuerzaPorAplicar = new Vector3(0,0,5f);
        tiempoDesdeUltimaFuerza = 0f;
        intervaloTiempo = 2f;
        velocidadLateral = 2f;
    }
    void Update()
    {
        float direccion = Input.GetAxis("Horizontal");
        transform.Translate(direccion*velocidadLateral*Time.deltaTime,0,0);
    }
    private void FixedUpdate()
    {
        tiempoDesdeUltimaFuerza += Time.deltaTime;
        if (tiempoDesdeUltimaFuerza >= intervaloTiempo)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(fuerzaPorAplicar, ForceMode.Impulse);
            tiempoDesdeUltimaFuerza = 0f;
        }
    }
}
