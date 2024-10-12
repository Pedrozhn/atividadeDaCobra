using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private TMP_InputField largura;  // Campo de texto para a largura do grid
    [SerializeField] private TMP_InputField altura;   // Campo de texto para a altura do grid
    [SerializeField] private TMP_InputField velocidade;  // Campo de texto para a velocidade da cobra

    public void Aplicar()
    {
        int larg = int.Parse(largura.text);
        int alt = int.Parse(altura.text);
        float vel = float.Parse(velocidade.text);

        GameManager.Instancia.DefinirTamanhoGrid(larg, alt);
    }
}