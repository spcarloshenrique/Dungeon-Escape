using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private Transform posicaoJogador;
    GameObject player;
    [SerializeField] private Transform[] pontos;
    [SerializeField] private float veloc_inimigo;
    private int pontoAtual;
    
    AudioSource audio;

    
    // Start is called before the first frame update
    void Start()
    {
        posicaoJogador = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        SeguirPlayer();
    }

    private void SeguirPlayer()
    {
        if(posicaoJogador.gameObject != null)
        {
            if(Vector3.Distance(transform.position, posicaoJogador.position) < 5)
            {
                transform.position = Vector2.MoveTowards(transform.position, posicaoJogador.position, veloc_inimigo * Time.deltaTime);
            }
            else
            {
                MovimentoInimigo();
            }
            
        }
    }

    void MovimentoInimigo()
    {
        transform.position = Vector2.MoveTowards(transform.position, pontos[pontoAtual].position,veloc_inimigo*Time.deltaTime);
        if(transform.position == pontos[pontoAtual].position )
        {
            pontoAtual += 1;
            if(pontoAtual >= pontos.Length)
            {
                pontoAtual = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Player>().PlayerDead();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Espada"))
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
        }
    }
}
