using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour //Script qui gère la vie du joueur, les degats comme les soins
{
    public int Max_healthlife = 200;
    public int Currenthealth;
    public Slider slider; // Fait le lien entre mes valeurs et le slider
    public float DOTweenSpeed;
    public Ease functionName;
    public Slider slider_latence;
    public GameObject Player;
    [SerializeField] private Animator _animator;
    [SerializeField] private Move movement;

    public void Start()
    {
        Currenthealth = Max_healthlife;
        slider.maxValue = Max_healthlife;
    }
    IEnumerator Damages_Delay()
    {
        Death();
        yield return new WaitForSeconds(0.7f);
        slider_latence.DOValue(Currenthealth, DOTweenSpeed).SetEase(functionName);
    }

    public void take_damages(int damages) //Fonction qui soustraie x pv a la vie du joueur
    {
        Currenthealth -= damages;
        slider.DOValue(Currenthealth, DOTweenSpeed).SetEase(functionName);
        StartCoroutine(Damages_Delay());
    }

    public void Death()
    {
        if (Currenthealth <= 0)
        {
            Destroy(Player);
        }
    }
}
