using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    public Text Vitoria;

    [SerializeField]
    private bool CanRestart;

    [SerializeField]
    private PlayerControl playerControl;

    [SerializeField]
    private AlienScript alienScript;


    void Start()
    {
        Vitoria.gameObject.SetActive(false);
        CanRestart = false;
    }

    void Update()
    {
        RestartGame();
    }

    public void MostrarMensagem()
    {
        alienScript.EndGame();
        playerControl.EndGame();

        Vitoria.gameObject.SetActive(true);
        CanRestart = true;
    }

    public void Derrota()
    {
        Vitoria.text = "Você foi derrotado! :(";
        MostrarMensagem();
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
