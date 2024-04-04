using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cheatCode : MonoBehaviour
{
    private Move playerMove;
    public bool Cheat1;
    public bool Cheat2;
    public bool Cheat3;
    public bool Cheat4;
    public bool Cheat5;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<Move>();
    }

    public void OnCheatCode1(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            Cheat1 = true;
        }
        else if (callbackContext.canceled)
        {
            Cheat1 = false;
        }
    }
    public void OnCheatCode2(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            Cheat2 = true;
        }
        else if (callbackContext.canceled)
        {
            Cheat2 = false;
        }
    }
    public void OnCheatCode3(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            Cheat3 = true;
        }
        else if (callbackContext.canceled)
        {
            Cheat3 = false;
        }
    }
    public void OnCheatCode4(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            Cheat4 = true;
        }
        else if (callbackContext.canceled)
        {
            Cheat4 = false;
        }
    }
    public void OnCheatCode5(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            Cheat5 = true;
        }
        else if (callbackContext.canceled)
        {
            Cheat5 = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Cheat1 && Cheat2 && Cheat3 && Cheat4 && Cheat5)
        {
            playerMove.maxCarbu = 10000;
            playerMove.carbu = 10000;
        }
    }
}
