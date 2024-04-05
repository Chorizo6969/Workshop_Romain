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
            ScreenShake.Instance.Shake(20, 0.1f);
            if (_life.Currenthealth > 25)
            {
                _life.take_damages(25);
                collision.transform.position = _newSpawn;
            }
            else
            {
                _life.take_damages(25);
                Destroy(collision.gameObject);
            }
        }
    }
}
