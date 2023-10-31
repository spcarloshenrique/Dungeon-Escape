using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chave : MonoBehaviour
{
    [SerializeField]
    int chaveId;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Player>().KeyOn = true;
            collision.GetComponent<Player>().Inventario(chaveId);
            Destroy(gameObject);
        }
    }

    
}
