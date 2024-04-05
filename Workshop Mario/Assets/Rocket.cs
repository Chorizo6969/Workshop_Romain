using DG.Tweening;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    [SerializeField] private Move player;
    public float Max_SP95;
    public float CurrentSP95;
    public Slider slider; // Fait le lien entre mes valeurs et le slider
    public float DOTweenSpeed;
    public Ease functionName;
    public Slider slider_latence;
    public GameObject self;

    public void Start()
    {
        Max_SP95 = player.maxCarbu;
        CurrentSP95 = Max_SP95;
        slider.maxValue = Max_SP95;
    }

    public void Update() //Fonction qui soustraie x pv a la vie du joueur
    {
        if (player.carbu == player.maxCarbu)
        {
            self.SetActive(false);
        }
        else
        {
            self.SetActive(true);
            CurrentSP95 = player.carbu;
            slider.DOValue(CurrentSP95, DOTweenSpeed).SetEase(functionName);
        }
    }
}
