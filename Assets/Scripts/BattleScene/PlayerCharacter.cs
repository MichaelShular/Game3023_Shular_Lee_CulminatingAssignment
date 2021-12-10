using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCharacter : ICharacter
{
    [SerializeField] Encounter myEnounter;
    static bool isNew = true;
    public SpriteRenderer spriteRenderer;
    public PlayerAbility currA;
    public List<Button> buttons;
    private AnimatorOverrideController overrideController;
    public List<AnimationClip> allAnimationClips;
    private void Start()
    {
        for (int i = 0; i < 4; ++i)
        {
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = currA.currentAbility[i].name;
        }
        currentPokemon = pokemons[0];
        pName = pokemons[0].name;
        abilities = currA.currentAbility;
        maxHealth = currentPokemon.MaxHp;
        attack = currentPokemon.Attack;
        defense = currentPokemon.Defence;
        health = maxHealth;
        hasShield = false;
        incapacitated = false;        
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = currentPokemon.BackSprite;
        charactersAnimation = GetComponent<Animator>();
        charactersAnimation.SetInteger("BattleAnimation", 4);
        newAnimations();
    }
    public void CastAbility(int slot)
    {
        charactersAnimation.SetInteger("BattleAnimation", slot);
        UseAbilty(slot, this, myEnounter.enemy);        
    }
    public override void TakeTurn(Encounter encounter)
    {
        myEnounter = encounter;
    }   

    private void newAnimations()
    {
        overrideController = new AnimatorOverrideController();
        overrideController.runtimeAnimatorController = charactersAnimation.runtimeAnimatorController;

        foreach (AnimationClip item in allAnimationClips)
        {
            if (item.name == currA.currentAbility[0].name)
            {
                overrideController["BasicAttack"] = item;
            }
            if (item.name == currA.currentAbility[1].name)
            {
                overrideController["SelfHeal"] = item;
            }
            if (item.name == currA.currentAbility[2].name)
            {
                overrideController["CreateShield"] = item;
            }
            if (item.name == currA.currentAbility[3].name)
            {
                overrideController["Stun"] = item;
            }
        }
        charactersAnimation.runtimeAnimatorController = overrideController;
    }

}
