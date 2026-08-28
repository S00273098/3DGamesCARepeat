using UnityEngine;

public class ExitButton : MonoBehaviour, IInteractable
{
    private bool activated = false;

    public void Interact()
    {
        if (activated)
            return;

        activated = true;

        GameManager.Instance.CompleteGame();
    }
}