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
        GameManager.Instancia.DefinirVelocidadeCobra(vel);
    }

<<<<<<< Updated upstream
public void IniciarJogo()
{
    SceneManager.LoadScene("JogoCobra");
}
=======
    public void IniciarJogo()
    {
        DestroyTodosObjetosNaCena();

        GameManager.Instancia.IniciarJogo();  // Chama o método de iniciar o jogo

        SceneManager.LoadScene("JogoCobra");
    }

    private void DestroyTodosObjetosNaCena()
    {
        // Encontra todos os objetos do tipo GameObject
        GameObject[] objetos = FindObjectsOfType<GameObject>();

        // Itera sobre todos os objetos e os destrói, exceto o Menu
        foreach (GameObject objeto in objetos)
        {
            if (objeto != this.gameObject) // Evita destruir o próprio Menu
            {
                Destroy(objeto);
            }
        }
    }
>>>>>>> Stashed changes
}