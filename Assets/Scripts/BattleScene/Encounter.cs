using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Encounter : MonoBehaviour
{
    private int turnNumber;

    public int TurnNumber
    {
        get { return TurnNumber; }
        private set { turnNumber = value; }
    }

    public PlayerCharacter player;
    public AICharacter enemy;
    public ICharacter currentCharacter;

    public UnityEvent<PlayerCharacter> onPlayerTurnBegin;
    public UnityEvent<PlayerCharacter> onPlayerTurnEnd;

    public UnityEvent<AICharacter> onEnemyTurnBegin;
    public UnityEvent<ICharacter> onTurnBegin;
    public bool haveVisableUI;
    public TextMeshProUGUI battlestateText;
    public Canvas gameState;
    void Start()
    {
        currentCharacter = player;
        haveVisableUI = true;
        player.onAbilityCast.AddListener(OnAbilityCastCallBack);
        gameState.enabled = false;
        if(GameObject.Find("MusicManager") != null)
        {
            GameObject.Find("MusicManager").GetComponent<SoundManager>().PlayTrack(TrackID.BattleMusic);
        }
    }

    public void OnAbilityCastCallBack(Ability casted, ICharacter self)
    {
        //UpdateTurns()
        //StartCoroutine(delayLogic());
        
        //Debug.Log(currentCharacter.name);
    }

    public void nextTurn()
    {
        if(player.health < 0)
        {
            battlestateText.text = "You Lost";
            gameState.enabled = true; 
        }
        if(enemy.health < 0)
        {
            gameState.enabled = true;
            battlestateText.text = "You Won";
        }

        if (currentCharacter == player)
        {
            player.charactersAnimation.SetInteger("BattleAnimation", 4);
            
            currentCharacter = enemy;
        }
        else
        {
            enemy.charactersAnimation.SetInteger("BattleAnimation", 4);
            haveVisableUI = true;
            currentCharacter = player;
        }
        UpdateTurns();
    }
    public void UpdateTurns()
    {
        turnNumber++;
        if (currentCharacter == player)
        { 
            //currentCharacter = enemy;
            player.onAbilityCast.RemoveListener(OnAbilityCastCallBack);
            enemy.onAbilityCast.AddListener(OnAbilityCastCallBack);
            onPlayerTurnEnd.Invoke(player);
            onEnemyTurnBegin.Invoke(enemy);
        }
        else
        {
            enemy.onAbilityCast.RemoveListener(OnAbilityCastCallBack);
            player.onAbilityCast.AddListener(OnAbilityCastCallBack);

            onPlayerTurnBegin.Invoke(player);

        }
        onTurnBegin.Invoke(currentCharacter);
        currentCharacter.TakeTurn(this);

    }

    IEnumerator delayLogic()
    {
        yield return new WaitForSeconds(5);
        UpdateTurns();
    }

    public void backToOverWorld()
    {
        SceneManager.LoadScene("OverWorld");
    }

}
