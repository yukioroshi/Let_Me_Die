using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    private Vector2 moveInput;
    private Animator animator;

    
    public float movespeed;

    public PlayerInputActions playerControls;

    [SerializeField]
    private InputActionReference pointerPosition;


    private Vector2 pointerInput;

    [SerializeField]
    private weaponParent weaponparent;


    private InputAction attack;



    private void Awake()
    {
        playerControls = new PlayerInputActions();

        weaponparent = GetComponentInChildren<weaponParent>();
    }

    private void OnEnable()
    {

        attack = playerControls.Player.Fire;
        attack.Enable();
        attack.performed += Fire;
    }

    private void OnDisable()
    {
        
        attack.Disable();
    }


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        pointerInput = GetPointerInput();
        weaponparent.PointerPosition = pointerInput;
    }

    private void FixedUpdate()
    {
        
        rb2d.velocity = moveInput * movespeed;
    }


    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking", true);

        if (context.canceled)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.x);

        }

        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
        //Debug.Log("moving");
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

    public void SpeedUpgrade()
    {
        movespeed += 1;
        MoneyManager.score -= 30;
    }
}
