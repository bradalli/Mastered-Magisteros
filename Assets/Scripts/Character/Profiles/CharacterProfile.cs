using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mastered.Magisteros.NPC
{
    [CreateAssetMenu(fileName = "Character Profile", menuName = "Character Profile", order = 1)]
    public class CharacterProfile : ScriptableObject
    {
        [Header("Info")]
        public string characterName = "NotYetAssigned";
        public Personality personality = Personality.Friendly;
        public UnityEngine.Object meshPrefab = null;

        public enum Personality { Friendly, Hostile, Fearful }

        [Header("Stats")]
        [Range(1, 100)]
        public int level = 5;
        [Range(1, 100)]
        public int baseHealth = 50;
        [Range(1, 100)]
        public int baseArmour = 50;
        [Range(1, 100)]
        public int baseStamina = 50;
        [Range(1, 100)]
        public int baseSpeed = 50;
        [Range(1, 100)]
        public int baseDamage;
    }
}

