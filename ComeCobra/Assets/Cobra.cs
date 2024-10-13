using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cobra : MonoBehaviour
{
     public Vector2 direcao = Vector2.right;  // Direção inicial da cobra
    private float temporizadorMovimento;  // Temporizador que controla o tempo entre movimentos
    private bool viva = true;  // Verifica se a cobra está viva
    public static Cobra Instancia;

    [SerializeField]
    private Transform segmentoPrefab;


    public List<Transform> segmentosCobra = new List<Transform>();  // Segmentos da cobra
    public List<Vector2> segmentosCobra = new List<Vector2>();  // Lista que armazena os segmentos da cobra

    private void Awake()
    {
        if (Instancia == null) // Define esta instância como a instância da cobra
        {
            Instancia = this;
        }
        else
        {
            Destroy(gameObject);
        } 
    }

    public void Inicializar()
    {
        segmentosCobra.Clear();  // Limpa os segmentos anteriores
        transform.position = Vector3.zero;  // Define a posição inicial da cobra
        AdicionarSegmento();  // Adiciona o primeiro segmento
    }
    private void Start()
    {
        // Define a posição inicial da cobra no meio 
        segmentosCobra.Add(new Vector2(10, 10));
    }

    public void AdicionarSegmento()
    {
        Transform novoSegmento = Instantiate(segmentoPrefab);
        novoSegmento.position = segmentosCobra.Count == 0
           if (segmentosCobra.Count == 0)
        {
            // Se não houver segmentos, posiciona na mesma posição da cabeça
            novoSegmento.position = transform.position;
        }
        else
        {
            // Se já houver segmentos, posiciona no mesmo lugar do último segmento
            novoSegmento.position = segmentosCobra[segmentosCobra.Count - 1].position;
        }
        segmentosCobra.Add(novoSegmento);
    }
    private void Update()
    {
        if (viva)
        {
            temporizadorMovimento += Time.deltaTime;
            if (temporizadorMovimento >= GameManager.Instancia.velocidadeCobra)
            {
                AtualizarDirecao();  // Atualiza a direção com base na entrada do jogador
                Movimentar();
                VerificarColisao();
                temporizadorMovimento = 0;
            }
        }
    }
    private void AtualizarDirecao()
    {
        if (Input.GetKeyDown(KeyCode.W))
            direcao = Vector2.up;  // Move para cima
        else if (Input.GetKeyDown(KeyCode.S))
            direcao = Vector2.down;  // Move para baixo
        else if (Input.GetKeyDown(KeyCode.A))
            direcao = Vector2.left;  // Move para a esquerda
        else if (Input.GetKeyDown(KeyCode.D))
            direcao = Vector2.right;  // Move para a direita
    }
    private void Movimentar()
    {
        Vector2 novaPosicao = segmentosCobra[0] + direcao; // Define a nova posição da cabeça da cobra

        // Move todos os segmentos para a posição do segmento anterior
        for (int i = segmentosCobra.Count - 1; i > 0; i--)
        {
            segmentosCobra[i] = segmentosCobra[i - 1];
        }

        segmentosCobra[0] = novaPosicao; // Atualiza a posição da cabeça
        VerificarLimites(novaPosicao); // Verifica se a cobra ultrapassou os limites do mapa }

      
    }
    private void VerificarColisao()
    {
        Vector2 posicaoCabeca = segmentosCobra[0];

        // Verifica se a cobra colidiu consigo mesma sem usar Contains
        for (int i = 1; i < segmentosCobra.Count; i++)
        {
            if (segmentosCobra[i].x == posicaoCabeca.x && segmentosCobra[i].y == posicaoCabeca.y)
            {
                Debug.Log("A cobra se comeu e morreu :C");
                viva = false;  // Cobra morre
                return;
            }
        }
    }

    // Método que faz a cobra crescer
    public void Crescer()
    {
        Vector2 segmentoCauda = segmentosCobra[segmentosCobra.Count - 1];
        segmentosCobra.Add(segmentoCauda);  // Adiciona um novo segmento à cobra
    }
   
    // Verifica se a cobra ultrapassou os limites e a reposiciona do outro lado
    private void VerificarLimites(Vector2 novaPosicao)
    {
        if (novaPosicao.x < 0)
        {
            segmentosCobra[0] = new Vector2(GameManager.Instancia.larguraGrid - 1, novaPosicao.y);
        }
        else if (novaPosicao.x >= GameManager.Instancia.larguraGrid)
        {
            segmentosCobra[0] = new Vector2(0, novaPosicao.y);
        }

        if (novaPosicao.y < 0)
        {
            segmentosCobra[0] = new Vector2(novaPosicao.x, GameManager.Instancia.alturaGrid - 1);
        }
        else if (novaPosicao.y >= GameManager.Instancia.alturaGrid)
        {
            segmentosCobra[0] = new Vector2(novaPosicao.x, 0);
        }
    }
}