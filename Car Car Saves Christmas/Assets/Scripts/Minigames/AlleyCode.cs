using System.Collections.Generic;
using UnityEngine;

public class AlleyCode : MonoBehaviour
{
    [SerializeField] GameObject codeCanvas;
    [SerializeField] AudioClip buttonPress;
    [SerializeField] string code = "123";
    [SerializeField] AudioClip correct;
    [SerializeField] AudioClip incorrect;
    [SerializeField] GameObject transport;
    public static bool accessed;
    string inputtedCode;

    [SerializeField] List<string> easterEggCodes = new List<string>();
    [SerializeField] List<AudioClip> easterEggClips = new List<AudioClip>();

    private void Start()
    {
        if (accessed)
        {
            transport.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (PointAndClickController.instance.canClick && !accessed)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        PointAndClickController.instance.canClick = false;

        codeCanvas.SetActive(true);
    }

    public void ButtonPress(int value)
    {
        inputtedCode += value.ToString();
        
        PointAndClickController.PlayAudioClip(buttonPress);

        if (inputtedCode.Length >= 3)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        codeCanvas.SetActive(false);

        PointAndClickController.instance.canClick = true;

        if (inputtedCode == code)
        {
            PointAndClickController.PlayAudioClip(correct);

            transport.SetActive(true);
            accessed = true;

            Destroy(gameObject);
        }
        else
        {

            for (int i = 0;  i < easterEggCodes.Count; i++)
            {
                if (inputtedCode == easterEggCodes[i])
                {
                    PointAndClickController.PlayAudioClip(easterEggClips[i]);

                    inputtedCode = string.Empty;

                    return;
                }
            }

            PointAndClickController.PlayAudioClip(incorrect);

            inputtedCode = string.Empty;
        }
    }
}
