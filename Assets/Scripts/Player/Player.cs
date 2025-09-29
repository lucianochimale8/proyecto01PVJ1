using UnityEngine;

public class Player
{
    private float velocidad;
    private float aceleracion;

    public Player(float velocidad, float aceleracion)
    {
        this.velocidad = velocidad;
        this.aceleracion = aceleracion;
    }

    public float Velocidad { get { return velocidad; } set { velocidad = value; }}
    public float Aceleracion { get { return aceleracion; } set { aceleracion = value; }}
}
