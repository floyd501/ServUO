using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a dragon corpse")]
    public class FrostDragon : BaseCreature
    {
        [Constructable]
        public FrostDragon() : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a frost dragon";
            Body = Utility.RandomList(12, 59);
            BaseSoundID = 362;

            Hue = Utility.RandomMinMax(1319, 1327);

            SetStr(1300, 1400);
            SetDex(100, 125);
            SetInt(600, 700);

            SetHits(2050, 2250);

            SetDamage(24, 33);

            SetDamageType(ResistanceType.Physical, 50);
            SetDamageType(ResistanceType.Cold, 50);

            SetResistance(ResistanceType.Physical, 85, 92);
            SetResistance(ResistanceType.Fire, 55, 70);
            SetResistance(ResistanceType.Cold, 85, 95);
            SetResistance(ResistanceType.Poison, 65, 70);
            SetResistance(ResistanceType.Energy, 65, 75);

            SetSkill(SkillName.EvalInt, 50, 60);
            SetSkill(SkillName.Magery, 120, 130);
            SetSkill(SkillName.MagicResist, 115, 135);
            SetSkill(SkillName.Tactics, 120, 135);
            SetSkill(SkillName.Wrestling, 120, 130);
            SetSkill(SkillName.Meditation, 1, 50);

            Fame = 25000;
            Karma = -25000;

            VirtualArmor = 60;

            Tamable = true;
            ControlSlots = 5;
            MinTameSkill = 105.0;
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.UltraRich, 2);
            AddLoot(LootPack.Gems, 8);
        }

        public override WeaponAbility GetWeaponAbility()
        {
            return WeaponAbility.BleedAttack;
        }

        public override void OnAfterTame(Mobile tamer)
        {
            Title = null;
        }

        public override bool CanAngerOnTame { get { return true; } }
        public override bool StatLossAfterTame { get { return true; } }
        public override bool ReacquireOnMovement { get { return !Controlled; } }
        public override bool AutoDispel { get { return !Controlled; } }
        public override int TreasureMapLevel { get { return 4; } }
        public override int Meat { get { return 19; } }
        public override int Hides { get { return 33; } }
        public override HideType HideType { get { return HideType.Barbed; } }
        public override int DragonBlood { get { return 8; } }
        public override FoodType FavoriteFood { get { return FoodType.Meat; } }

        public override bool HasBreath { get { return true; } } // fire breath enabled
        public override int BreathFireDamage { get { return 0; } }
        public override int BreathColdDamage { get { return 100; } }
        public override int BreathEffectHue { get { return 1264; } }

<<<<<<< HEAD
        public override int AuraBaseDamage { get { return 10; } }
        public override bool HasAura { get { return true; } }
        public override int AuraRange { get { return 10; } }
        public override int AuraFireDamage { get { return 0; } }
        public override int AuraColdDamage { get { return 100; } }
=======
        public override bool CanAreaDamage { get { return !Controlled; } }
        public override int AreaDamageRange { get { return 10; } }
        public override double AreaDamageScalar { get { return 1.0; } }
        public override double AreaDamageChance { get { return 1.0; } }
        public override TimeSpan AreaDamageDelay { get { return TimeSpan.FromSeconds(30); } }

        public override int AreaFireDamage { get { return 0; } }
        public override int AreaColdDamage { get { return 100; } }
>>>>>>> master

        public override void AreaDamageEffect(Mobile m)
        {
            m.FixedParticles(0x374A, 10, 30, 5052, Hue, 0, EffectLayer.Waist);
            m.PlaySound(0x5C6);
        }

        public FrostDragon(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}