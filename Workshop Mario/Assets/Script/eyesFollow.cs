using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyesFollow : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = FindAnyObjectByType<Move>().gameObject;
    }

    private void Update()
    {
        // D�terminez la direction du point cible par rapport � la position actuelle de l'objet
        Vector2 directionToTarget = player.transform.position - this.transform.position;

        // Calculez l'angle en radians � partir de la direction vers le point cible
        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
        angle -= 90;

        // Cr�ez une rotation � partir de l'angle calcul�
        Quaternion newRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Appliquez la nouvelle rotation � l'objet
        this.transform.rotation = newRotation;
    }
}
