using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;

    [SerializeField]
    public float movespeed = 10f;

    public PlayerInputActions playerControls;

    [SerializeField]
    private InputActionReference pointerPosition;

    Vector2 moveDirection = Vector2.zero;
    private Vector2 pointerInput;

    [SerializeField]
    private weaponParent weaponparent;

    private InputAction move;
    private InputAction attack;

    private void Awake()
    {
        playerControls = new PlayerInputActions();

        weaponparent = GetComponentInChildren<weaponParent>();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        attack = playerControls.Player.Fire;
        attack.Enable();
        attack.performed += Fire;
    }

    private void OnDisable()
    {
        move.Disable();
        attack.Disable();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();

        pointerInput = GetPointerInput();
        weaponparent.PointerPosition = pointerInput;
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(moveDirection.x * movespeed, moveDirection.y * movespeed);
    }

    private void Fire(InputAction.CallbackContext context)
    {
        weaponparent.Attack();
        //Debug.Log("piuu");
    }

    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
