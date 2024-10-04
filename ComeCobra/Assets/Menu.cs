using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public InputField campoLargura;  // Campo de texto para a largura do grid
    public InputField campoAltura;   // Campo de texto para a altura do grid
    public InputField campoVelocidade;  // Campo de texto para a velocidade da cobra

    // Aplica as configurações definidas pelo jogador no menu
    public void AplicarConfiguracoes()
    {
        int largura = int.Parse(campoLargura.text);
        int altura = int.Parse(campoAltura.text);
        float velocidade = float.Parse(campoVelocidade.text);

        // Define as configurações no Gerenciador do Jogo
        GameManager.Instancia.DefinirTamanhoGrid(largura, altura);
        GameManager.Instancia.DefinirVelocidadeCobra(velocidade);
    }
}
