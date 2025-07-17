using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float Speed = 5f;

    [SerializeField]
    private GameObject Bullet;

    [SerializeField]
    public GameController Controller;

    [SerializeField]
    public LifeScript LifeScript;

    private Rigidbody2D PlayerBody;

    public int Life;

    void Start()
    {
        PlayerBody = GetComponent<Rigidbody2D>();
        Life = 3;
    }

    void Update()
    {
        MovePlayer();
        Shoot();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AlienShoot") || collision.gameObject.CompareTag("Alien"))
        {
            if (Life > 0)
            {
                Life--;
                LifeScript.AtualizarVidas(Life);
            }
            else
            {
                Controller.CanRestart = true;
                Destroy(gameObject);
            }
        }
    }

    void MovePlayer()
    {
        Vector2 Horizontal = new Vector2(Input.GetAxis("Horizontal"), 0f);
        PlayerBody.MovePosition(PlayerBody.position + (Horizontal * Speed * Time.deltaTime));
    }

    void Shoot()
    {
        GameObject BulletClone;

        if (Input.GetButtonDown("Shoot"))
        {
            BulletClone = Instantiate(Bullet, transform.position, Quaternion.identity);
        }
    }
}
