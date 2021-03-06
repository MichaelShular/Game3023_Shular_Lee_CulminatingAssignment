using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICharacter : ICharacter
{
    private enum AITypeOfStates { attack, playerStunned, heal, goingForWin};

    private AITypeOfStates CurrentState = 0;    
    public SpriteRenderer spriteRenderer;
    private AnimatorOverrideController enemyoverrideController;
    public List<AnimationClip> allAnimationClips;
    private void Start()
    {
        int a = Random.Range(0, pokemons.Count);       
        currentPokemon = pokemons[a];
        pName = pokemons[a].name;
        abilities = currentPokemon.Ability;
        maxHealth = currentPokemon.MaxHp;
        attack = currentPokemon.Attack;
        defense = currentPokemon.Defence;
        health = maxHealth;
        hasShield = false;
        incapacitated = false;
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = currentPokemon.FrontSprite;

        charactersAnimation = GetComponent<Animator>();
        charactersAnimation.SetInteger("BattleAnimation", 4);
        newAnimations();
    }
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

    static void ChangeAbility(Ability ability)
    {

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
            charactersAnimation.SetInteger("BattleAnimation", 0);
        }
        else if(abilityToUse >= rangeForSlot0 && abilityToUse < rangeForSlot1)
        {
            abilityToUse = 1;
            charactersAnimation.SetInteger("BattleAnimation", 1);
        }
        else if (abilityToUse >= rangeForSlot1 && abilityToUse < rangeForSlot2)
        {
            abilityToUse = 2;
            charactersAnimation.SetInteger("BattleAnimation", 2);
        }
        else
        {
            abilityToUse = 3;
            charactersAnimation.SetInteger("BattleAnimation", 3);
        }
        
        return abilityToUse;
    }

    private void newAnimations()
    {
        enemyoverrideController = new AnimatorOverrideController();
        enemyoverrideController.runtimeAnimatorController = charactersAnimation.runtimeAnimatorController;

        foreach (AnimationClip item in allAnimationClips)
        {

          
            if (item.name == currentPokemon.Ability[0].name)
            {
                enemyoverrideController["BasicAttack"] = item;
            }
            if (item.name == currentPokemon.Ability[1].name)
            {
                enemyoverrideController["SelfHeal"] = item;
            }
            if (item.name == currentPokemon.Ability[2].name)
            {
                enemyoverrideController["CreateShield"] = item;
            }
            if (item.name == currentPokemon.Ability[3].name)
            {
                enemyoverrideController["Stun"] = item;
            }
        }
        charactersAnimation.runtimeAnimatorController = enemyoverrideController;
    }

}
