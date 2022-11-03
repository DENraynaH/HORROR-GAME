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
    public AudioSource subtitleClip;
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
        if (Controller.Instance.onGoingVoiceline == true) { return; }
        StartCoroutine(RunSubtitle());
    }

    IEnumerator RunSubtitle()
    {
        Controller.Instance.onGoingVoiceline = true;
        onGoing = true;
        subtitleTextComponent.text = "";
        subtitleObject.SetActive(true);
        subtitleClip.Play();
        foreach (char letter in subtitleText)
        {
            yield return new WaitForSeconds(delayPerLetter);
            subtitleTextComponent.text += letter;
        }
        yield return new WaitForSeconds(stayTimeBeforeDelete);
        subtitleObject.SetActive(false);
        onGoing = false;
        Controller.Instance.onGoingVoiceline = false;
    }

}
