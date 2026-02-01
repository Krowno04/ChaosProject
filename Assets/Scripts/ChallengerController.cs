using UnityEngine;
using UnityEngine.SceneManagement;

public class ChallengerController : MonoBehaviour, Interactable
{
    public void Interact()
    {
        Debug.Log("Yo! Battle!");
        SceneManager.LoadScene("Initial Battle");

    }
}
