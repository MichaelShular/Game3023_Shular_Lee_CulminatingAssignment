using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName ="Create Pokemon")]
public class PokemonBase : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;
    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;

    [SerializeField] List<Ability> learnAbility;
    public string GetName
    {
        get { return name; }
    }

    public string Description
    {
        get { return description; }
    }

    public Sprite FrontSprite
    {
        get { return frontSprite; }
    }
    public Sprite BackSprite
    {
        get { return backSprite; }
    }    
    public int MaxHp
    {
        get { return maxHp; }
    }
    public int Attack
    {
        get { return attack; }
    }
    public int Defence
    {
        get { return defense; }
    }

    public List<Ability> Ability
    {
        get
        {
            return learnAbility;
        }
    }

    public Ability this[int key]
    {
        get { return learnAbility[key]; }
        set { learnAbility[key] = value; }
    }

}

public enum PokemonType
{
    None,
    Normal,
    Fire,
    Water,
    Grass,
    Flying,
    Fighting,
    Poison,
    Electric,
    Ground,
    Rock,
    Psychic,
    Ice,
    Bug,
    Ghost,
    Steel,
    Dragon, 
    Dark,
    Fairy
}
