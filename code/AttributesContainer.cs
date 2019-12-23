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
            public Basis basis;
            public FlatBonus flatBonus;
            public PercentageBonus percentageBonus;

            public ArmorTypes ArmorType;
            public DamageTypes DamageType;

            public uint current_Health;
            public uint current_Strength;
            public uint current_HealthRegen;
            public uint current_Mana;
            public uint current_Magic;
            public uint current_Intelligence;
            public uint current_ManaRegen;
            public uint current_Rage;
            public uint current_Attack;
            public uint current_Energy;
            public uint current_WalkSpeed;
            public uint current_RunSpeed;
            public uint current_Dexterity;
            public uint current_Armor;
            public uint current_MagicResistence;

            public Stats(Basis _BasisStats, FlatBonus _FlatBoni, PercentageBonus _PercentageBoni, ArmorTypes _ArmorType, DamageTypes _DamageType)
            {
                basis = _BasisStats;
                flatBonus = _FlatBoni;
                percentageBonus = _PercentageBoni;

                ArmorType = _ArmorType;
                DamageType = _DamageType;

                this.current_Health = max_Health;
                this.current_Strength = max_Strength;
                this.current_HealthRegen = max_HealthRegen;
                this.current_Mana = max_Mana;
                this.current_Magic = max_Magic;
                this.current_Intelligence = max_Intelligence;
                this.current_ManaRegen = max_ManaRegen;
                this.current_Rage = max_Rage;
                this.current_Attack = max_Attack;
                this.current_Energy = max_Energy;
                this.current_WalkSpeed = max_WalkSpeed;
                this.current_RunSpeed = max_RunSpeed;
                this.current_Dexterity = max_Dexterity;
                this.current_Armor = max_Armor;
                this.current_MagicResistence = max_MagicResistence;
            }
            public Stats() : this(new Basis(), new FlatBonus(), new PercentageBonus(), ArmorTypes.Infantry, DamageTypes.Slash)
            {

            }

            public Stats(Basis _BasisStats, ArmorTypes _ArmorType, DamageTypes _DamageType) : this(_BasisStats, new FlatBonus(), new PercentageBonus(), _ArmorType, _DamageType)
            {

            }

            public uint max_Health { get => (uint)((basis.Health + flatBonus.Health) * percentageBonus.Health); }
            public uint max_Strength { get => (uint)((basis.Strength + flatBonus.Strength) * percentageBonus.Strength); }
            public uint max_HealthRegen { get => (uint)((basis.HealthRegen + flatBonus.HealthRegen) * percentageBonus.HealthRegen); }
            public uint max_Mana { get => (uint)((basis.Mana + flatBonus.Mana) * percentageBonus.Mana); }
            public uint max_Magic { get => (uint)((basis.Magic + flatBonus.Magic) * percentageBonus.Magic); }
            public uint max_Intelligence { get => (uint)((basis.Intelligence + flatBonus.Intelligence) * percentageBonus.Intelligence); }
            public uint max_ManaRegen { get => (uint)((basis.ManaRegen + flatBonus.ManaRegen) * percentageBonus.ManaRegen); }
            public uint max_Rage { get => (uint)((basis.Rage + flatBonus.Rage) * percentageBonus.Rage); }
            public uint max_Attack { get => (uint)((basis.Attack + flatBonus.Attack) * percentageBonus.Attack); }
            public uint max_Energy { get => (uint)((basis.Energy + flatBonus.Energy) * percentageBonus.Energy); }
            public uint max_WalkSpeed { get => (uint)((basis.WalkSpeed + flatBonus.WalkSpeed) * percentageBonus.WalkSpeed); }
            public uint max_RunSpeed { get => (uint)((basis.RunSpeed + flatBonus.RunSpeed) * percentageBonus.RunSpeed); }
            public uint max_Dexterity { get => (uint)((basis.Dexterity + flatBonus.Dexterity) * percentageBonus.Dexterity); }
            public uint max_Armor { get => (uint)((basis.Armor + flatBonus.Armor) * percentageBonus.Armor); }
            public uint max_MagicResistence { get => (uint)((basis.MagicResistence + flatBonus.MagicResistence) * percentageBonus.MagicResistence); }
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

            public Basis(uint _Health, uint _Strength, uint _HealthRegen, uint _Mana, uint _Magic,
                uint _Intelligence, uint _ManaRegen, uint _Rage, uint _Attack, uint _Energy,
                uint _WalkSpeed, uint _RunSpeed, uint _Dexterity, uint _Armor, uint _MagicResistence)
            {
                this.Health = _Health;
                this.Strength = _Strength;
                this.HealthRegen = _HealthRegen;
                this.Mana = _Mana;
                this.Magic = _Magic;
                this.Intelligence = _Intelligence;
                this.ManaRegen = _ManaRegen;
                this.Rage = _Rage;
                this.Attack = _Attack;
                this.Energy = _Energy;
                this.WalkSpeed = _WalkSpeed;
                this.RunSpeed = _RunSpeed;
                this.Dexterity = _Dexterity;
                this.Armor = _Armor;
                this.MagicResistence = _MagicResistence;
            }

            public Basis() : this(1000, 5, 0, 0, 0, 5, 0, 0, 5, 0, 200, 500, 5, 0, 0)
            {

            }

            public Basis(uint _Strength, uint _Intelligence, uint _Dexterity) : this(1000, _Strength, 0, 0, 0, _Intelligence, 0, 0, 5, 0, 200, 500, _Dexterity, 0, 0)
            {

            }
        }

        [System.Serializable]
        public class FlatBonus
        {
            Dictionary<string, int> health;
            Dictionary<string, int> strength;
            Dictionary<string, int> healthRegen;
            Dictionary<string, int> mana;
            Dictionary<string, int> magic;
            Dictionary<string, int> intelligence;
            Dictionary<string, int> manaRegen;
            Dictionary<string, int> rage;
            Dictionary<string, int> attack;
            Dictionary<string, int> energy;
            Dictionary<string, int> walkSpeed;
            Dictionary<string, int> runSpeed;
            Dictionary<string, int> dexterity;
            Dictionary<string, int> armor;
            Dictionary<string, int> magicResistence;

            public FlatBonus()
            {
                this.health = new Dictionary<string, int>();
                this.strength = new Dictionary<string, int>();
                this.healthRegen = new Dictionary<string, int>();
                this.mana = new Dictionary<string, int>();
                this.magic = new Dictionary<string, int>();
                this.intelligence = new Dictionary<string,int>();
                this.manaRegen = new Dictionary<string, int>();
                this.rage = new Dictionary<string, int>();
                this.attack = new Dictionary<string, int>();
                this.energy = new Dictionary<string, int>();
                this.walkSpeed = new Dictionary<string, int>();
                this.runSpeed = new Dictionary<string, int>();
                this.dexterity = new Dictionary<string, int>();
                this.armor = new Dictionary<string, int>();
                this.magicResistence = new Dictionary<string, int>();
            }

            public int Health { get => sumOfBoni(health); }
            public int Strength { get => sumOfBoni(strength); }
            public int HealthRegen { get => sumOfBoni(healthRegen); }
            public int Mana { get => sumOfBoni(mana); }
            public int Magic { get => sumOfBoni(magic); }
            public int Intelligence { get => sumOfBoni(intelligence); }
            public int ManaRegen { get => sumOfBoni(manaRegen); }
            public int Rage { get => sumOfBoni(rage); }
            public int Attack { get => sumOfBoni(attack); }
            public int Energy { get => sumOfBoni(energy); }
            public int WalkSpeed { get => sumOfBoni(walkSpeed); }
            public int RunSpeed { get => sumOfBoni(runSpeed); }
            public int Dexterity { get => sumOfBoni(dexterity); }
            public int Armor { get => sumOfBoni(armor); }
            public int MagicResistence { get => sumOfBoni(magicResistence); }


            int sumOfBoni(Dictionary<string, int> _BonusValues)
            {
                int result = 0;
                foreach (KeyValuePair<string, int> value in _BonusValues)
                {
                    result += value.Value;
                }
                return result;
            }
        }


        [System.Serializable]
        public class PercentageBonus
        {
            Dictionary<string, float> health;
            Dictionary<string, float> strength;
            Dictionary<string, float> healthRegen;

            Dictionary<string, float> mana;
            Dictionary<string, float> intelligence;
            Dictionary<string, float> manaRegen;
            Dictionary<string, float> magic;

            Dictionary<string, float> rage;
            Dictionary<string, float> attack;

            Dictionary<string, float> energy;
            Dictionary<string, float> walkSpeed;
            Dictionary<string, float> runSpeed;
            Dictionary<string, float> dexterity;

            Dictionary<string, float> armor;
            Dictionary<string, float> magicResistence;

            public PercentageBonus()
            {
                this.health = new Dictionary<string, float>();
                this.strength = new Dictionary<string, float>();
                this.healthRegen = new Dictionary<string, float>();
                this.mana = new Dictionary<string, float>();
                this.magic = new Dictionary<string, float>();
                this.intelligence = new Dictionary<string, float>();
                this.manaRegen = new Dictionary<string, float>();
                this.rage = new Dictionary<string, float>();
                this.attack = new Dictionary<string, float>();
                this.energy = new Dictionary<string, float>();
                this.walkSpeed = new Dictionary<string, float>();
                this.runSpeed = new Dictionary<string, float>();
                this.dexterity = new Dictionary<string, float>();
                this.armor = new Dictionary<string, float>();
                this.magicResistence = new Dictionary<string, float>();
            }

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