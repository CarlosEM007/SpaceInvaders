using UnityEngine;

public class AlienControllerScript : MonoBehaviour
{
    [SerializeField]
    public float AlienSpeed = 2f;

    [SerializeField]
    public bool CanInvert = true;

    [SerializeField]
    public float SpeedIncrement = 0.2f;

    void Start() 
    {
        AlienSpeed = 2f;
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
}
