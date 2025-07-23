using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AlienScript : MonoBehaviour
{
    /* Atributos */

    [SerializeField]
    AlienControllerScript Controller;

    [SerializeField]
    public float Speed = 2;

    [SerializeField]
    public float DownDistance = -2;

    [SerializeField]
    private Animator DeathAnimation;

    [SerializeField]
    private Rigidbody2D AlienBody;

    [SerializeField]
    private BoxCollider2D AlienCollider;

    [SerializeField]
    public GameObject Bullet;

    [SerializeField]
    public LayerMask Layer;

    private bool Morto = false; // Está Vivo

    private bool AlienAfrente;

    bool PodeAtirar = true; // Valida se pode atirar

    /* Principal */

    private void Start()
    {
        DeathAnimation.GetComponent<Animator>();
        AlienBody.GetComponent<Rigidbody2D>();
        AlienCollider.GetComponent<BoxCollider2D>();

        AlienAfrente = FreeDown();

        if (AlienAfrente)
        {
            StartCoroutine(Cooldown());
        }
    }

    void Update()
    {
        Move();
        Down();
        Shoot();
    }

    /* -- Events -- */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shoot"))
        {
            if (!Morto)
            {
                SetMorto();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ParedeInvisivel"))
        {
            if (Controller.CanInvert)
            {
                Controller.AlienSpeed *= -1;
                Controller.CanInvert = false;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ParedeInvisivel"))
        {
            Controller.CanInvert = true;
        }
    }

    /* -- Methods -- */
    private void SetMorto()
    {
        AlienCollider.isTrigger = true;
        Morto = true;
        DeathAnimation.SetBool("Morto", true);
        AlienBody.gravityScale = 1f;

        Controller.Increment();
        Controller.AlienDecrease();
    }

    private void Down()
    {
        if (!Controller.CanInvert)
        {
            Vector3 Vertical = new Vector3(0f, DownDistance, 0f);

            transform.position += Vertical;
        }
    }

    void Move()
    {
        if (!Morto)
        {
            Vector3 Horizontal = new Vector3(Controller.AlienSpeed, 0f, 0f);

            transform.position += Horizontal * Time.deltaTime * Speed;
        }
        else
        {
            if(gameObject.transform.position.y < -10f)
            {
                Destroy(gameObject);
            }
        }
    }

    void Shoot()
    {
        if (!Morto && !AlienAfrente && PodeAtirar)
        {
            GameObject CloneBullet = Instantiate(Bullet, transform.position, Quaternion.identity);
            StartCoroutine(Cooldown());
        }
        else if (AlienAfrente)
        {
            AlienAfrente = FreeDown();
        }
    }

    private bool FreeDown()
    {
        float Distancia = 1f;

        Vector3 Position = transform.position;

        Position.y -= 0.6f;

        RaycastHit2D Hit = Physics2D.Raycast(Position, Vector2.down, Distancia, Layer);
        return Hit.collider;
    }

    IEnumerator Cooldown()
    {
        PodeAtirar = false;
        float tempo = Random.Range(3f, 5f);
        yield return new WaitForSeconds(tempo);
        PodeAtirar = true;
    }

    public void EndGame()
    {
        Speed = 0;
    }
}
