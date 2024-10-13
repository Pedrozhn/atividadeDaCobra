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

        // Preenche a lista com todas as posições do grid
        for (int x = 0; x < GameManager.Instancia.larguraGrid; x++)
        {
            for (int y = 0; y < GameManager.Instancia.alturaGrid; y++)
            {
                Vector2 posicao = new Vector2(x, y);

                // Variável para indicar se a posição está ocupada
                bool posicaoOcupada = false;

                
                foreach (var segmento in Cobra.Instancia.segmentosCobra)
                {
                    if (segmento.x == posicao.x && segmento.y == posicao.y)
                    {
                        posicaoOcupada = true;
                      
                    }
                }

                // Se a posição não estiver ocupada pela cobra, adiciona à lista de disponíveis
                if (!posicaoOcupada)
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

    // Posiciona a comida na posição gerada e armazenada em `novaPosicao`.
    public void Posicionar()
    {
        transform.position = new Vector3(novaPosicao.x, novaPosicao.y, 0);
    }

    // Método chamado para gerar e posicionar a comida
    public void GerarEPosicionar()
    {
        GerarPosicao();  // Gera uma nova posição válida
        Posicionar();    // Posiciona a maçã na nova posição
    }

}
