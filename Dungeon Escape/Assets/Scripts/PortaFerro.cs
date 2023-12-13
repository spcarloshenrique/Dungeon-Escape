using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaFerro : MonoBehaviour
{
    // Start is called before the first frame update
    Alavanca alavanca;
    bool ativou;
    public SpriteRenderer SpritePorta;
    public Sprite portaAberta;
    public Sprite portaFechada;
    void Start()
    {
        alavanca =FindAnyObjectByType<Alavanca>();
        SpritePorta = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ativou = alavanca.ativou;
        Porta();
    }

    private void Porta()
    {
        if (ativou)
        {
            SpritePorta.sprite = portaAberta;
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            SpritePorta.sprite = portaFechada;
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
