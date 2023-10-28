using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public Transform destination;
    GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gameObject.CompareTag("PortaFechada"))
            {
                if(player.GetComponent<Player>().KeyOn == true)
                {
                    if (Vector2.Distance(player.transform.position, transform.position) > 0.3f)
                    {
                        player.transform.position = destination.transform.position;
                        GetComponent<CapsuleCollider2D>().enabled = false;
                    }
                }
                else
                {
                    print("Você não possui chave");
                }
            }
            else if (Vector2.Distance(player.transform.position, transform.position) > 0.3f)
            {
                player.transform.position = destination.transform.position;
            }
        }
    }
}
