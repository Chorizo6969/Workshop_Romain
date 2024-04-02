using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    [SerializeField] private float vitese;
    [SerializeField] private float forceSaut;
    //[SerializeField] private float ;

    [SerializeField] private GameObject attaqueProjectile;

    [SerializeField] private bool peutSauter;

    [SerializeField] private bool appuiSurBoutonSaut;

    private Vector2 stickGaucheAxeX;

    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        stickGaucheAxeX = callbackContext.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started && peutSauter)
        {
            appuiSurBoutonSaut = true;
            Sauter();
        }

        if (callbackContext.canceled)
        {
            appuiSurBoutonSaut = false;
        }
    }

    public void OnAttaque(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            GameObject newProjectile = Instantiate(attaqueProjectile);
            newProjectile.transform.position = transform.position + new Vector3(0.5f, 0, 0);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Time.deltaTime * vitese * new Vector2(stickGaucheAxeX.x, 0));
        if (peutSauter && appuiSurBoutonSaut)
        {
            Sauter();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        peutSauter = true;
        if (Gamepad.current != null)
        {
            StartCoroutine(Vibration(0.2f, 0.125f));
        }
    }

    public void Sauter()
    {
        peutSauter = false;
        GetComponent<Rigidbody2D>().AddForce(forceSaut * Vector2.up);
    }

    IEnumerator Vibration(float temps, float speedValue)
    {
        Gamepad.current.SetMotorSpeeds(speedValue, speedValue);
        yield return new WaitForSeconds(temps);
        Gamepad.current.SetMotorSpeeds(0, 0);
    }
}