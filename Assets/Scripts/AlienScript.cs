using Unity.VisualScripting;
using UnityEngine;

public class AlienScript : MonoBehaviour
{
    /* Atributos */

    [SerializeField]
    AlienControllerScript Controller;

    [SerializeField]
    public float Speed = 2;

    public float DownDistance = 5;

    /* Principal */

    private void Start()
    {
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
            Vector3 Vertical = new Vector3(0f, DownDistance, 0f);

            transform.position += Vertical;
        }
    }

    void Move()
    {
        Vector3 Horizontal = new Vector3(Controller.AlienSpeed, 0f, 0f);

        transform.position += Horizontal * Time.deltaTime * Speed;
    }
}
