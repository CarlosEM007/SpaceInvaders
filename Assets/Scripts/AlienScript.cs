using Unity.VisualScripting;
using UnityEngine;

public class AlienScript : MonoBehaviour
{
    /* Atributos */

    [SerializeField]
    AlienControllerScript Controller;

    [SerializeField]
    private Rigidbody2D AlienBody;

    [SerializeField]
    public float Speed = 2;

    public float DownDistance = 5;

    /* Principal */

    private void Start()
    {
        AlienBody = GetComponent<Rigidbody2D>();
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
            Destroy(gameObject);
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

    private void Down()
    {
        if (!Controller.CanInvert)
        {
            Vector2 Vertical = new Vector2(0f, DownDistance);

            AlienBody.MovePosition(Vertical);
        }
    }

    void Move()
    {
        Vector2 Horizontal = new Vector2(Speed, 0f);

        AlienBody.MovePosition(AlienBody.position + Horizontal * Time.deltaTime);    
    }
}
