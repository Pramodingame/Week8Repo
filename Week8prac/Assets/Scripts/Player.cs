using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private int moveSpeed;
    
    private Vector3 movementVector;

    private PlayerActions playerActions;
    private InputAction moveAction;
    [SerializeField] private bool player2Controls = false;

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    // Awake is called once the instance is created
    private void Awake()
    {
        playerActions = new PlayerActions();
        if(player2Controls)
        {
            moveAction = playerActions.playerControls.move2;
        }
        else
        {
            moveAction = playerActions.playerControls.move1;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // Works as the z component will just be 0 (see line 740 of Unity's Vector2.cs).
        movementVector = moveAction.ReadValue<Vector2>();
        // Swap y and z components
        movementVector.z = movementVector.y;
        movementVector.y = 0.0f;

        transform.Translate(movementVector * moveSpeed * Time.deltaTime);
    }
}
