using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Animator _playerAnimator;
    Rigidbody2D _playerRb;
    Vector2 mov;

    //internas
    [SerializeField]
    public float playerSpeed;

    public List<int> idChaves = new();

    float OuroFinal;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimentacao();
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

    public void Inventario(int idchave, float ouro)
    {
        idChaves.Add(idchave);
        OuroFinal += ouro;
    }

    public void PlayerDead()
    {
        Debug.Log("Voce Morreu :(");
    }
}
