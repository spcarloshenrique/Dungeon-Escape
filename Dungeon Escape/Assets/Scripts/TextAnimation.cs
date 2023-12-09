using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TextAnimation : MonoBehaviour
{
    GameObject player;
    GameObject inimigo;
    public TextMeshProUGUI textObject;
    public List<string> falas = new();
    public string fullText;
    public GameObject painel;
    public TextData textData;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        //inimigo = GameObject.FindGameObjectWithTag("Inimigo");
    }

    public void MostraFala(int idFala)
    {
        for (int i = 0; i < textData.talkScript.Count; i++)
        {
            if (i == idFala)
            {
                fullText = textData.talkScript[i].text;
            }
        }
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        painel.SetActive(true);
        textObject.text = fullText;
        textObject.maxVisibleCharacters = 0;
        //player.GetComponent<Player>().playerSpeed = 0;
        //inimigo.GetComponent<Inimigo>().veloc_inimigo = 0;
        for(int i = 0; i <= textObject.text.Length; i++)
        {
            textObject.maxVisibleCharacters = i;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.2f);
        //player.GetComponent<Player>().playerSpeed = 7;
        //inimigo.GetComponent<Inimigo>().veloc_inimigo = 3;
        painel.SetActive (false);
    }
}
