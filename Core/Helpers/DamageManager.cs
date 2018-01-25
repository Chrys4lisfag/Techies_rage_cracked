// Decompiled with JetBrains decompiler
// Type: Core.Helpers.DamageManager
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using Ensage.SDK.Extensions;
using Ensage.SDK.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using TechiesRage.Models;

namespace Core.Helpers
{
  public static class DamageManager
  {
    private static readonly string[] IgnoreModifiers = new string[6]
    {
      "modifier_templar_assassin_refraction_absorb",
      "modifier_item_blade_mail_reflect",
      "modifier_item_lotus_orb_active",
      "modifier_nyx_assassin_spiked_carapace",
      "modifier_medusa_stone_gaze_stone",
      "modifier_winter_wyvern_winters_curse"
    };

    public static float _LandDemage()
    {
      return Core.Config._QSpell.GetAbilitySpecialData("damage", Core.Config._QSpell.Level);
    }

    public static float _LandDemage(Hero _Enemy)
    {
      return DamageManager._LandDemage() * (1f - Core.Config._QSpell.GetDamageReduction((Unit) _Enemy));
    }

    public static float _RemoteDemage(Hero _Enemy)
    {
      return (float) (((double) Core.Config._QSpell.GetAbilitySpecialData("damage", Core.Config._RSpell.Level) + (Core.Config._Hero.HasAghanimsScepter() ? 150.0 : 0.0)) * (1.0 - (double) Core.Config._RSpell.GetDamageReduction((Unit) _Enemy)));
    }

    public static float _SuicideDemage(Hero _Enemy)
    {
      return Core.Config._ESpell.GetAbilitySpecialData("damage", Core.Config._WSpell.Level) * (1f - Core.Config._WSpell.GetDamageReduction((Unit) _Enemy, DamageType.Magical));
    }

    public static int NeedToKillLand(Hero _Enemy, bool MaxHp = false)
    {
      return (int) Math.Ceiling((MaxHp ? (double) _Enemy.MaximumHealth : (double) _Enemy.Health + (double) _Enemy.HealthRegeneration * 2.0) / (double) DamageManager._LandDemage(_Enemy));
    }

    public static int NeedToKillRemote(Hero _Enemy, bool MaxHp = false)
    {
      return (int) Math.Ceiling((MaxHp ? (double) _Enemy.MaximumHealth : (double) _Enemy.Health + (double) _Enemy.HealthRegeneration * 2.0) / (double) DamageManager._RemoteDemage(_Enemy));
    }

    public static int NeedToKill(Hero _Enemy, List<RemoteBomb> _Bombs)
    {
      if (_Enemy.ClassId == ClassId.CDOTA_Unit_Hero_StormSpirit)
      {
        if ((double) Core.Config._StormLastUlt + 0.6 > (double) Game.RawGameTime)
          return 100;
      }
      else if (_Enemy.ClassId == ClassId.CDOTA_Unit_Hero_EmberSpirit && (double) Core.Config._EmberLastUlt + 0.6 > (double) Game.RawGameTime)
        return 100;
      float num1 = Core.Config._RSpell.GetDamageReduction((Unit) _Enemy);
      if (Core.Config._Menu.DamageHelpersMenu.UseVeil && Core.Config._Items.Veil != null && (Core.Config._Items.Veil.CanBeCasted && (double) Core.Config._Hero.Distance2D((Unit) _Enemy, false) < (double) Core.Config._Items.Veil.CastRange))
        num1 = (float) (1.0 - (1.0 - (double) num1) * 1.25);
      float _Ab = 1f - num1;
      if (_Enemy.ClassId == ClassId.CDOTA_Unit_Hero_Bristleback && (Entity) _Enemy.GetAbilityById(AbilityId.bristleback_bristleback) != (Entity) null && ((double) _Enemy.FindRotationAngle(_Bombs.First<RemoteBomb>()._Unit.Position) > 0.35 || _Enemy.IsRotating()))
        return 100;
      float _Health = (float) _Enemy.Health + _Enemy.HealthRegeneration * 1.5f;
      Item itemById1 = _Enemy.GetItemById(AbilityId.item_infused_raindrop);
      if ((Entity) itemById1 != (Entity) null && (double) itemById1.Cooldown == 0.0)
        _Health += 90f;
      Item itemById2 = _Enemy.GetItemById(AbilityId.item_aeon_disk);
      float num2 = _Health - (float) _Enemy.MaximumHealth * 0.8f;
      bool flag = false;
      if ((Entity) itemById2 != (Entity) null && (double) itemById2.Cooldown == 0.0 && (double) _Health > (double) num2)
      {
        _Health = num2;
        flag = true;
      }
      if (_Enemy.HasModifier("modifier_abaddon_aphotic_shield"))
        _Health += 200f;
      if (_Enemy.HasModifier("modifier_abaddon_borrowed_time_passive"))
        _Health -= 350f;
      if (_Enemy.ClassId == ClassId.CDOTA_Unit_Hero_Huskar)
        return DamageManager.NeedToKillHuskar(_Enemy, _Bombs);
      if (_Enemy.ClassId == ClassId.CDOTA_Unit_Hero_Spectre)
      {
        uint level = _Enemy.GetAbilityById(AbilityId.spectre_dispersion).Level;
        if (level > 0U)
        {
          switch (level)
          {
            case 1:
              _Health *= 1.1111f;
              break;
            case 2:
              _Health *= 1.1628f;
              break;
            case 3:
              _Health *= 1.2195f;
              break;
            case 4:
              _Health *= 1.2821f;
              break;
          }
        }
      }
      if (_Enemy.ClassId == ClassId.CDOTA_Unit_Hero_Medusa)
        return DamageManager.NeedToKillMedusa(_Enemy, _Bombs, _Ab);
      if (_Enemy.HasModifier("modifier_visage_gravekeepers_cloak"))
        return DamageManager.NeedToKillVisage(_Enemy, _Bombs);
      Modifier modifierByName = _Enemy.GetModifierByName("modifier_templar_assassin_refraction_absorb");
      int num3 = modifierByName != null ? modifierByName.StackCount : 0;
      if (num3 > 0 && !Core.Config._Menu.Features.DetonateOnTAShield)
        return 100;
      if (!flag)
        DamageManager.UseDagon(_Enemy, _Ab, ref _Health);
      int num4 = 0;
      if (!_Bombs.Any<RemoteBomb>())
        num4 = 100;
      foreach (RemoteBomb remoteBomb in (IEnumerable<RemoteBomb>) _Bombs.OrderBy<RemoteBomb, float>((Func<RemoteBomb, float>) (x => x._Damage)))
      {
        if ((double) _Health > 0.0)
        {
          _Health -= remoteBomb._Damage * _Ab;
          ++num4;
        }
        else
          break;
      }
      if ((double) _Health > 0.0)
        num4 = 100;
      return num4 + num3;
    }

    private static int NeedToKillHuskar(Hero _Enemy, List<RemoteBomb> _Bomds)
    {
      int num1 = 0;
      Stack<RemoteBomb> source = new Stack<RemoteBomb>((IEnumerable<RemoteBomb>) _Bomds.OrderBy<RemoteBomb, float>((Func<RemoteBomb, float>) (x => x._Damage)));
      float num2 = (float) _Enemy.MaximumHealth * 0.87f;
      long health = (long) _Enemy.Health;
      while ((double) health > (double) num2)
      {
        if (!source.Any<RemoteBomb>())
          return 100;
        health -= (long) (uint) ((double) source.Pop()._Damage * 0.75);
        ++num1;
      }
      float num3 = 0.035714f;
      while (health > 0L)
      {
        if (!source.Any<RemoteBomb>())
          return 100;
        int num4 = 14 - (int) Math.Ceiling((double) health / (double) _Enemy.MaximumHealth / 7.0 * 100.0);
        double num5 = 0.75 * (1.0 - (double) num3 * (double) num4);
        double a = (double) source.Pop()._Damage * num5;
        health -= (long) (uint) Math.Ceiling(a);
        ++num1;
      }
      return num1;
    }

    private static int NeedToKillVisage(Hero _Enemy, List<RemoteBomb> _Bomds)
    {
      int num1 = 0;
      Stack<RemoteBomb> source = new Stack<RemoteBomb>((IEnumerable<RemoteBomb>) _Bomds.OrderBy<RemoteBomb, float>((Func<RemoteBomb, float>) (x => x._Damage)));
      long health = (long) _Enemy.Health;
      float num2 = 0.035714f;
      while (health > 0L)
      {
        if (!source.Any<RemoteBomb>())
          return 100;
        int num3 = 14 - (int) Math.Ceiling((double) health / (double) _Enemy.MaximumHealth / 7.0 * 100.0);
        double num4 = 0.75 * (1.0 - (double) num2 * (double) num3);
        health -= (long) (uint) Math.Ceiling((double) source.Pop()._Damage * num4);
        ++num1;
      }
      return num1;
    }

    private static int NeedToKillMedusa(Hero _Enemy, List<RemoteBomb> _Bomds, float _Ab)
    {
      float num1 = 0.0f;
      Ensage.Ability abilityById = _Enemy.GetAbilityById(AbilityId.medusa_mana_shield);
      if (abilityById.IsToggled)
        num1 = abilityById.GetAbilitySpecialData("damage_per_mana", 0U);
      float _Health = (float) _Enemy.Health;
      if ((double) num1 > 0.0)
      {
        float num2 = _Enemy.Mana * num1;
        float num3 = (float) (_Enemy.Health / 40U * 60U);
        _Health = (double) num3 <= (double) num2 ? num3 + (float) _Enemy.Health : num2 + (float) _Enemy.Health;
      }
      int num4 = 0;
      Stack<RemoteBomb> source = new Stack<RemoteBomb>((IEnumerable<RemoteBomb>) _Bomds.OrderBy<RemoteBomb, float>((Func<RemoteBomb, float>) (x => x._Damage)));
      DamageManager.UseDagon(_Enemy, _Ab, ref _Health);
      while ((double) _Health > 0.0)
      {
        if (!source.Any<RemoteBomb>())
          return 100;
        _Health -= source.Pop()._Damage;
        ++num4;
      }
      return num4;
    }

    private static void UseDagon(Hero _Enemy, float _Ab, ref float _Health)
    {
      if (!Core.Config._Menu.DamageHelpersMenu.UseDagon)
        return;
      Item dagon = DagonManager.GetDagon();
      if (!((Entity) dagon != (Entity) null) || (double) dagon.Cooldown != 0.0 || (double) Core.Config._Hero.Distance2D((Unit) _Enemy, false) >= (double) dagon.CastRange)
        return;
      float num = DamageManager.GotDamage((Unit) _Enemy, dagon);
      if ((double) num <= 0.0)
        return;
      _Health -= num * _Ab;
    }

    private static float GotDamage(Unit _Enemy, Item _Dagon)
    {
      IEnumerable<Modifier> modifiers = _Enemy.Modifiers;
      Func<Modifier, bool> func = x => ((IEnumerable<string>)IgnoreModifiers).Any(new Func<string, bool>(x.Name.Equals));
      if (modifiers.Any(func))
        return 0.0f;
      return _Dagon.GetAbilitySpecialData("damage", 0U) * (1f - _Dagon.GetDamageReduction(_Enemy));
    }
  }
}
