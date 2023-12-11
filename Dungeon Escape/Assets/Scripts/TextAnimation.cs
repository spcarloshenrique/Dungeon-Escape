using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TextAnimation : MonoBehaviour
{
    GameObject player;
    Inimigo[] inimigo;
    public TextMeshProUGUI textObject;
    public List<string> falas = new();
    public string fullText;
    public GameObject painelFala;
    public TextData textData;

    public TextMeshProUGUI textChave;
    public TextMeshProUGUI textMoeda;
    public GameObject painelMochila;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");     
        inimigo = FindObjectsOfType(typeof(Inimigo)) as Inimigo[];
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
        painelFala.SetActive(true);
        textObject.text = fullText;
        textObject.maxVisibleCharacters = 0;
        player.GetComponent<PlayerInput>().DeactivateInput();
        foreach (Inimigo ini in inimigo)
        {
            ini.enabled = false;
        }
        for (int i = 0; i <= textObject.text.Length; i++)
        {
            textObject.maxVisibleCharacters = i;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.2f);
        player.GetComponent<PlayerInput>().ActivateInput();
        foreach (Inimigo ini in inimigo)
        {
            ini.enabled = true;
        }
        painelFala.SetActive (false);
    }

    public void AbreMochila(int qntMoedas, string chaves)
    {
        painelMochila.SetActive(true);
        player.GetComponent<Player>().playerSpeed = 0;
        textChave.text = chaves;
        textMoeda.text = qntMoedas.ToString() + " moedas de ouro";
        foreach(Inimigo ini  in inimigo)
        {
            ini.enabled = false;
        }

    }
    public void FechaMochila()
    {
        painelMochila.SetActive(false);
        player.GetComponent<Player>().playerSpeed = 7;
        foreach (Inimigo ini in inimigo)
        {
            ini.enabled = true;
        }
    }

}
