using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public GameObject player;
    public GameObject UI;
    private bool UIOn;
    private void Start()
    {
        UIOn = false;
        UI.SetActive(UIOn);
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            UIOn = !UIOn;
            UI.SetActive(UIOn);
        }
    }
    public void NewGame()
    {
        PlayerPrefs.SetFloat("x-axis", 0);
        PlayerPrefs.SetFloat("y-axis", 0);
    }
    public void SavePlayer()
    {
        PlayerPrefs.SetFloat("x-axis", player.transform.position.x);
        PlayerPrefs.SetFloat("y-axis", player.transform.position.y);
    }
    public void LoadPlayerPosition()
    {
        player.transform.position = new Vector2( PlayerPrefs.GetFloat("x-axis"), PlayerPrefs.GetFloat("y-axis"));
    }
}
