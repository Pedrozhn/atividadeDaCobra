using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton que gerencia o estado do jogo
    public static GameManager Instancia;

    public int larguraGrid = 20;  // Largura do mapa
    public int alturaGrid = 20;   
    public float velocidadeCobra = 0.2f; 
    private void Awake()  
    {        
        if (Instancia == null)
        {           
            Instancia = this;
            DontDestroyOnLoad(gameObject); 
     }
    else
     {            Destroy(gameObject);  
    
        } 
    
    }
    public void DefinirTamanhoGrid(int largura, int altura)
    {
        larguraGrid = largura;
        alturaGrid = altura;
    }
    
    public void DefinirVelocidadeCobra(float velocidade)
    {
        velocidadeCobra = velocidade; // Define a velocidade da cobra
    }
    // Método que retorna uma posição na borda do outro lado se a cobra atravessar os limites do mapa
    public Vector2 MudarPosicao(Vector2 posicao)
    {
        if (posicao.x < 0)
            posicao.x = larguraGrid - 1;
        else if (posicao.x >= larguraGrid)
        {
            posicao.x = 0;
        }

        if (posicao.y < 0)
            posicao.y = alturaGrid - 1;
        else if (posicao.y >= alturaGrid)
            posicao.y = 0;

        return posicao;
    }

}
