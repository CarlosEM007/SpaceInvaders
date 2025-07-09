using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    public Text Vitoria;

    [SerializeField]
    public bool CanRestart;

    void Start()
    {
        Vitoria.gameObject.SetActive(false);
        CanRestart = false;
    }

    void Update()
    {
        RestartGame();
    }

    public void Victory()
    {
        Vitoria.gameObject.SetActive(true);
        CanRestart = true;
    }

    void RestartGame()
    {
        if (CanRestart)
        {
            if (Input.GetKeyDown("return") || Input.GetKeyDown("r"))
            {
                SceneManager.LoadScene("Fase1");
            }
        }
    }
}
