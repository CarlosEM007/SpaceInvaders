using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
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
    public Text Vitoria;

    void Start() 
    {
        AlienSpeed = 2f;
        AliensCount = GameObject.FindGameObjectsWithTag("Alien").Length;
        Vitoria.gameObject.SetActive(false);
    }

    void Update()
    {
        RestartGame();
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
    }

    void RestartGame()
    {
        if(AliensCount == 0)
        {
            Vitoria.enabled = true;
        }

        if(Input.GetKeyDown("return") || Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("Fase1");
        }
    }
}
