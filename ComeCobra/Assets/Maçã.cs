using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class maca : MonoBehaviour
{
    public GameObject prefabMaca;
    public Vector2 limiteMapa;
    private Cobra cobra;

    public List<Vector2> segmentosCobra = new List<Vector2>();

    public static maca Instancia;  // Singleton

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject); // Garante que a instância persista entre as cenas
        }
        else
        {
            Destroy(gameObject); // Destrói duplicatas
            return;
        }

        cobra = Cobra.Instancia;
        if (cobra == null)
        {
            Debug.LogError("A referência para a Cobra não foi encontrada!");
            return;
        }

        RecriarMaca();  // Cria a primeira maçã
    }

    public void RecriarMaca()
    {
        Vector2 novaPosicao;

        // Tenta encontrar uma posição válida dentro dos limites
        do
        {
            novaPosicao = GerarPosicaoAleatoria();
        }
        while (EstaDentroDoCorpo(novaPosicao));

        transform.position = novaPosicao; // Define a nova posição da maçã
    }

    // Gera uma posição aleatória que não esteja sobre a cobra
    private Vector2 GerarPosicaoAleatoria()
    {
        int x = Random.Range(0, GameManager.Instancia.larguraGrid);
        int y = Random.Range(0, GameManager.Instancia.alturaGrid);
        return new Vector2(x, y);
    }

    private bool EstaDentroDoCorpo(Vector2 posicao)
    {
        if (cobra.segmentosCobra == null || cobra.segmentosCobra.Count == 0)
        {
            Debug.LogError("Lista de segmentos da cobra não foi inicializada corretamente!");
            return false;
        }

        // Verifica se a nova posição está dentro de algum segmento do corpo
        IList list = cobra.segmentosCobra; //aqui realmente não sei explicar, o proprio inuty corrigiu :P
        for (int i = 0; i < list.Count; i++)
        {
            Vector2 segmento = (Vector2)list[i];
            if (segmento.Equals(posicao))  // Melhor forma de comparar structs
            {
                return true; // A posição está ocupada pela cobra
            }
        }


        return false; // A posição está livre
    }
}

