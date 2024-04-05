using UnityEngine;

public class killFuze : MonoBehaviour
{
    [SerializeField] private GameObject fuze;
    [SerializeField] private Move can_Fly;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        can_Fly.isflying = true;
        Destroy(fuze, 1);
    }
}
