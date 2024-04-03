using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    [SerializeField] private float vitese;
    [SerializeField] private float jetPackVitesse;
    [SerializeField] private float forceSaut;
    //[SerializeField] private float ;

    [SerializeField] private GameObject attaqueProjectile;
    [SerializeField] private GameObject bouclierObjet;
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject jetPackFlamme;

    [SerializeField] private ParticleSystem particuleFeu;

    [SerializeField] private bool peutSauter;

    [SerializeField] private bool appuiSurBoutonSaut;

    [SerializeField] private bool peutUtiliserJetpack;
    
    private Vector2 stickGaucheAxeX;

    [SerializeField] private bool utilisejetpack;

    [SerializeField] private float carbu;
    [SerializeField] private float maxCarbu;

    private void Start()
    {
        bouclierObjet = Instantiate(bouclierObjet);
        bouclierObjet.SetActive(false);
        bouclierObjet.transform.position = spawner.transform.position;
        bouclierObjet.transform.parent = spawner.transform;

        particuleFeu.Stop();
    }

    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        stickGaucheAxeX = callbackContext.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            appuiSurBoutonSaut = true;
            if (peutSauter)
            {
                Sauter();
            }
            else if (!peutSauter)
            {
                peutUtiliserJetpack = true;
            }

        }

        if (callbackContext.canceled)
        {
            appuiSurBoutonSaut = false;
            utilisejetpack = false;
        }
    }

    public void OnShield(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            bouclierObjet.SetActive(true);
        }
        if (callbackContext.canceled)
        {
            bouclierObjet.SetActive(false);
        }
    }

    public void OnAttaque(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            GameObject newProjectile = Instantiate(attaqueProjectile);
            newProjectile.transform.position = spawner.transform.position;
            newProjectile.transform.rotation = spawner.transform.rotation;
        }
    }

    private void FixedUpdate()
    {
        if (stickGaucheAxeX.x != 0)
        {
            if (stickGaucheAxeX.x > 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                transform.Translate(Time.deltaTime * vitese * new Vector2(stickGaucheAxeX.x, 0));
            }
            else if (stickGaucheAxeX.x < 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                transform.Translate(Time.deltaTime * vitese * new Vector2(-stickGaucheAxeX.x, 0));
            }
        }


        if (peutSauter && appuiSurBoutonSaut)
        {
            Sauter();
        }

        if (peutUtiliserJetpack && carbu > 0)
        {
            if (appuiSurBoutonSaut)
            {
                jetPackFlamme.SetActive(true);
                carbu -= Time.deltaTime * 50;
                if (carbu < 0) { carbu = 0; }
                utilisejetpack = true;
                GetComponent<Rigidbody2D>().AddForce(Vector2.up*15);
                particuleFeu.Play();
            }

            if (utilisejetpack && carbu > 0)
            {
                Gamepad.current.SetMotorSpeeds(0.2f, 0.2f);
            }
            else /*if (!appuiSurBoutonSaut && !estEnCollision)*/
            {
                jetPackFlamme.SetActive(false);
                particuleFeu.Stop();
                Gamepad.current.SetMotorSpeeds(0, 0);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        peutSauter = true;
        peutUtiliserJetpack = false;
        if (Gamepad.current != null)
        {
            StartCoroutine(Vibration(0.2f, 0.125f));
        }
        jetPackFlamme.SetActive(false);
        particuleFeu.Stop();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        carbu += Time.deltaTime * 10;
        if (carbu > maxCarbu)
        {
            carbu = maxCarbu;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
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

    IEnumerator EteindreFlamme()
    {
        yield return new WaitForSeconds(1);
        jetPackFlamme.SetActive(false);
    }

    
}