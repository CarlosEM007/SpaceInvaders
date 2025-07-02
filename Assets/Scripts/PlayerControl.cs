using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    /* Principal */

    [SerializeField]
    private float Speed = 5f;

    [SerializeField]
    private GameObject Bullet;

    private Rigidbody2D PlayerBody;

    /* Principal */

    void Start()
    {
        PlayerBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
        Shoot();
    }

    /* -- Events -- */

    /* -- Methods -- */

    void MovePlayer()
    {
        Vector2 Horizontal = new Vector2(Input.GetAxis("Horizontal"), 0f);
        PlayerBody.MovePosition(PlayerBody.position + Horizontal * Speed * Time.deltaTime);
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Space"))
        {
            GameObject BulletClone = Instantiate(Bullet, transform.position, Quaternion.identity);
        }
    }
}
