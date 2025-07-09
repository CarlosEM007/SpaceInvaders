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

    private bool Morto = false;

    /* Principal */

    private void Start()
    {
        DeathAnimation.GetComponent<Animator>();
        AlienBody.GetComponent<Rigidbody2D>();
        AlienCollider.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Move();
        Down();
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

    private void SetMorto()
    {
        AlienCollider.isTrigger = true;
        Morto = true;
        DeathAnimation.SetBool("Morto", true);
        AlienBody.gravityScale = 1f;

        Controller.Increment();
        Controller.AlienDecrease();
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
}
