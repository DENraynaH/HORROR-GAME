using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class KeypadController : MonoBehaviour
{
    public int codeSize = 4;
    public string correctCode = "9999";

    public Keypad keypad;
    public string currentCode = "";
    public Text keypadText;
    public Image backgroundPanel;

    public UnityEvent onCorrectCode;
    private bool correctCodeRoutine;

    private void Update()
    {
        KeypadInput();
        keypadText.text = currentCode;
    }

    private void Start()
    {
        keypad = GetComponent<Keypad>();
    }


    public void KeypadInput()
    {
        if (correctCodeRoutine) { return; }
        if (Input.GetKeyDown(KeyCode.Alpha0)) { KeyInput("0"); }
        if (Input.GetKeyDown(KeyCode.Alpha1)) { KeyInput("1"); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { KeyInput("2"); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { KeyInput("3"); }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { KeyInput("4"); }
        if (Input.GetKeyDown(KeyCode.Alpha5)) { KeyInput("5"); }
        if (Input.GetKeyDown(KeyCode.Alpha6)) { KeyInput("6"); }
        if (Input.GetKeyDown(KeyCode.Alpha7)) { KeyInput("7"); }
        if (Input.GetKeyDown(KeyCode.Alpha8)) { KeyInput("8"); }
        if (Input.GetKeyDown(KeyCode.Alpha9)) { KeyInput("9"); }
        if (Input.GetKeyDown(KeyCode.Backspace)) { DeleteLastInput(); }
        if (Input.GetKeyDown(KeyCode.Equals)) { ClearCode(); }
    }

    public void KeyInput(string key)
    {
        if (currentCode.Length >= codeSize) { return; }
        currentCode += key;
    }

    public void DeleteLastInput()
    {
        if (currentCode.Length > 0) { currentCode = currentCode.Remove(currentCode.Length - 1); }
    }

    public void CheckCode()
    {
        if (currentCode == correctCode)
        {
            StartCoroutine(CorrectCodeRoutine());
            correctCodeRoutine = true;
        }
        else
        {
            StartCoroutine(IncorrectCodeRoutine());
            correctCodeRoutine = true;
        }
    }

    private IEnumerator CorrectCodeRoutine()
    {
        onCorrectCode.Invoke();
        for (int i = 0; i < 3; i++)
        {
            backgroundPanel.color = Color.green;
            yield return new WaitForSeconds(0.5f);
            backgroundPanel.color = Color.black;
            yield return new WaitForSeconds(0.5f);

        }
        ClearCode();
        correctCodeRoutine = false;
    }

    private IEnumerator IncorrectCodeRoutine()
    {
        for (int i = 0; i < 3; i++)
        {
            backgroundPanel.color = Color.red;
            yield return new WaitForSeconds(0.5f);
            backgroundPanel.color = Color.black;
            yield return new WaitForSeconds(0.5f);

        }
        ClearCode();
        correctCodeRoutine = false;
    }

    public void ClearCode()
    {
        currentCode = "";
    }

    public void CheckCodeButton()
    {
        if (correctCodeRoutine == false) { CheckCode(); }
    }

}