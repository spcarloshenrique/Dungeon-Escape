using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escada : MonoBehaviour
{
    public Transform destination;
    GameObject player;

    AudioSource escada;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        escada = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Vector2.Distance(player.transform.position, transform.position) > 0.3f)
            {
                player.transform.position = destination.transform.position;
                AudioSource.PlayClipAtPoint(escada.clip, transform.position);
            }
        }
    }
}
