using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// Summary: This script is used to control the UI in the title scene
public class TitleSceneUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text nameAndID;
    [SerializeField] private Button start;
    [SerializeField] private Button quit;


    // Start is called before the first frame update
    void Start()
    {
        nameAndID.text = "Daekoen Lee 101076401\n Michael Shular 101273089";
    }

    public void loadGame()
    {
        SceneManager.LoadScene("OverWorld");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
