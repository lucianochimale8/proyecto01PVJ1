using UnityEngine;

public class AceletareMovement : IMovementStrategy
{

    public void Move(Transform transform, Player player, float direccion)
    {
        float movement = direccion * (player.Aceleracion * player.Aceleracion) * Time.deltaTime;

        transform.Translate(movement * Time.deltaTime, 0, 0);
    }
}
