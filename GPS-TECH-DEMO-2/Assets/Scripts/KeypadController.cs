using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class KeypadController : MonoBehaviour
{
    bool lockInput = false;
    public int codeSize = 4;
    public string correctCode = "9999";

    public Keypad keypad;
    public string currentCode = "";
    public Text keypadText;
    public Image backgroundPanel;

    public GameObject cinematicCamera;
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
        if (keypad.isInteract == false) { return; }
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
        if (lockInput) { return; }
        if (currentCode.Length >= codeSize) { return; }
        currentCode += key;
    }

    public void DeleteLastInput()
    {
        if (lockInput) { return; }
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
        Controller.Instance.ToggleInteractInput(false);
        lockInput = true;
        for (int i = 0; i < 3; i++)
        {
            backgroundPanel.color = Color.green;
            yield return new WaitForSeconds(0.5f);
            backgroundPanel.color = Color.black;
            yield return new WaitForSeconds(0.5f);

        }
        cinematicCamera.SetActive(true);
        onCorrectCode.Invoke();
        ClearCodeOverride();
        correctCodeRoutine = false;
        yield return new WaitForSeconds(5f);
        cinematicCamera.SetActive(false);
        Controller.Instance.ToggleInteractInput(true);
        lockInput = false;
    }

    private IEnumerator IncorrectCodeRoutine()
    {
        lockInput = true;
        for (int i = 0; i < 3; i++)
        {
            backgroundPanel.color = Color.red;
            yield return new WaitForSeconds(0.5f);
            backgroundPanel.color = Color.black;
            yield return new WaitForSeconds(0.5f);

        }
        ClearCodeOverride();
        correctCodeRoutine = false;
        lockInput = false;
    }

    public void ClearCode()
    {
        if (lockInput) { return; }
        currentCode = "";
    }

    public void ClearCodeOverride()
    {
        currentCode = "";
    }

    public void CheckCodeButton()
    {
        if (lockInput) { return; }
        if (correctCodeRoutine == false) { CheckCode(); }
    }

}
