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
    float ouro;
    [SerializeField]
    int idFrase;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bauAnimator = GetComponent<Animator>();
        textAnimation = GameObject.FindGameObjectWithTag("TextAnimation");
        bauAberto = false;
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
                player.GetComponent<Player>().Inventario(chaveId, 0);
                if(!bauAberto) 
                {
                    textAnimation.GetComponent<TextAnimation>().MostraFala(idFrase);
                    bauAberto = true;
                }
            }
            else if (ouroOn)
            {
                player.GetComponent<Player>().Inventario(0,ouro);
                if (!bauAberto)
                {
                    textAnimation.GetComponent<TextAnimation>().MostraFala(idFrase);
                    bauAberto = true;
                }
            }
            else
            {
                if (!bauAberto)
                {
                    textAnimation.GetComponent<TextAnimation>().MostraFala(idFrase);
                    bauAberto = true;
                }
            }
        }
        
    }
}
