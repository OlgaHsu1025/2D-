using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUserCtrl2D : MonoBehaviour
   
{
    Character2D character;
    GaneContro2D inputActions;
    bool isJump = false;
    bool isSpeedup = false;

    private void Awake()
    {
        inputActions = new GaneContro2D();
        inputActions.Player.Jump.performed += ctx => { isJump = true;
        };
        inputActions.Player.SpeedUP.performed += ctx => { isSpeedup = !isSpeedup; };
    }
    private void OnEnable()
    {
        inputActions.Player.Enable();
    }
    private void OnDisable()
    {
        inputActions.Player.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 axisCtrl = inputActions.Player.Movement.ReadValue<Vector2>();
        float speed = axisCtrl.x;
        if (!isSpeedup) speed *= 0.5f;

        character.Move(speed, isJump);
        isJump = false;
    }
}
