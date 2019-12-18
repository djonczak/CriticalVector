using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerMeleeAttack playerAttack;
   // private PhoneUI phoneControl;
    private PlayerRangeAttack playerShoot;
    private PlayerDash playerDash;

    private PlayerInput controls;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerMeleeAttack>();
        playerShoot = GetComponent<PlayerRangeAttack>();
        // phoneControl = GetComponent<PhoneUI>();
        playerDash = GetComponent<PlayerDash>();

        //<----------- Set Controls ----------->
        controls = new PlayerInput();

        controls.Player.MeleeAttack.performed += inp => playerAttack.Attack();
        controls.Player.Dash.performed += inp => playerDash.ActivateDash();
        controls.Player.RangeAttack.performed += inp => playerShoot.Shoot();
        //controls.Player.OpenPhone.performed += inp => phoneControl.ShowPhone();


        controls.Player.Movement.performed += inp => playerMovement.playerMove = inp.ReadValue<Vector2>();
        controls.Player.Movement.canceled += inp => playerMovement.playerMove = Vector2.zero;

    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }
}
