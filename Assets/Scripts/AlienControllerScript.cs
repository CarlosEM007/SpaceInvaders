using UnityEngine;

public class AlienControllerScript : MonoBehaviour
{
    [SerializeField]
    public float AlienSpeed = 2f;

    [SerializeField]
    public bool CanInvert = true;

    private void Start()
    {
        AlienSpeed = 2f;
    }
}
