using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Player : MonoBehaviour
{
    Animator _playerAnimator;
    Rigidbody2D _playerRb;
    Vector2 mov;
    GameObject textAnimation;

    
    [SerializeField]
    public float playerSpeed;
    public int vida;
    public Image barra_vida;
    public float porcentagem_vida;
    public SpriteRenderer SpritePlayer;

    public List<int> idChaves = new();

    int OuroFinal;

    bool mochilaAberta;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        textAnimation = GameObject.FindGameObjectWithTag("TextAnimation");
        OuroFinal = 0;
        vida = 100;
        porcentagem_vida = 100;
        mochilaAberta = false;
        SpritePlayer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimentacao();
        porcentagem_vida = vida;
        barra_vida.fillAmount = porcentagem_vida / 100;
    }


    void Movimentacao()
    {
        _playerRb.velocity = new Vector2(mov.x * playerSpeed, mov.y * playerSpeed);

        if (mov.x != 0 || mov.y != 0)
        {
            _playerAnimator.SetFloat("X", mov.x);
            _playerAnimator.SetFloat("Y", mov.y);

            _playerAnimator.SetBool("Walking", true);
        }
        else
        {
            _playerAnimator.SetBool("Walking", false);
        }



    }

    void OnMove(InputValue inputValue)
    {
        mov = inputValue.Get<Vector2>();
    }

    void OnMochila(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            if(!mochilaAberta)
            {
                string stringChaves = "";
                for (int i = 0;i < idChaves.Count; i++)
                {
                    if (idChaves[i] != 0)
                        stringChaves += "Chave " + idChaves[i] + "\n\r";
                }    
                textAnimation.GetComponent<TextAnimation>().AbreMochila(OuroFinal,stringChaves);
                mochilaAberta = true;
            }
            else
            {
                textAnimation.GetComponent<TextAnimation>().FechaMochila();
                mochilaAberta= false;
            }
            
        }
    }

    public void Inventario(int idchave, int ouro)
    {
        idChaves.Add(idchave);
        OuroFinal += ouro;
    }

    public void PlayerDead()
    {
        if (vida==0)
        {
            Debug.Log("Você Morreu!");
            SceneManager.LoadScene("level1");
        }
        else
        {
            vida -=20;
            StartCoroutine(SemDano());
            Debug.Log(porcentagem_vida);
        }
    }

    IEnumerator SemDano()
    {
        Physics2D.IgnoreLayerCollision(6, 10);
        SpritePlayer.color = (Color)(new Color32(255,255, 255, 100));
        yield return new WaitForSeconds(1.2f);
        Physics2D.IgnoreLayerCollision(6, 10,false);
        SpritePlayer.color = (Color)(new Color32(255, 255, 255, 255));
    }
}
