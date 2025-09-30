using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private List<ICommand> commands;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        commands = new List<ICommand>();
    }

    // Update is called once per frame
    void Update()
    {
        commands.Clear();
        float horizontalInput = Input.GetAxis("Horizontal");
        commands.Add(new MoveCommand(playerMovement,horizontalInput));

        if (Input.GetKey(KeyCode.Space))
        {
            commands.Add(new AcelerateMoveCommand(playerMovement,horizontalInput));
        }

        foreach (var command in commands)
        {
            command.Execute();
        }
    }
}
