using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class MenuNavigate : MonoBehaviour
{
    [SerializeField] GameObject startCanvas;
    [SerializeField] GameObject loadCanvas;
    [SerializeField] GameObject infoCanvas;

    [SerializeField] TMP_InputField namebox;
   // [SerializeField] TMP_Text name)

    [SerializeField] TMP_Dropdown pronounbox;
   // [SerializeField] TMP_Text pronoun;

    [SerializeField] TMP_Dropdown genderbox;
    //[SerializeField] TMP_Text gender;

    [SerializeField] TMP_InputField describebox;
   // [SerializeField] TMP_Text describe)

    private void Start()
    {
        startCanvas.SetActive(true);
        loadCanvas.SetActive(false);
        infoCanvas.SetActive(false);
        Debug.Log("woohoo");
    }

    public void StartButton()
    {
        startCanvas.SetActive(false);
        loadCanvas.SetActive(true);

        Debug.Log("start button");
    }
    public void StartBack()
    {
        startCanvas.SetActive( true);
        loadCanvas.SetActive( false);
    }
    public void loadButton()
    {
        loadCanvas.SetActive(false);
        infoCanvas.SetActive(true);
        Debug.Log("start button");

    }
    public void loadBack()
    {
        loadCanvas.SetActive(true);
        infoCanvas.SetActive(false);
    }
  
    public void infoReset()
    {
        namebox.text = "";
        pronounbox.SetValueWithoutNotify(0);
        genderbox.SetValueWithoutNotify(0);
        describebox.text = "";
    }

    public void infoStart()
    {
        SceneManager.LoadScene("Character Customizer");
    }
}
