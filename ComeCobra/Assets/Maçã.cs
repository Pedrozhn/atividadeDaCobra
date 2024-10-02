using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class maca : MonoBehaviour
{
    private Vector2 novaPosicao; // Variável que armazena a nova posição da comida

    // Gera uma posição aleatória que não esteja sobre a cobra
    public void GerarPosicao()
    {
        // Lista de todas as posições possíveis no grid
        List<Vector2> posicoesDisponiveis = new List<Vector2>();
        for (int x = 0; x < GameManager.Instancia.larguraGrid; x++)
        {
            for (int y = 0; y < GameManager.Instancia.alturaGrid; y++)
            {
                Vector2 posicao = new Vector2(x, y);

                // Se a posição não estiver ocupada pela cobra, adiciona à lista de disponíveis
                if (!Cobra.Instancia.segmentosCobra.Contains(posicao))
                {
                    posicoesDisponiveis.Add(posicao);
                }
            }
        }
        // Escolhe uma posição aleatória da lista de disponíveis
        if (posicoesDisponiveis.Count > 0)
        {
            novaPosicao = posicoesDisponiveis[Random.Range(0, posicoesDisponiveis.Count)];
        }
    }

}
    
}
