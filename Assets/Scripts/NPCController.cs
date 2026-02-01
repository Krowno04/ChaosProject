using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    [SerializeField] Dialogue dialogue;
    [SerializeField] DialogueTrigger trigger;
    public void Interact()
    {
        //Debug.Log("Hey! NPC!");
        trigger.TriggerDialogue();
    }
}
