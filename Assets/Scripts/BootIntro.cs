using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BootIntro : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeSpeed = 1.5f;

    void Start()
    {
        StartCoroutine(Intro());
    }

    IEnumerator Intro()
    {
        canvasGroup.alpha = 0;

        // Fade in
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        // Fade out
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }

        SceneManager.LoadScene("MainMenuUI");
    }
}