using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;
    public void Interact()
    {
        //Debug.Log("Hey! NPC!");
        StartCoroutine(DialogManager.instance.ShowDialog(dialog));
    }
}
