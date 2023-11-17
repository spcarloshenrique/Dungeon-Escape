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
    private GameObject painelopcoes;
    
    
    public void jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

    public void abrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelopcoes.SetActive(true);
    }

    public void fecharOpcoes()
    {
        painelopcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void sairDoJogo()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }
}
