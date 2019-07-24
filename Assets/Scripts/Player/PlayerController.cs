using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement movement;
    private PlayerAttack playerAttack;
    private PhoneUI phoneControl;
    private PlayerShooting playerShoot;

    private InputManager controls;

    private void Awake()
    {
        controls = new InputManager();

        controls.Gameplay.Melee.performed += inp => playerAttack.Attack();
        controls.Gameplay.Dash.performed += inp => movement.Dash();
        controls.Gameplay.Shoot.performed += inp => playerShoot.Shoot();
        controls.Gameplay.Pause.performed += inp => phoneControl.ShowPhone();


        controls.Gameplay.Movement.performed += inp => movement.playerMove = inp.ReadValue<Vector2>();
        controls.Gameplay.Movement.canceled += inp => movement.playerMove = Vector2.zero;

    }

    void Start()
    {
        movement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();
        playerShoot = GetComponent<PlayerShooting>();
        phoneControl = GetComponent<PhoneUI>();
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
