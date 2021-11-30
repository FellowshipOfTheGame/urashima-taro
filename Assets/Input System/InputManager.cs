using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    private string device;
    private PlayerInput playerInput;
    private Vector2 moveDirection = Vector2.zero;
    private Vector2 changeWeapon;
    private Vector2 rotation;
    private bool isRunning = false;
    private bool lanterna = false;
    private bool shoot = false;
    private bool reload = false;
    private bool interagir = false;
    private int arma;
    private bool trocaArma = false;
    private bool trocaArmaVector = false;

    private static InputManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Mais de 1 InputManager");
        }
        instance = this;

        playerInput = GetComponent<PlayerInput>();
    }

    public static InputManager GetInstance()
    {
        return instance;
    }

    public string CurrentControlScheme()
    {
        return playerInput.currentControlScheme;
    }

    public void ChangeActionMap(string actionMap)
    {
        // padrao: "Player_base"

        // dialogo: "Dialogo"

        playerInput.SwitchCurrentActionMap(actionMap);
    }

    //
    // ActionMap: Player_base
    //
    
    
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
    }

    public void OnRotation(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            device = context.control.device.displayName;
            rotation = context.ReadValue<Vector2>();
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isRunning = true;
        }
        else if (context.canceled)
        {
            isRunning = false;
        }
    }

    public void OnLanterna(InputAction.CallbackContext context)
    {
        if(context.performed)
            lanterna = !lanterna;
    }

    public void OnChangeWeapon(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            trocaArmaVector = true;

            

            changeWeapon = context.ReadValue<Vector2>();
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            shoot = true;
        }
        else if (context.canceled)
        {
            shoot = false;
        }
    }

    public void OnReload(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            reload = true;
        }
        else if (context.canceled)
        {
            reload = false;
        }
    }

    public void OnArma1(InputAction.CallbackContext context)
    {
        trocaArma = true;
        arma = 0;
    }

    public void OnArma2(InputAction.CallbackContext context)
    {
        trocaArma = true;
        arma = 1;
    }

    public void OnArma3(InputAction.CallbackContext context)
    {
        trocaArma = true;
        arma = 2;
    }

    public void OnArma4(InputAction.CallbackContext context)
    {
        trocaArma = true;
        arma = 3;
    }

    public void OnInteragir(InputAction.CallbackContext context)
    {
        if (context.performed)
            interagir = true;
    }

    public string GetDevice()
    {
        return device;
    }

    public Vector2 GetMoveDirection()
    {
        return moveDirection;
    }

    public Vector2 GetRotation()
    {
        return rotation;
    }

    public Vector2 GetChangeWeapon()
    {
        return changeWeapon;
    }

    public bool GetRunPressed()
    {
        bool result = isRunning;
        return result;
    }

    public bool GetLanternaPressed()
    {
        bool result = lanterna;
        return result;
    }

    public bool GetShootPressed()
    {
        bool result = shoot;
        shoot = false;
        return result;
    }

    public bool GetReloadPressed()
    {
        bool result = reload;
        reload = false;
        return result;
    }

    public bool GetTroca()
    {
        bool result = trocaArma;
        trocaArma = false;
        return result;
    }

    public bool GetTrocaVector()
    {
        bool result = trocaArmaVector;
        trocaArmaVector = false;
        return result;
    }

    public int GetArma()
    {
        return arma;
    }

    public bool GetInteragir()
    {
        bool result = interagir;
        interagir = false;
        return result;
    }

    //
    // ActionMap: Dialogo
    //

    private Vector2 pointed;
    private bool avancarDialogo;
    private Vector2 moveDialogo;
    private Vector2 mousePos;

    public void OnPoint(InputAction.CallbackContext context)
    {
        pointed = context.ReadValue<Vector2>();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
            avancarDialogo = true;
    }

    public void OnAvancarDialogo(InputAction.CallbackContext context)
    {
        if (context.performed)
            avancarDialogo = true;
    }

    public void OnMoveDialogo(InputAction.CallbackContext context)
    {
        moveDialogo = context.ReadValue<Vector2>();
    }

    public void OnMousePos(InputAction.CallbackContext context)
    {
        if(context.performed)
            mousePos = context.ReadValue<Vector2>();
    }

    public Vector2 GetPoint()
    {
        return pointed;
    }

    public Vector2 GetMoveDialogo()
    {
        return moveDialogo;
    }

    public bool GetAvancarDialogo()
    {
        bool result = avancarDialogo;
        avancarDialogo = false;
        return result;
    }

    public Vector2 GetMousePos()
    {
        Vector2 result = mousePos;
        mousePos = new Vector2(0, 0);
        return result;
    }
}
