using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel;
    public TextMeshProUGUI tutorialText;

    private bool hasMoved = false;

    void Start()
    {
        tutorialPanel.SetActive(false);
    }

    public void PlayerLanded()
    {
        tutorialPanel.SetActive(true);
        tutorialText.text = "Press A & D to Move";
    }

    void Update()
    {
        if (tutorialPanel.activeSelf)
        {
            // Detect movement input
            if (!hasMoved && Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0)
            {
                hasMoved = true;
                tutorialText.text = "Press SPACE to Jump";
            }

            // Detect jump input
            if (hasMoved && Input.GetKeyDown(KeyCode.Space))
            {
                tutorialPanel.SetActive(false);
            }
        }
    }
}