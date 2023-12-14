using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bau : MonoBehaviour
{
    Animator bauAnimator;
    GameObject player;
    GameObject textAnimation;
    bool bauAberto;
    [SerializeField]
    int chaveId;
    [SerializeField]
    bool chaveOn;
    [SerializeField]
    bool ouroOn;
    [SerializeField]
    int ouro;
    [SerializeField]
    int idFrase;

    AudioSource audio;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bauAnimator = GetComponent<Animator>();
        textAnimation = GameObject.FindGameObjectWithTag("TextAnimation");
        bauAberto = false;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bauAnimator.SetBool("abriu_bau", true);
            
            if (chaveOn)
            {
                if(!bauAberto) 
                {
                    player.GetComponent<Player>().Inventario(chaveId, 0);
                    textAnimation.GetComponent<TextAnimation>().MostraFala(idFrase);
                    bauAberto = true;
                    AudioSource.PlayClipAtPoint(audio.clip, transform.position);
                }
            }
            else if (ouroOn)
            {
                if (!bauAberto)
                {
                    player.GetComponent<Player>().Inventario(0, ouro);
                    textAnimation.GetComponent<TextAnimation>().MostraFala(idFrase);
                    bauAberto = true;
                    AudioSource.PlayClipAtPoint(audio.clip, transform.position);
                }
            }
            else
            {
                if (!bauAberto)
                {
                    textAnimation.GetComponent<TextAnimation>().MostraFala(idFrase);
                    bauAberto = true;
                    AudioSource.PlayClipAtPoint(audio.clip, transform.position);
                }
            }
        }
        
    }
}
