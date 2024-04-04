using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStandart : MonoBehaviour
{
    [SerializeField] private GameObject Backgroud;
    [SerializeField] private GameObject InfoWindow;
    [SerializeField] private GameObject ErrorWindow;
    [SerializeField] private GameObject ConfirmWindow;
    [SerializeField] private GameObject PromptWindow;
    [SerializeField] private GameObject LoadingWindow;


//#if UNITY_EDITOR
//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Q))
//        {
//            ShowLoading("Loading", "Please wait...");
//        }
//        if (Input.GetKeyDown(KeyCode.W))
//        {
//            Info("Info", "This is an info message!");
//        }
//        if (Input.GetKeyDown(KeyCode.E))
//        {
//            Error("Error", "This is an error message!");
//        }
//        if (Input.GetKeyDown(KeyCode.R))
//        {
//            Confirm("Confirm", "Do you want to confirm?", "Yes", "No", () => { Debug.Log("Yes"); }, () => { Debug.Log("No"); });
//        }
//        if (Input.GetKeyDown(KeyCode.T))
//        {
//            Prompt("Prompt", "Please enter your name", "John Doe", "Your name", (name) => { Debug.Log(name); });
//        }
//    }
//#endif

    private void CloseAllWindows()
    {
        Backgroud.SetActive(false);
        InfoWindow.SetActive(false);
        ErrorWindow.SetActive(false);
        ConfirmWindow.SetActive(false);
        PromptWindow.SetActive(false);
        LoadingWindow.SetActive(false);
    }

    //TODO: Localization support
    public void ShowLoading(string title, string message)
    {
        CloseAllWindows();
        Backgroud.SetActive(true);
        Backgroud.transform.SetAsLastSibling();
        LoadingWindow.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = title;
        LoadingWindow.transform.Find("Message").GetComponent<TextMeshProUGUI>().text = message;
        LoadingWindow.SetActive(true);
        LoadingWindow.transform.SetAsLastSibling();
        transform.SetAsLastSibling();
    }
    public void HideLoading()
    {
        LoadingWindow.SetActive(false);
        Backgroud.SetActive(false);
    }

    public void Info(string title = "Info", string message = "Something has hapend!", Action onComplete = null)
    {
        CloseAllWindows();

        InfoWindow.transform.Find("Caption/Title").GetComponent<TextMeshProUGUI>().text = title;
        InfoWindow.transform.Find("Message").GetComponent<TextMeshProUGUI>().text = message;
        var infoButton = InfoWindow.GetComponentInChildren<Button>();
        infoButton.onClick.RemoveAllListeners();
        infoButton.onClick.AddListener(() =>
        {
            InfoWindow.SetActive(false);
            Backgroud.SetActive(false);
            onComplete?.Invoke();
        });

        InfoWindow.SetActive(true);
        InfoWindow.transform.SetAsLastSibling();
        Backgroud.SetActive(true);
        Backgroud.transform.SetAsLastSibling();
        transform.SetAsLastSibling();
    }

    public void Error(string title = "Error", string message = "Some error has occured!", Action onComplete = null)
    {
        CloseAllWindows();

        ErrorWindow.transform.Find("Caption/Title").GetComponent<TextMeshProUGUI>().text = title;
        ErrorWindow.transform.Find("Message").GetComponent<TextMeshProUGUI>().text = message;
        var errorButton = ErrorWindow.GetComponentInChildren<Button>();
        errorButton.onClick.RemoveAllListeners();
        errorButton.onClick.AddListener(() =>
        {
            ErrorWindow.SetActive(false);
            Backgroud.SetActive(false);
            onComplete?.Invoke();
        });

        ErrorWindow.SetActive(true);
        ErrorWindow.transform.SetAsLastSibling();
        Backgroud.SetActive(true);
        Backgroud.transform.SetAsLastSibling();
        transform.SetAsLastSibling();
    }

    public void Confirm(string title, string message, string yesButtonCaption = "YES", string noButtonCaption = "NO", Action onYes = null, Action onNo = null)
    {
        CloseAllWindows();

        ConfirmWindow.transform.Find("Caption/Title").GetComponent<TextMeshProUGUI>().text = title;
        ConfirmWindow.transform.Find("Message").GetComponent<TextMeshProUGUI>().text = message;
        Button yesButton = ConfirmWindow.GetComponentInChildren<HorizontalLayoutGroup>().transform.GetChild(0).GetComponent<Button>();
        Button noButton = ConfirmWindow.GetComponentInChildren<HorizontalLayoutGroup>().transform.GetChild(1).GetComponent<Button>();
        yesButton.GetComponentInChildren<TextMeshProUGUI>().text = yesButtonCaption;
        noButton.GetComponentInChildren<TextMeshProUGUI>().text = noButtonCaption;

        yesButton.onClick.RemoveAllListeners();
        yesButton.onClick.AddListener(() =>
        {
            ConfirmWindow.SetActive(false);
            Backgroud.SetActive(false);
            onYes?.Invoke();
        });

        noButton.onClick.RemoveAllListeners();
        noButton.onClick.AddListener(() =>
        {
            ConfirmWindow.SetActive(false);
            Backgroud.SetActive(false);
            onNo?.Invoke();
        });

        Backgroud.SetActive(true);
        Backgroud.transform.SetAsLastSibling();
        ConfirmWindow.SetActive(true);
        ConfirmWindow.transform.SetAsLastSibling();
        transform.SetAsLastSibling();
    }
    public void Prompt(string title, string message, string defaultValue, string placeHolder, Action<string> onOk)
    {
        CloseAllWindows();

        PromptWindow.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = title;
        PromptWindow.transform.Find("Message").GetComponent<TextMeshProUGUI>().text = message;
        PromptWindow.transform.Find("InputField").GetComponent<TMP_InputField>().text = defaultValue;
        PromptWindow.transform.Find("InputField/Text Area/Placeholder").GetComponent<TextMeshProUGUI>().text = placeHolder;

        var prompButton = PromptWindow.GetComponentInChildren<Button>();
        prompButton.onClick.RemoveAllListeners();
        prompButton.onClick.AddListener(() =>
        {
            PromptWindow.SetActive(false);
            Backgroud.SetActive(false);
            onOk?.Invoke(PromptWindow.transform.Find("InputField").GetComponent<TMP_InputField>().text.Trim());
        });

        PromptWindow.SetActive(true);
        PromptWindow.transform.SetAsLastSibling();
        Backgroud.SetActive(true);
        Backgroud.transform.SetAsLastSibling();
        transform.SetAsLastSibling();
    }
}
