using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using manager.ioc;

namespace attributeSystem.rts.twod
{
    [System.Serializable]
    public class AttributesDictionary : CustomDict<string, IamAttribute>
    {
        public AttributesDictionary() : base()
        {
        }
    }

    [System.Serializable]
    public class AttributeContainerState
    {
        public Stats StatsBase = new Stats();

        public enum ArmorTypes
        {
            Unarmed,
            BuildingLight,
            Building,
            BuildingHeavy,
            KavalleryLight,
            Kavallery,
            KavalleryHeavy,
            InfantryLight,
            Infantry,
            InfantryHeavy,
            Siege,
            Hero,
        }

        public enum DamageTypes
        {
            Magic,
            Unarmed,
            Blunt,
            Pierce,
            Slash,
            Siege,
            Hero,
        }

        public enum Boni
        {
            Health,
            Strength,
            HealthRegen,
            Mana,
            Magic,
            Intelligence,
            ManaRegen,
            Rage,
            Attack,
            Energy,
            WalkSpeed,
            RunSpeed,
            Dexterity,
            Armor,
            MagicResistence
        }

        [System.Serializable]
        public class Stats
        {
            public Basis basis = new Basis();
            public FlatBonus flatBonus = new FlatBonus();
            public PercentageBonus percentageBonus = new PercentageBonus();

            public ArmorTypes ArmorType = ArmorTypes.Infantry;
            public DamageTypes DamageType = DamageTypes.Slash;

            public float max_Health { get => (basis.Health + flatBonus.Health) * percentageBonus.Health; }
            public float max_Strength { get => (basis.Strength + flatBonus.Strength) * percentageBonus.Strength; }
            public float max_HealthRegen { get => (basis.HealthRegen + flatBonus.HealthRegen) * percentageBonus.HealthRegen; }
            public float max_Mana { get => (basis.Mana + flatBonus.Mana) * percentageBonus.Mana; }
            public float max_Magic { get => (basis.Magic + flatBonus.Magic) * percentageBonus.Magic; }
            public float max_Intelligence { get => (basis.Intelligence + flatBonus.Intelligence) * percentageBonus.Intelligence; }
            public float max_ManaRegen { get => (basis.ManaRegen + flatBonus.ManaRegen) * percentageBonus.ManaRegen; }
            public float max_Rage { get => (basis.Rage + flatBonus.Rage) * percentageBonus.Rage; }
            public float max_Attack { get => (basis.Attack + flatBonus.Attack) * percentageBonus.Attack; }
            public float max_Energy { get => (basis.Energy + flatBonus.Energy) * percentageBonus.Energy; }
            public float max_WalkSpeed { get => (basis.WalkSpeed + flatBonus.WalkSpeed) * percentageBonus.WalkSpeed; }
            public float max_RunSpeed { get => (basis.RunSpeed + flatBonus.RunSpeed) * percentageBonus.RunSpeed; }
            public float max_Dexterity { get => (basis.Dexterity + flatBonus.Dexterity) * percentageBonus.Dexterity; }
            public float max_Armor { get => (basis.Armor + flatBonus.Armor) * percentageBonus.Armor; }
            public float max_MagicResistence { get => (basis.MagicResistence + flatBonus.MagicResistence) * percentageBonus.MagicResistence; }
        }

        [System.Serializable]
        public class FlatBonus
        {
            public uint Health = 0;
            public uint Strength = 0;
            public uint HealthRegen = 0;
            public uint Mana = 0;
            public uint Magic = 0;
            public uint Intelligence = 0;
            public uint ManaRegen = 0;
            public uint Rage = 0;
            public uint Attack = 0;
            public uint Energy = 0;
            public uint WalkSpeed = 0;
            public uint RunSpeed = 0;
            public uint Dexterity = 0;
            public uint Armor = 0;
            public uint MagicResistence = 0;
        }

        [System.Serializable]
        public class Basis
        {
            public uint Health = 1000;
            public uint Strength = 0;
            public uint HealthRegen = 1;
            public uint Mana = 400;
            public uint Magic = 0;
            public uint Intelligence = 0;
            public uint ManaRegen = 1;
            public uint Rage = 1000;
            public uint Attack = 5;
            public uint Energy = 1000;
            public uint WalkSpeed = 100;
            public uint RunSpeed = 500;
            public uint Dexterity = 0;
            public uint Armor = 0;
            public uint MagicResistence = 0;
        }

        [System.Serializable]
        public class PercentageBonus
        {
            Dictionary<string, float> health = new Dictionary<string, float>();
            Dictionary<string, float> strength = new Dictionary<string, float>();
            Dictionary<string, float> healthRegen = new Dictionary<string, float>();

            Dictionary<string, float> mana = new Dictionary<string, float>();
            Dictionary<string, float> intelligence = new Dictionary<string, float>();
            Dictionary<string, float> manaRegen = new Dictionary<string, float>();
            Dictionary<string, float> magic = new Dictionary<string, float>();

            Dictionary<string, float> rage = new Dictionary<string, float>();
            Dictionary<string, float> attack = new Dictionary<string, float>();

            Dictionary<string, float> energy = new Dictionary<string, float>();
            Dictionary<string, float> walkSpeed = new Dictionary<string, float>();
            Dictionary<string, float> runSpeed = new Dictionary<string, float>();
            Dictionary<string, float> dexterity = new Dictionary<string, float>();

            Dictionary<string, float> armor = new Dictionary<string, float>();
            Dictionary<string, float> magicResistence = new Dictionary<string, float>();

            public float Health { get => concatinatePercentageBoni(health); }
            public float Strength { get => concatinatePercentageBoni(strength);}
            public float HealthRegen { get => concatinatePercentageBoni(healthRegen);}
            public float Mana { get => concatinatePercentageBoni(mana); }

            public float Magic { get => concatinatePercentageBoni(magic); }
            public float Intelligence { get => concatinatePercentageBoni(intelligence);}
            public float ManaRegen { get => concatinatePercentageBoni(manaRegen);}
            public float Rage { get => concatinatePercentageBoni(rage); }
            public float Attack { get => concatinatePercentageBoni(attack); }
            public float Energy { get => concatinatePercentageBoni(energy); }
            public float WalkSpeed { get => concatinatePercentageBoni(walkSpeed); }
            public float RunSpeed { get => concatinatePercentageBoni(runSpeed); }
            public float Dexterity { get => concatinatePercentageBoni(dexterity); }
            public float Armor { get => concatinatePercentageBoni(armor); }
            public float MagicResistence { get => concatinatePercentageBoni(magicResistence); }

            private void AddBonusIntoDict(string _BonusKey, float _Bonus, Dictionary<string, float> _Dict)
            {
                _Dict.Add(_BonusKey, _Bonus);
            }

            private void RemoveBonusFromDict(string _BonusKey, Dictionary<string, float> _Dict)
            {
                _Dict.Remove(_BonusKey);
            }

            /// <summary>
            /// Add a value from 1.0f and above for buff and a value between 0.0f and 1.0f for debuff.
            /// 0.2 == a debuff of 20% == 80% of current value
            /// 1.2 == a 20% buff == 120% of current value
            /// Adding severall buffs and debuffs scales cummulative
            /// </summary>
            /// <param name="_Type"></param>
            /// <param name="_BonusKey"></param>
            /// <param name="_Bonus"></param>
            public void AddBonus(Boni _Type, string _BonusKey, float _Bonus)
            {
                switch (_Type)
                {
                    case Boni.Health:
                        this.AddBonusIntoDict(_BonusKey, _Bonus, health);
                        break;
                    case Boni.Strength:
                        this.AddBonusIntoDict(_BonusKey, _Bonus, strength);
                        break;
                    case Boni.HealthRegen:
                        this.AddBonusIntoDict(_BonusKey, _Bonus, healthRegen);
                        break;
                    case Boni.Mana:
                        this.AddBonusIntoDict(_BonusKey, _Bonus, mana);
                        break;
                    case Boni.Magic:
                        this.AddBonusIntoDict(_BonusKey, _Bonus, magic);
                        break;
                    case Boni.Intelligence:
                        this.AddBonusIntoDict(_BonusKey, _Bonus, intelligence);
                        break;
                    case Boni.ManaRegen:
                        this.AddBonusIntoDict(_BonusKey, _Bonus, manaRegen);
                        break;
                    case Boni.Rage:
                        this.AddBonusIntoDict(_BonusKey, _Bonus, rage);
                        break;
                    case Boni.Attack:
                        this.AddBonusIntoDict(_BonusKey, _Bonus, attack);
                        break;
                    case Boni.Energy:
                        this.AddBonusIntoDict(_BonusKey, _Bonus, energy);
                        break;
                    case Boni.WalkSpeed:
                        this.AddBonusIntoDict(_BonusKey, _Bonus, walkSpeed);
                        break;
                    case Boni.RunSpeed:
                        this.AddBonusIntoDict(_BonusKey, _Bonus, runSpeed);
                        break;
                    case Boni.Dexterity:
                        this.AddBonusIntoDict(_BonusKey, _Bonus, dexterity);
                        break;
                    case Boni.Armor:
                        this.AddBonusIntoDict(_BonusKey, _Bonus, armor);
                        break;
                    case Boni.MagicResistence:
                        this.AddBonusIntoDict(_BonusKey, _Bonus, magicResistence);
                        break;
                    default:
                        break;
                }
            }

            public void RemoveBonus(Boni _Type, string _BonusKey, float _Bonus)
            {
                switch (_Type)
                {
                    case Boni.Health:
                        this.RemoveBonusFromDict(_BonusKey, health);
                        break;
                    case Boni.Strength:
                        this.RemoveBonusFromDict(_BonusKey, strength);
                        break;
                    case Boni.HealthRegen:
                        this.RemoveBonusFromDict(_BonusKey, healthRegen);
                        break;
                    case Boni.Mana:
                        this.RemoveBonusFromDict(_BonusKey, mana);
                        break;
                    case Boni.Magic:
                        this.RemoveBonusFromDict(_BonusKey, magic);
                        break;
                    case Boni.Intelligence:
                        this.RemoveBonusFromDict(_BonusKey, intelligence);
                        break;
                    case Boni.ManaRegen:
                        this.RemoveBonusFromDict(_BonusKey, manaRegen);
                        break;
                    case Boni.Rage:
                        this.RemoveBonusFromDict(_BonusKey, rage);
                        break;
                    case Boni.Attack:
                        this.RemoveBonusFromDict(_BonusKey, attack);
                        break;
                    case Boni.Energy:
                        this.RemoveBonusFromDict(_BonusKey, energy);
                        break;
                    case Boni.WalkSpeed:
                        this.RemoveBonusFromDict(_BonusKey, walkSpeed);
                        break;
                    case Boni.RunSpeed:
                        this.RemoveBonusFromDict(_BonusKey, runSpeed);
                        break;
                    case Boni.Dexterity:
                        this.RemoveBonusFromDict(_BonusKey, dexterity);
                        break;
                    case Boni.Armor:
                        this.RemoveBonusFromDict(_BonusKey, armor);
                        break;
                    case Boni.MagicResistence:
                        this.RemoveBonusFromDict(_BonusKey, magicResistence);
                        break;
                    default:
                        break;
                }
            }

            float concatinatePercentageBoni(Dictionary<string, float> _BonusValues)
            {
                float result = 1f;
                foreach (KeyValuePair<string, float> percent in _BonusValues)
                {
                    if(percent.Value < 1.0f)
                    {
                        float debuff = 1.0f - percent.Value; // 0.0f to 0.99f debuff inverted value for better usage
                        result *= debuff;
                    }
                    else
                    {
                        result *= percent.Value; // 1.0f or higher for buff
                    }
                }
                return result;
            }
        }
    }

    public class AttributesContainer : MonoBehaviour
    {
        public AttributeContainerState State = new AttributeContainerState();

        // command queue to execute dictionary
        public Queue<string> Commands = new Queue<string>();

        [Header("Active Attributes e.g.abilities and spells")]
        public AttributesDictionary AttributesActives; // active usable like walk run cast attack stuff like this
        [Header("Passive Attributes e.g. Auras/Debuffs and damage calculators")]
        public AttributesDictionary AttributesPassives; // like buffs debuffs attributes like bleeding or maybe the calculation how damage is handled
        private List<string> removalListForPassives;

        public void addActive(string key, IamAttribute _Value)
        {
            // TODO
        }

        public void addPassive(string key, IamAttribute _Value)
        {
            // TODO
        }

        public void appendCommand(string appendedCommand)
        {
            // with shift then or something
            Commands.Enqueue(appendedCommand);
        }

        public void changeCommand(string newCommand)
        {
            // a new command to clear old ones
            Commands.Clear();
            Commands.Enqueue(newCommand);
        }

        public void appendCommands(string[] appendedCommands)
        {
            // with shift then or something
            foreach (string command in appendedCommands)
            {
                Commands.Enqueue(command);
            }
        }

        public void changeCommands(string[] newCommands)
        {
            // a new command to clear old ones
            Commands.Clear();
            foreach (string command in newCommands)
            {
                Commands.Enqueue(command);
            }
        }


        void handleActives()
        {
            if (Commands.Count > 0)
            {
                AttributesActives.TryGetValue(Commands.Peek(), out IamAttribute attribute);
                AttributeState state = attribute.UpdateLogic(this);
                switch (state)
                {
                    case AttributeState.Done:
                        {
                            Commands.Dequeue();
                            break;
                        }
                    case AttributeState.InProgress:
                        {
                            break;
                        }
                    case AttributeState.Loop:
                        {
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        void handlePassives()
        {
            foreach (string attributeName in AttributesPassives.Keys)
            {
                IamAttribute temp;
                AttributesPassives.TryGetValue(attributeName, out temp);
                AttributeState state = temp.UpdateLogic(this);
                switch (state)
                {
                    case AttributeState.Done:
                        {
                            removalListForPassives.Add(attributeName);
                            break;
                        }
                    case AttributeState.InProgress:
                        {
                            break;
                        }
                    case AttributeState.Loop:
                        {
                            break;
                        }
                    default:
                        break;
                }
            }

            foreach (string name in removalListForPassives)
            {
                AttributesPassives.Remove(name);
            }
        }

        void Update()
        {
            handleActives();
            handlePassives();
        }
    }
}