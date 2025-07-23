using Unity.VisualScripting;
using UnityEngine;

public class ShootMove : MonoBehaviour
{
    [SerializeField]
    public float BulletSpeed;

    [SerializeField]
    public string TargetTag;

    [SerializeField]
    public bool PlayerShoot;

    public float lifetime = 3f;

    public System.Action onDestroy;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        Move();
        OutOfBounds();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(TargetTag))
        {
            Destroy(gameObject);
        }
    }

    void Move()
    {
        transform.position += new Vector3(0f, BulletSpeed * Time.deltaTime, 0f);
    }

    // Passou dos limites do jogo.
    void OutOfBounds()
    {
        if (transform.position.y > 12f || transform.position.y < -12f)
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        if (onDestroy != null)
            onDestroy.Invoke();
    }
}
