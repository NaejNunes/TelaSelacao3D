using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelecionarPersonagem : MonoBehaviour
{

    public Transform esquerdaFora, esquerda, centro, direita, direitaFora;

    public Transform[] listaPersonagens;

    private GameObject[] personagens;

    private int personagemAtual = 0;
    // Start is called before the first frame update
    void Start()
    {
        personagens = new GameObject[listaPersonagens.Length];
        int indice = 0;
        foreach (Transform t in listaPersonagens)
        {
            personagens[indice++] = GameObject.Instantiate(t.gameObject, direitaFora.position, Quaternion.identity) as GameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, (Screen.height - 50) / 2, 100, 50), "Anterior"))
        {
            personagemAtual--;
            if (personagemAtual < 0)
            {
                personagemAtual = 0;
            }
        }

        if (GUI.Button(new Rect(Screen.width - 100 - 10, (Screen.height - 50) / 2, 100, 50), "Próximo"))
        {
            personagemAtual++;
            if (personagemAtual >= personagens.Length)
            {
                personagemAtual = personagens.Length - 1;
            }
        }
        GameObject personagemSelecionado = personagens[personagemAtual];
        string nomePersonagem = personagemSelecionado.name;

        GUI.Label(new Rect((Screen.width - 100) / 2, 20, 200, 50), "CHOOSE YOUR PLAYER");

        int indicePersonagemMeio = personagemAtual;
        int indicePersonagemEsquerda = personagemAtual - 1;
        int indicePersonagemDireita = personagemAtual + 1;

        for (int indice = 0; indice < personagens.Length; indice++)
        {
            Transform transf = personagens[indice].transform;

            if (indice < indicePersonagemEsquerda)
            {
                transf.position = Vector3.Lerp(transf.position, esquerdaFora.position, Time.deltaTime);
            }
            else if (indice > indicePersonagemDireita)
            {
                transf.position = Vector3.Lerp(transf.position, direitaFora.position, Time.deltaTime);
            }
            else if (indice == indicePersonagemEsquerda)
            {
                transf.position = Vector3.Lerp(transf.position, esquerda.position, Time.deltaTime);
            }
            else if (indice == indicePersonagemDireita)
            {
                transf.position = Vector3.Lerp(transf.position, direita.position, Time.deltaTime);
            }
            else if (indice == indicePersonagemMeio)
            {
                transf.position = Vector3.Lerp(transf.position, centro.position, Time.deltaTime);
            }
        }
    }
}
