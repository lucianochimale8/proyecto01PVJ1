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
    /// representa la estrategia de movimiento
    /// </summary>
    
    private IMovementStrategy strategy;
    private Player player;
    #endregion

    #region Ciclo de vida del script
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fuerzaPorAplicar = new Vector3(0,0,5f);
        tiempoDesdeUltimaFuerza = 0f;
        intervaloTiempo = 2f;

        player = new Player(5f, 5f);
        SetStrategy(new AceletareMovement());
    }
    void Update()
    {
        MovePlayer();
            
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
    #endregion
    #region Logica de la estrategia
    public void SetStrategy(IMovementStrategy strategy)
    {
        this.strategy = strategy;
    }
    public void MovePlayer()
    {
        strategy.Move(transform, player);
    }
    #endregion
}
