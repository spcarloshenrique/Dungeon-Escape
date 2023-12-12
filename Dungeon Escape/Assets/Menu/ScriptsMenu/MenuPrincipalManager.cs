using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private string nomeDoLevelDeJogo;
    
    [SerializeField]
    private GameObject painelMenuInicial;

    [SerializeField] 
    private GameObject NomeJogo;
    
    [SerializeField]
    private GameObject painelopcoes;
    
    
    public void jogar()
    {
        
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

    public void abrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelopcoes.SetActive(true);
        NomeJogo.SetActive(false);
    }

    public void fecharOpcoes()
    {
        painelopcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
        NomeJogo.SetActive(true);
    }

    public void sairDoJogo()
    {
        Debug.Log("Saindo do jogo... só funciona quando o jogo for .exe");
        Application.Quit();
    }
}
