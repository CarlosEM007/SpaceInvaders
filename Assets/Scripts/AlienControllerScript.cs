using UnityEngine;

public class AlienControllerScript : MonoBehaviour
{
    [SerializeField]
    public float AlienSpeed = 2f;

    [SerializeField]
    public bool CanInvert = true;

    [SerializeField]
    public float SpeedIncrement = 0.2f;

    [SerializeField]
    public int AliensCount;

    [SerializeField]
    public GameController Controller;


    void Start()
    {
        AlienSpeed = 2f;
        AliensCount = GameObject.FindGameObjectsWithTag("Alien").Length;
    }

    public void Increment()
    {
        if(AlienSpeed > 0)
        {
            AlienSpeed += SpeedIncrement;
        }
        else
        {
            AlienSpeed -= SpeedIncrement;
        }
    }


    public void AlienDecrease()
    {
        AliensCount -= 1;

        if(AliensCount <= 0)
        {
            Controller.Victory();
        }
    }
}
