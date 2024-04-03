using UnityEngine;

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
            _life.take_damages(25);
        }
    }
}
