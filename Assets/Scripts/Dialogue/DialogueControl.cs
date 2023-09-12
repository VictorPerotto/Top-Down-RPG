using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum idioma
    {
        pt,
        eng,
        spa
    }

    public idioma language;

    [Header("Components")]
    public GameObject dialogueObj;
    public Image profileSprite;
    public TextMeshProUGUI speechText;
    public TextMeshProUGUI actorNameText;

    [Header("Settings")]
    public float typeSpeed;
    private bool isShowing;
    private int index;
    private string[] sentences;

    public static DialogueControl instance;

    public bool IsShowing {get => isShowing; set => isShowing = value;}
    //chamado antes de todos os métodos Start()
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    IEnumerator TypeSentence() 
    {
        //char letter in sentences - cria uma variavel do tipo char que recebe um char
        //sentences.[index].ToCharArray() - ele pega de sentences que é um array uma string e transforma ela em um array de char
        foreach(char letter in sentences[index].ToCharArray()) 
        {
            speechText.text += letter; //vamos passando letra por letra ao dialogo
            yield return new WaitForSeconds(typeSpeed); //para aguardar o tempo dependendo do type speed
        }
    }

    //pula para a proxima frase
    public void NextSentence()
    {
        if(speechText.text == sentences[index]) //se a frase completa esta sendo exibida
        {
            if(index < sentences.Length - 1) //se ainda tem frases para o npc falar
            {
                index ++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }

            else //acabaram as frases
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                isShowing = false;
            }
        }
    }

    //chama a fala do npc
    public void Speech(string[] text)
    {
        if(!isShowing)
        {
            dialogueObj.SetActive(true); //ativa o objeto do dialogo
            sentences = text;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}