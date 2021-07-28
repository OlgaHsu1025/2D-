using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoyUserCtrl2D : MonoBehaviour
   
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
        float speed =1;
        if (!isSpeedup) speed *= 0.5f;

        character.Move(speed, isJump);
        isJump = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            transform.GetComponent<BoyUserCtrl2D>().enabled = false;
            Collider2D[] colliders = transform.GetComponentsInChildren<Collider2D>();
            for (int i = 0; i < colliders.Length; i++) { colliders[i].isTrigger = true; };
        }
    }
}
