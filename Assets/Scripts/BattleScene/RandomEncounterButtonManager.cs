using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Has button fuctions that are in the random encounter scene 
//
//Version 0.1
//-button function for change to main scene and keeping player information between scene 
public class RandomEncounterButtonManager : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    //exit the back to main world scene
    public void loadGameWorld()
    {
        
        //passing information to next scene
        DontDestroyOnLoad(player);
        SceneManager.LoadScene("Main");
        //enabling player game object components for main world scene
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
    }
}
