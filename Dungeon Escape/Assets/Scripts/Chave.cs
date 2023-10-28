using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chave : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Player>().KeyOn = true;
            Destroy(gameObject);
        }
    }
}
