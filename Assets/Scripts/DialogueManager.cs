using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Mono.Cecil.Cil;

//public class DialogManager : MonoBehaviour
//{
//    [SerializeField] GameObject dialogBox;
//    [SerializeField] TextMeshProUGUI dialogText;


//    [SerializeField] int lettersPerSecond;

//    public event Action OnShowDialog;
//    public event Action OnHideDialog;
//    public static DialogManager instance {  get; private set; }
//    private void Awake()
//    {
//        instance=this;
//    }

//    Dialog dialog;
//    int currentLine = 0;
//    bool isTyping;

//    public void HandleUpdate()
//    {
//        if (Input.GetKeyDown(KeyCode.Z) && !isTyping)
//        {
//            ++currentLine;
//            if (currentLine < dialog.Lines.Count)
//            {
//                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
//            }
//            else
//            {
//                dialogBox.SetActive(false);
//                currentLine = 0;
//                OnHideDialog?.Invoke();
//            }
//        }
//    }
//    public IEnumerator ShowDialog(Dialog dialog)
//    {
//        yield return new WaitForEndOfFrame();
//        OnShowDialog?.Invoke();

//        this.dialog = dialog;

//        dialogBox.SetActive(true);
//        StartCoroutine(TypeDialog(dialog.dialogLines.[0]));
//    }

//    public IEnumerator TypeDialog(string line)
//    {
//        isTyping = true;
//        dialogText.text = "";
//        foreach (var letter in line.ToCharArray())
//        {
//            dialogText.text += letter;
//            yield return new WaitForSeconds(1f / lettersPerSecond);
//        }
//        isTyping = false;
//    }
//}

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI characterNameAlt;
    public TextMeshProUGUI dialogueArea;
    public TextMeshProUGUI dialogueAreaNoChar;
    public event Action OnShowDialog;
    public event Action OnHideDialog;
    private Queue<DialogueLine> lines;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] GameObject dialogueName;
    [SerializeField] GameObject dialogueNameAlt;
    [SerializeField] GameObject dialoguePortrait;
    public bool isTyping = false;

    public bool isDialogueActive = false;

    public int typingSpeed;

    //public Animator animator;

    private void Start()
    {
        if (instance == null)
            instance = this;
        lines = new Queue<DialogueLine>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);
        OnShowDialog?.Invoke();

        isDialogueActive = true;
        //animator.Play("show");
        lines.Clear();
        
        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }
        DisplayNextDialogueLine();
    }

    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isTyping)
        {
            Debug.Log("Input");
            isTyping = true;
            DisplayNextDialogueLine();
        }
    }

    public void DisplayNextDialogueLine()
    {
        Debug.Log("DisplayDialogue");

        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();

        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;
        characterNameAlt.text = currentLine.character.name;

        if (currentLine.isCharText == true)
        {
            StartCoroutine(TypeSentence(currentLine));
        }
        else
        {
            StartCoroutine(TypeSentenceNoChar(currentLine));
        }
    }

    public IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialoguePortrait.SetActive(true);
        dialogueName.SetActive(true);
        dialogueNameAlt.SetActive(false);

        Debug.Log("TypeSentence");

        dialogueArea.text = "";
        dialogueAreaNoChar.text = "";

        foreach (var letter in dialogueLine.line.ToCharArray())
        {
            Debug.Log("letter");
            dialogueArea.text += letter;
            yield return new WaitForSeconds(1f / typingSpeed);

        }
        isTyping = false;
    }
    public IEnumerator TypeSentenceNoChar(DialogueLine dialogueLine)
    {
        dialoguePortrait.SetActive(false);
        dialogueName.SetActive(false);

        if (dialogueLine.NameNoPortrait)
            dialogueNameAlt.SetActive(true);
        else
            dialogueNameAlt.SetActive(false);

        Debug.Log("TypeNarration");

        dialogueArea.text = "";
        dialogueAreaNoChar.text = "";
        foreach (var letter in dialogueLine.line.ToCharArray())
        {
            Debug.Log("letter");
            dialogueAreaNoChar.text += letter;
            yield return new WaitForSeconds(1f / typingSpeed);

        }
        isTyping = false;
    }

    //    public IEnumerator TypeDialog(string line)
    //    {
    //        isTyping = true;
    //        dialogText.text = "";
    //        foreach (var letter in line.ToCharArray())
    //        {
    //            dialogText.text += letter;
    //            yield return new WaitForSeconds(1f / lettersPerSecond);
    //        }
    //        isTyping = false;
    //    }

    void EndDialogue()
    {
        OnHideDialog?.Invoke();
        dialogueBox.SetActive(false);
        isDialogueActive = false;
        //animator.Play("hide");
    }
}