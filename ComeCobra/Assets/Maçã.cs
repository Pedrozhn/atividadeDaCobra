using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class maca : MonoBehaviour
{
    public GameObject macaPrefab;
    public Vector2 limiteMapa;
    private Cobra cobra;

    public static maca Instancia;  // Singleton

    private void Awake()
    {
<<<<<<< Updated upstream
        // Lista de todas as posições possíveis no grid
        List<Vector2> posicoesDisponiveis = new List<Vector2>();
        for (int x = 0; x < GameManager.Instancia.larguraGrid; x++)
=======
        Instancia = this;
        cobra = Cobra.Instancia;
        if (cobra == null)
>>>>>>> Stashed changes
        {
            Debug.LogError("A referência para a Cobra não foi encontrada!");
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

        transform.position = novaPosicao;
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
        if (cobra == null || cobra.segmento == null)
        {
            Debug.LogError("Lista de segmentos da cobra não inicializada!");
            return false;
        }

        // Verifica se a nova posição está dentro de algum segmento do corpo
        foreach (Transform segmento in cobra.segmento)
        {
            if ((Vector2)segmento.position == posicao)
            {
<<<<<<< Updated upstream
                Vector2 posicao = new Vector2(x, y);

                // Se a posição não estiver ocupada pela cobra, adiciona à lista de disponíveis
                if (!Cobra.Instancia.segmentosCobra.Contains(posicao))
                {
                    posicoesDisponiveis.Add(posicao);
                }
=======
                return true;
>>>>>>> Stashed changes
            }
        }
<<<<<<< Updated upstream
        // Escolhe uma posição aleatória da lista de disponíveis
        if (posicoesDisponiveis.Count > 0)
        {
            novaPosicao = posicoesDisponiveis[Random.Range(0, posicoesDisponiveis.Count)];
        }
    }

}
    
}
=======
        return false;
    }
}
>>>>>>> Stashed changes
