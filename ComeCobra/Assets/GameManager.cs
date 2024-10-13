using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton que gerencia o estado do jogo
    public static GameManager Instancia;
    public int larguraGrid;  // Armazena a largura do grid
    public int alturaGrid;   // Armazena a altura do grid
    public float velocidadeCobra;  // Armazena a velocidade da cobra
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
