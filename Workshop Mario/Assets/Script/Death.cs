using UnityEngine;
using Cinemachine;

public class Death : MonoBehaviour
{
    [SerializeField]
    private Vector3 _newSpawn;
    [SerializeField]
    private Life _life;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.position = _newSpawn;
            ScreenShake.Instance.Shake(10f, 0.1f);
            _life.take_damages(25);
        }
    }
}
