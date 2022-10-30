using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleManager : MonoBehaviour
{
    private bool onGoing = false;

    private Text subtitleTextComponent;
    public GameObject subtitleObject;
    public AudioClip subtitleClip;
    public string subtitleText;

    public float delayPerLetter;
    public float stayTimeBeforeDelete;

    private void Start()
    {
        subtitleTextComponent = subtitleObject.GetComponent<Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 8) { return; }
        if (onGoing) { return; } 
        StartCoroutine(RunSubtitle());
    }

    IEnumerator RunSubtitle()
    {
        onGoing = true;
        subtitleTextComponent.text = "";
        subtitleObject.SetActive(true);
        //AudioClip.Play()
        foreach (char letter in subtitleText)
        {
            yield return new WaitForSeconds(delayPerLetter);
            subtitleTextComponent.text += letter;
        }
        yield return new WaitForSeconds(stayTimeBeforeDelete);
        subtitleObject.SetActive(false);
        onGoing = false;
    }

}
