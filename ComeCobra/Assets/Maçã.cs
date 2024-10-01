using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class maca : MonoBehaviour, IGerar
{
    // Gera uma posição aleatória no mapa.
    public Vector2 Posicionar(Vector2 posicao)
    {
        int x = Random.Range(0, GameManager.Instancia.larguraGrid);
        int y = Random.Range(0, GameManager.Instancia.alturaGrid);
        return new Vector2(x, y);
    }




}
