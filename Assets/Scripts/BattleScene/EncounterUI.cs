using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class EncounterUI : MonoBehaviour
{
    [SerializeField] GameObject abilitiesPanel;
    // Start is called before the first frame update
    [SerializeField] TMPro.TextMeshProUGUI encounterTextBox;
    [SerializeField] GameObject nextButton;

    [SerializeField] private Encounter encounter;

    [SerializeField] float timeBetweenCharacters;

    private IEnumerator animateTextCoroutine = null;

    UnityEvent m_MyEvent = new UnityEvent();
    void Start()
    {

        animateTextCoroutine = AnimateTextCoroutine("You have encounter a battle", timeBetweenCharacters);
        StartCoroutine(animateTextCoroutine);

        encounter.onTurnBegin.AddListener(AnnouceTurnBegin);

        encounter.player.onAbilityCast.AddListener(abilityCast);
        encounter.enemy.onAbilityCast.AddListener(abilityCast);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (encounter.haveVisableUI) 
        {
            nextButton.SetActive(false);
        }
        else
        {
            nextButton.SetActive(true);
        }

            
    }

    IEnumerator AnimateTextCoroutine(string message, float secPerCharacter)
    {
        abilitiesPanel.SetActive(false);

        encounterTextBox.text = "";

        for (int i = 0; i < message.Length; i++)
        {
            encounterTextBox.text += message[i];
            yield return new WaitForSeconds(secPerCharacter);
        }
        if(encounter.currentCharacter == encounter.player && encounter.haveVisableUI)
        {
            abilitiesPanel.SetActive(true);
        }
       
    }

    void AnnouceTurnBegin(ICharacter whoseTurn)
    {
        //if (animateTextCoroutine != null)
        //{
        //    StopCoroutine(animateTextCoroutine);
        //}
        if(encounter.currentCharacter == encounter.player)
        {
            animateTextCoroutine = AnimateTextCoroutine("It is " + whoseTurn.name + "'s turn", timeBetweenCharacters);
            StartCoroutine(animateTextCoroutine);
        }
       
        
    }

    void abilityCast(Ability whichAbility, ICharacter whoCasted)
    {

        //if (animateTextCoroutine != null)
        //{
        //    Debug.Log("asd");
        //    StopCoroutine(animateTextCoroutine);
        //}
        //Debug.Log(whoCasted.name);
        encounter.haveVisableUI = false;
        animateTextCoroutine = AnimateTextCoroutine(whoCasted.name + " casted "  + whichAbility.name, timeBetweenCharacters);
        StartCoroutine(animateTextCoroutine);
    }

}
