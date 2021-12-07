using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : ICharacter
{
    [SerializeField] Encounter myEnounter;
    static bool isNew = true;
    public SpriteRenderer spriteRenderer;
    public PlayerAbility currA;
    
    private void Start()
    {
        
        currentPokemon = pokemons[0];
        
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

    }
    public void CastAbility(int slot)
    {
        UseAbilty(slot, this, myEnounter.enemy);
    }
    public override void TakeTurn(Encounter encounter)
    {
        myEnounter = encounter;
    }

    

}
