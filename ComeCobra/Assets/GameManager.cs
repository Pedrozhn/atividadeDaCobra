using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia;

    public int larguraGrid;  // Armazena a largura do grid
    public int alturaGrid;   // Armazena a altura do grid
    public float velocidadeCobra;  // Armazena a velocidade da cobra
    private GameObject prefabMaca;  // Prefab da maçã
    private GameObject macaInstanciada; // Referência para a maçã instanciada

  

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IniciarJogo()
    {
        // Verifica se o prefab está definido e se a maçã não foi instanciada
        if (prefabMaca != null && macaInstanciada == null)
        {
            // Instancia a maçã
            macaInstanciada = Instantiate(prefabMaca);
            // Gera e posiciona a maçã
            macaInstanciada.GetComponent<maca>().RecriarMaca(); // Certifique-se de que "Maca" esteja com a letra maiúscula
        }
        else if (macaInstanciada != null)
        {
            Debug.Log("A maçã já foi instanciada.");
        }
        else
        {
            Debug.LogError("Prefab de maçã não está atribuído!");
        }
    }

    public void DefinirTamanhoGrid(int largura, int altura)
    {
        larguraGrid = largura;
        alturaGrid = altura;
        maca.Instancia.limiteMapa = new Vector2(largura / 2, altura / 2);  // Define os limites da maçã
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
            posicao.x = 0;

        if (posicao.y < 0)
            posicao.y = alturaGrid - 1;
        else if (posicao.y >= alturaGrid)
            posicao.y = 0;

        return posicao;
    }
}
