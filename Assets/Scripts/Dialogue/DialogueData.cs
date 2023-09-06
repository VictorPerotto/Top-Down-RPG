using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue/Dialogue")]
public class DialogueData : ScriptableObject
{
    [Header("Settings")]
    public GameObject actor;
    
    [Header("Dialogue")]
    public Sprite speakerSprite;
    public string sentence;

    public List<Sentences> dialogues = new List<Sentences>();
}

[System.Serializable] //para aparecer no inspector da unity
public class Sentences
{
    public string actorName;
    public Sprite profile;
    public Languages sentence;
}

[System.Serializable]
public class Languages
{
    public string portuguese;
    public string english;
    public string spanish;
}

#if UNITY_EDITOR
[CustomEditor(typeof(DialogueData))]
public class BuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogueData dialogueData = (DialogueData)target; //armazena a classe alvo

        Languages languages = new Languages(); //armazenamos as frases nas suas respectivas linguagens
        languages.portuguese = dialogueData.sentence; //toda vez que uma nova frase é criada ela é armazenada em portugues

        Sentences sentence = new Sentences();
        sentence.profile = dialogueData.speakerSprite;
        sentence.sentence = languages;

        if(GUILayout.Button("Create Dialogue")) //criamos um botão para criar o dialogo
        {
            if(dialogueData.sentence != "") //se a fala nao esta vazia
            {
                dialogueData.dialogues.Add(sentence);

                dialogueData.speakerSprite = null;
                dialogueData.sentence = "";
            }
        }
    }
}


#endif