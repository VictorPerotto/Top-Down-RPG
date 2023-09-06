using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj;
    public Image profileSprite;
    public Text speechText;
    public Text actorNameText;

    [Header("Settings")]
    public float typeSpeed;
    private bool isShowing;
    private int index;
    private string[] sentences;

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