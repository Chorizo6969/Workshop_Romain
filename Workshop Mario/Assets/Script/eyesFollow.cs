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
        // Déterminez la direction du point cible par rapport à la position actuelle de l'objet
        Vector2 directionToTarget = player.transform.position - this.transform.position;

        // Calculez l'angle en radians à partir de la direction vers le point cible
        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
        angle -= 90;

        // Créez une rotation à partir de l'angle calculé
        Quaternion newRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Appliquez la nouvelle rotation à l'objet
        this.transform.rotation = newRotation;
    }
}
