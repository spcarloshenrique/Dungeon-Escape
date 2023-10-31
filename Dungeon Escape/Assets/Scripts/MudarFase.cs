using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarFase : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    int portaId;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.gameObject.GetComponent<Player>().idChaves.Contains(portaId))
            SceneManager.LoadScene("Level2");
        else
            Debug.Log("Você não possui chave");
    }
}
