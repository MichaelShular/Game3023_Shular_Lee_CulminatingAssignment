using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public List<Ability> learnableAbility;
    public GameObject chooseAbility;
    public List<Button> learnalbeSlot;
    
    public GameObject chooseWhere;
    public List<Button> PlayerSlot;

    public Ability currentAbility;
    public PlayerAbility player;

    PlayerController p;
    // Start is called before the first frame update
    private void Start()
    {        
        for (int i = 0; i < learnableAbility.Count; ++i)
        {
            learnalbeSlot[i].GetComponentInChildren<TextMeshProUGUI>().text = learnableAbility[i].name;                      
        }
        for (int i = 0; i < PlayerSlot.Count; ++i)
        {
            PlayerSlot[i].GetComponentInChildren<TextMeshProUGUI>().text = player.currentAbility[i].name;
        }
    }
    public void Interact(PlayerController player)
    {
        chooseAbility.SetActive(true);
        p = player;
    }
    public void ChooseClicked(Button button)
    {
        string name = button.name;
        int temp = 0;
        temp = int.Parse(name);
        currentAbility = learnableAbility[temp - 1];
        chooseAbility.SetActive(false);
        chooseWhere.SetActive(true);
    }

    public void SetAbility(Button button)
    {
        string name = button.name;
        int temp = 0;
        temp = int.Parse(name);
        player.currentAbility[temp - 1] = currentAbility;
        chooseWhere.SetActive(false);
        p.isInteract = false;
    }
}
