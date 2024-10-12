using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField Largura;
    [SerializeField]
    private TMP_InputField Altura;
    [SerializeField]
    private TMP_InputField Velocidade;
    void Start()
    {
        Largura = GameObject.Find("Largura").GetComponent<TMP_InputField>();
        Altura = GameObject.Find("Altura").GetComponent<TMP_InputField>();
        Velocidade = GameObject.Find("Velocidade da Cobra").GetComponent<TMP_InputField>();
    }

    // Aplica as configurações definidas pelo jogador no menu
    public void AplicarConfiguracoes()
    {
        int largura = int.Parse(Largura.text);
        int altura = int.Parse(Altura.text);
        float velocidade = float.Parse(Velocidade.text);

        // Define as configurações no Gerenciador do Jogo
        GameManager.Instancia.DefinirTamanhoGrid(largura, altura);
        GameManager.Instancia.DefinirVelocidadeCobra(velocidade);
    }
}
