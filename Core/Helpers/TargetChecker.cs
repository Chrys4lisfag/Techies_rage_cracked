// Decompiled with JetBrains decompiler
// Type: Core.Helpers.TargetChecker
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using Ensage.SDK.Extensions;
using System.Collections.Generic;
using TechiesRage.Models;

namespace Core.Helpers
{
    public static class TargetChecker
    {
        public static bool PreCheck(Hero _Enemy)
        {
            return _Enemy.IsValid && _Enemy.Health > 1U && (_Enemy.IsVisible && _Enemy.IsAlive) && (!Sleeper.IsSleep(_Enemy.Name) && !_Enemy.HasModifiers((IEnumerable<string>)Core.Config._BlockModiffers, false) && (!_Enemy.IsMagicImmune() && !_Enemy.IsInvulnerable()));
        }

        public static bool CheckPos(Hero _Enemy, BombStack _Stack)
        {
            int num = 0;
            int index = -1;
            foreach (string heroesFullName in Core.Config._HeroesFullNames)
            {
                if (heroesFullName == _Enemy.Name)
                {
                    index = num;
                    break;
                }
                ++num;
            }
            return index != -1 && !_Stack._Disabler[index];
        }

        public static bool CanCounter(Hero _Enemy)
        {
            Item itemById1 = _Enemy.GetItemById(AbilityId.item_blink);
            float rawGameTime = Game.RawGameTime;
            if (_Enemy.ClassId == ClassId.CDOTA_Unit_Hero_Juggernaut)
            {
                Ensage.Ability abilityById = _Enemy.GetAbilityById(AbilityId.juggernaut_blade_fury);
                if ((Entity)abilityById != (Entity)null && (double)abilityById.Cooldown == 0.0 && ((double)_Enemy.Mana >= (double)abilityById.ManaCost && _Enemy.CanCastAbilities()))
                {
                    if (!Core.Config._Delays.ContainsKey("juggernaut_blade_fury"))
                    {
                        Core.Config._Delays.Add("juggernaut_blade_fury", new TimeModel()
                        {
                            AddedTime = rawGameTime,
                            Delay = 0.5f
                        });
                        return true;
                    }
                    TimeModel delay = Core.Config._Delays["juggernaut_blade_fury"];
                    if ((double)delay.AddedTime + 3.0 < (double)rawGameTime)
                    {
                        delay.AddedTime = rawGameTime;
                        return true;
                    }
                    if ((double)delay.AddedTime + (double)delay.Delay > (double)rawGameTime)
                        return true;
                }
            }
            else if (_Enemy.ClassId == ClassId.CDOTA_Unit_Hero_Riki)
            {
                Ensage.Ability abilityById = _Enemy.GetAbilityById(AbilityId.riki_tricks_of_the_trade);
                if ((Entity)abilityById != (Entity)null)
                {
                    if (abilityById.IsChanneling || abilityById.IsInAbilityPhase)
                        return true;
                    if ((double)abilityById.Cooldown == 0.0 && (double)_Enemy.Mana >= (double)abilityById.ManaCost && _Enemy.CanCastAbilities())
                    {
                        if (!Core.Config._Delays.ContainsKey("riki_tricks_of_the_trade"))
                        {
                            Core.Config._Delays.Add("riki_tricks_of_the_trade", new TimeModel()
                            {
                                AddedTime = rawGameTime,
                                Delay = 0.25f
                            });
                            return true;
                        }
                        TimeModel delay = Core.Config._Delays["riki_tricks_of_the_trade"];
                        if ((double)delay.AddedTime + 3.0 < (double)rawGameTime)
                        {
                            delay.AddedTime = rawGameTime;
                            return true;
                        }
                        if ((double)delay.AddedTime + (double)delay.Delay > (double)rawGameTime)
                            return true;
                    }
                }
            }
            else if (_Enemy.ClassId == ClassId.CDOTA_Unit_Hero_Tusk)
            {
                if ((Entity)itemById1 != (Entity)null && (double)itemById1.CooldownLength - (double)itemById1.Cooldown < 0.600000023841858 && (double)itemById1.CooldownLength - (double)itemById1.Cooldown > 0.0)
                {
                    Ensage.Ability abilityById = _Enemy.GetAbilityById(AbilityId.tusk_snowball);
                    if ((Entity)abilityById != (Entity)null)
                    {
                        if (abilityById.IsChanneling || abilityById.IsInAbilityPhase)
                            return true;
                        if ((double)abilityById.Cooldown == 0.0 && (double)_Enemy.Mana >= (double)abilityById.ManaCost && _Enemy.CanCastAbilities())
                        {
                            if (!Core.Config._Delays.ContainsKey("tusk_snowball"))
                            {
                                Core.Config._Delays.Add("tusk_snowball", new TimeModel()
                                {
                                    AddedTime = rawGameTime,
                                    Delay = 0.75f
                                });
                                return true;
                            }
                            TimeModel delay = Core.Config._Delays["tusk_snowball"];
                            if ((double)delay.AddedTime + 3.0 < (double)rawGameTime)
                            {
                                delay.AddedTime = rawGameTime;
                                return true;
                            }
                            if ((double)delay.AddedTime + (double)delay.Delay > (double)rawGameTime)
                                return true;
                        }
                    }
                }
            }
            else if (_Enemy.ClassId == ClassId.CDOTA_Unit_Hero_Phoenix)
            {
                Ensage.Ability abilityById = _Enemy.GetAbilityById(AbilityId.phoenix_supernova);
                if ((Entity)abilityById != (Entity)null)
                {
                    if (abilityById.IsChanneling || abilityById.IsInAbilityPhase)
                        return true;
                    if ((double)abilityById.Cooldown == 0.0 && (double)_Enemy.Mana >= (double)abilityById.ManaCost && _Enemy.CanCastAbilities())
                    {
                        if (!Core.Config._Delays.ContainsKey("phoenix_supernova"))
                        {
                            Core.Config._Delays.Add("phoenix_supernova", new TimeModel()
                            {
                                AddedTime = rawGameTime,
                                Delay = 0.75f
                            });
                            return true;
                        }
                        TimeModel delay = Core.Config._Delays["phoenix_supernova"];
                        if ((double)delay.AddedTime + 3.0 < (double)rawGameTime)
                        {
                            delay.AddedTime = rawGameTime;
                            return true;
                        }
                        if ((double)delay.AddedTime + (double)delay.Delay > (double)rawGameTime)
                            return true;
                    }
                }
            }
            Item itemById2 = _Enemy.GetItemById(AbilityId.item_black_king_bar);
            if ((Entity)itemById2 != (Entity)null && (double)itemById2.Cooldown == 0.0)
            {
                if (!Core.Config._Delays.ContainsKey(_Enemy.Name + "item_black_king_bar"))
                {
                    Core.Config._Delays.Add(_Enemy.Name + "item_black_king_bar", new TimeModel()
                    {
                        AddedTime = rawGameTime,
                        Delay = 0.5f
                    });
                    return true;
                }
                TimeModel delay = Core.Config._Delays[_Enemy.Name + "item_black_king_bar"];
                if ((double)delay.AddedTime + 1.0 < (double)rawGameTime)
                {
                    delay.AddedTime = rawGameTime;
                    return true;
                }
                if ((double)delay.AddedTime + (double)delay.Delay > (double)rawGameTime)
                    return true;
            }
            if ((Entity)itemById1 != (Entity)null && (double)itemById1.CooldownLength - (double)itemById1.Cooldown < 0.600000023841858 && (double)itemById1.CooldownLength - (double)itemById1.Cooldown > 0.0)
            {
                Item itemById3 = _Enemy.GetItemById(AbilityId.item_cyclone);
                if ((Entity)itemById3 != (Entity)null && (double)itemById3.Cooldown == 0.0)
                    return true;
                Item itemById4 = _Enemy.GetItemById(AbilityId.item_black_king_bar);
                if ((Entity)itemById4 != (Entity)null && (double)itemById4.Cooldown == 0.0)
                    return true;
                if (_Enemy.ClassId == ClassId.CDOTA_Unit_Hero_Puck)
                {
                    Ensage.Ability abilityById = _Enemy.GetAbilityById(AbilityId.puck_phase_shift);
                    if ((Entity)abilityById != (Entity)null && ((double)abilityById.Cooldown == 0.0 || abilityById.IsChanneling || abilityById.IsInAbilityPhase))
                        return true;
                }
                if (_Enemy.ClassId == ClassId.CDOTA_Unit_Hero_SandKing)
                {
                    Ensage.Ability abilityById = _Enemy.GetAbilityById(AbilityId.sandking_burrowstrike);
                    if ((Entity)abilityById != (Entity)null && ((double)abilityById.Cooldown == 0.0 || abilityById.IsChanneling || abilityById.IsInAbilityPhase))
                        return true;
                }
            }
            return false;
        }

        public static bool ForcePreCheck(Hero _Enemy)
        {
            return _Enemy.IsValid && _Enemy.Health > 1U && (_Enemy.IsVisible && _Enemy.IsAlive) && ((!Sleeper.IsSleep(_Enemy.Name) || !_Enemy.IsRotating()) && ((double)Core.Config._Items.Force.CastRange >= (double)Core.Config._Hero.Distance2D((Unit)_Enemy, false) && _Enemy.ClassId != ClassId.CDOTA_Unit_Hero_Bristleback)) && (!_Enemy.HasModifiers((IEnumerable<string>)Core.Config._BlockModiffers, false) && !_Enemy.IsMagicImmune() && !_Enemy.IsInvulnerable());
        }
    }
}
