using UnityEngine;
using UnityEngine.UI;

public class LifeScript : MonoBehaviour
{
    [Header("Configurações")]
    public int maxVidas = 3;

    [SerializeField]
    public Sprite iconeVida; // ícone do coração

    private Image[] vidas;

    void Start()
    {
        CriarUI();
    }

    void CriarUI()
    {
        vidas = new Image[maxVidas];

        for (int i = 0; i < maxVidas; i++)
        {
            GameObject obj = new GameObject("Vida_" + (i + 1));
            obj.transform.SetParent(transform); // adiciona ao pai (Canvas ou outro container)

            Image img = obj.AddComponent<Image>();
            img.sprite = iconeVida;
            img.rectTransform.sizeDelta = new Vector2(16, 16); // tamanho do ícone
            img.rectTransform.anchoredPosition = new Vector2(i * 10, 0); // espaçamento horizontal

            vidas[i] = img;
        }
    }

    public void AtualizarVidas(int vidasRestantes)
    {
        for (int i = 0; i < vidas.Length; i++)
        {
            vidas[i].enabled = i < vidasRestantes;
        }
    }
}
