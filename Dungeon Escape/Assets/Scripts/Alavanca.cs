using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alavanca : MonoBehaviour
{
    public bool ativou;
    Animator _alavancaAnimator;
    // Start is called before the first frame update
    void Start()
    {
        ativou = false; 
        _alavancaAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(!ativou)
            {
                _alavancaAnimator.SetBool("Ativou", true);
                ativou = true;
            }
            else
            {
                _alavancaAnimator.SetBool("Ativou", false);
                ativou = false;
            }
        }
    }
}
