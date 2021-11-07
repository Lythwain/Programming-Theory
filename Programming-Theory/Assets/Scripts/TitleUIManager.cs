using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class TitleUIManager : MonoBehaviour
{
    public Button playButton;
    public TMP_InputField nameInputField;

    // Start is called before the first frame update
    void Start()
    {
        if((GameManager.Instance.playerName == null) || (GameManager.Instance.playerName.Length == 0))
        {
            playButton.enabled = false;
        }
        else
        {
            nameInputField.text = GameManager.Instance.playerName;
            playButton.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ValueChanged(string value)
    {
        playButton.enabled = (nameInputField.text.Length > 0) ? true : false;
    }
    public void PlayButtonClicked()
    {
        GameManager.Instance.playerName = nameInputField.text;
        SceneManager.LoadScene(1);
    }
}
