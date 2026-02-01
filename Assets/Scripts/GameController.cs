using UnityEngine;

public enum GameState
{
    FreeRoam, 
    Dialog, 
    Battle
}
public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    GameState state;

    private void Start()
    {

        DialogueManager.instance.OnShowDialog += () =>
        {
            state = GameState.Dialog;
        };
        DialogueManager.instance.OnHideDialog += () =>
        {
            if (state == GameState.Dialog)
                state = GameState.FreeRoam;
        };
    }
    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        } 
        else if (state == GameState.Dialog)
        {
            DialogueManager.instance.HandleUpdate();
        } 
        else if (state == GameState.Battle)
        {

        }
    }
}
