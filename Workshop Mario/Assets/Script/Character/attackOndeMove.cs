using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackOndeMove : MonoBehaviour
{
    [SerializeField] private int vitesse;

    private void Start()
    {
        Destroy(gameObject, 0.4f);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.up * Time.deltaTime * vitesse);
    }
}
