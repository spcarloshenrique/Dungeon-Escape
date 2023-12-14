using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Porta : MonoBehaviour
{
    public Transform destination;
    GameObject player;
    GameObject textAnimation;
    [SerializeField]
    int portaId;
    [SerializeField]
    public bool portaFechada;
    public SpriteRenderer SpritePorta;
    public Sprite portaAberta;
    [SerializeField]
    int idFrase;
    [SerializeField]
    string level;

    AudioSource audio;

    
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        textAnimation = GameObject.FindGameObjectWithTag("TextAnimation");
        SpritePorta = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (portaFechada)
            {
                if(player.GetComponent<Player>().idChaves.Contains(portaId) && gameObject.CompareTag("PortaFinal"))
                {
                    SceneManager.LoadScene(level);
                    AudioSource.PlayClipAtPoint(audio.clip, transform.position);
                }
                else if (player.GetComponent<Player>().idChaves.Contains(portaId))
                {
                    StartCoroutine(AbrindoPorta()); 
                }
                else
                {
                    textAnimation.GetComponent<TextAnimation>().MostraFala(idFrase);
                }
            }
            else
            {
                player.transform.position = destination.transform.position;
            }
        }
    }

    IEnumerator AbrindoPorta()
    {
        textAnimation.GetComponent<TextAnimation>().MostraFala(7);
        portaFechada = false;
        yield return new WaitForSeconds(0.2f);
        AudioSource.PlayClipAtPoint(audio.clip, transform.position);
        SpritePorta.sprite = portaAberta;
        GetComponent<CapsuleCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.8f);
        player.transform.position = destination.transform.position;
    }
}
