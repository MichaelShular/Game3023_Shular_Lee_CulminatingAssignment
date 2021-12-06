using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICharacter : ICharacter
{
    private enum AITypeOfStates { attack, playerStunned, heal, goingForWin};

    private AITypeOfStates CurrentState = 0;
    public override void TakeTurn(Encounter encounter)
    {

        chooseState(encounter);

        switch (CurrentState)
        {
            case (AITypeOfStates)0:
                UseAbilty(percentOfAbility(50, 51, 75), this, encounter.player);
                break;
            case (AITypeOfStates)1:
                UseAbilty(percentOfAbility(60, 70, 100), this, encounter.player);
                break;
            case (AITypeOfStates)2:
                UseAbilty(percentOfAbility(10, 70, 85), this, encounter.player);
                break;
            case (AITypeOfStates)3:
                UseAbilty(percentOfAbility(100, 101, 101), this, encounter.player);
                break;
            default:
                break;
        }
    }

    private void chooseState(Encounter encounter)
    {
        if (encounter.player.incapacitated)
        {
            CurrentState = AITypeOfStates.playerStunned;
            return;
        }
        if(encounter.player.health < 5)
        {
            CurrentState = AITypeOfStates.goingForWin;
            return;
        }
        if (encounter.enemy.health <= 10)
        {
            CurrentState = AITypeOfStates.heal;
            return;
        }
        CurrentState = AITypeOfStates.attack;
    }
    private int percentOfAbility(int rangeForSlot0, int rangeForSlot1, int rangeForSlot2)
    {
        int abilityToUse = Random.Range(0, 100);
        
        if(abilityToUse < rangeForSlot0)
        {
            abilityToUse = 0;
        }
        else if(abilityToUse >= rangeForSlot0 && abilityToUse < rangeForSlot1)
        {
            abilityToUse = 1;
        }
        else if (abilityToUse >= rangeForSlot1 && abilityToUse < rangeForSlot2)
        {
            abilityToUse = 2;
        }
        else
        {
            abilityToUse = 3;
        }
        return abilityToUse;
    }

}
