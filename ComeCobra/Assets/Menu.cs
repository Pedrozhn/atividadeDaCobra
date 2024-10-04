using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public InputField Largura;  // Campo de texto para a largura do grid
    public InputField Altura;   // Campo de texto para a altura do grid
    public InputField Velocidade;  // Campo de texto para a velocidade da cobra

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
