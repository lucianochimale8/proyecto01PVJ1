using UnityEngine;

public class LateralMovement : IMovementStrategy
{
    public void Move(Transform transform, float speed)
    {
        float direccion = Input.GetAxis("Horizontal");
        transform.Translate(direccion * speed * Time.deltaTime, 0, 0);
    }
}
