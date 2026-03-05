using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (!triggered && collision.CompareTag("Player"))
        {
            triggered = true;
            Debug.Log("Jump Trigger Activated");

            TutorialManager tutorial = FindFirstObjectByType<TutorialManager>();

            if (tutorial != null)
            {
                tutorial.ShowJumpTutorial();
            }
        }
    }
}   