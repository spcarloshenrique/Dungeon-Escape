using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Porta : MonoBehaviour
{
    public Transform destination;
    GameObject player;
    GameObject textAnimation;
    [SerializeField]
    int portaId;
    [SerializeField]
    bool portaFechada;
    Animator porta;
    public SpriteRenderer SpritePorta;
    public Sprite portaAberta;
    [SerializeField]
    int idFrase;

    
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        textAnimation = GameObject.FindGameObjectWithTag("TextAnimation");
        SpritePorta = GetComponent<SpriteRenderer>();
 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (portaFechada)
            {
                if(player.GetComponent<Player>().idChaves.Contains(portaId) && gameObject.CompareTag("PortaFinal"))
                {
                    SceneManager.LoadScene("Level2");
                }
                else if (player.GetComponent<Player>().idChaves.Contains(portaId))
                {
                    if (Vector2.Distance(player.transform.position, transform.position) > 0.3f)
                    {
                        player.transform.position = destination.transform.position;
                        GetComponent<CapsuleCollider2D>().enabled = false;
                        portaFechada = false;
                        SpritePorta.sprite = portaAberta;
                    }
                }
                else
                {
                    textAnimation.GetComponent<TextAnimation>().MostraFala(idFrase);
                }
            }
            else if (Vector2.Distance(player.transform.position, transform.position) > 0.3f)
            {
                player.transform.position = destination.transform.position;
            }
        }
    }
}
