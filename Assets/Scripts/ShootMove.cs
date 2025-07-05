using UnityEngine;

public class ShootMove : MonoBehaviour
{
    public float BulletSpeed = 5f;

    public int BulletLimit;

    void Update()
    {
        Move();
        OutOfBounds();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Alien"))
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
        if (transform.position.y > 12f)
        {
            Destroy(gameObject);
        }
    }
}
