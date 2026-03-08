using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel;
    public TextMeshProUGUI tutorialText;

    private bool hasMoved = false;
    private bool jumpTutorialActive = false;

    void Start()
    {
        tutorialPanel.SetActive(false);
    }

    // Called when player lands from the intro fall
    public void PlayerLanded()
    {
        tutorialPanel.SetActive(true);
        tutorialText.text = "Press A & D to Move";
    }

    // Called by the jump trigger
    public void ShowJumpTutorial()
    {
        jumpTutorialActive = true;
        tutorialPanel.SetActive(true);
        tutorialText.text = "Press SPACE to Jump";
    }
    public void ShowEnemyTutorial()
    {
        tutorialPanel.SetActive(true);
        tutorialText.text = "Press E to defeat enemy";
    }
    void Update()
    {
        // Detect movement
        if (!hasMoved && Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0)
        {
            hasMoved = true;

            // hide movement tutorial once player moves
            tutorialPanel.SetActive(false);
        }

        // Detect jump input
        if (jumpTutorialActive && Input.GetKeyDown(KeyCode.Space))
        {
            tutorialPanel.SetActive(false);
            jumpTutorialActive = false;
        }
    }
}