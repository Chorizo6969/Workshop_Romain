using Unity.VisualScripting;
using UnityEngine;

public class Ennemy: MonoBehaviour
{
    [SerializeField] private Life _life;
    public Transform _targetPosition;
    public Transform _secondTarget;
    public int speed = 5;
    private SpriteRenderer _spriteRenderer;

    private Transform target;

    void Start()
    {
        target = _targetPosition;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.flipX = false;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            if (target == _targetPosition)
            {
                _spriteRenderer.flipX = true;
                target = _secondTarget;
            }
            else
            {
                _spriteRenderer.flipX = false;
                target = _targetPosition;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            _life.take_damages(20);
        }
    }
}
