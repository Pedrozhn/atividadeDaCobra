using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class maca : MonoBehaviour, IGeradorItem
{
    // Gera uma posição aleatória no mapa.
    public Vector2 GerarPosicao()
    {
        int x = Random.Range(0, GerenciadorJogo.Instancia.larguraGrid);
        int y = Random.Range(0, GerenciadorJogo.Instancia.alturaGrid);
        return new Vector2(x, y);
    }




}
