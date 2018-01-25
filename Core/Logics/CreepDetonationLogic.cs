// Decompiled with JetBrains decompiler
// Type: Core.Logics.CreepDetonationLogic
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

namespace Core.Logics
{
  public static class CreepDetonationLogic
  {
    public static void OnUpdate()
    {
      foreach (BombStack bombStack in Core.Config._BombStacks.Where<BombStack>((Func<BombStack, bool>) (x => x.Creeps)))
      {
        BombStack Stack = bombStack;
        if ((double) ((IEnumerable<Unit>) EntityManager<Unit>.Entities.Where<Unit>((Func<Unit, bool>) (x =>
        {
          if (x.Team != Core.Config._Hero.Team && x.IsAlive && (x.IsVisibleToEnemies && (double) x.Distance2D(Stack._Unit, false) <= 425.0))
            return x.ClassId != ClassId.CDOTA_BaseNPC_Creep_Lane;
          return false;
        })).ToArray<Unit>()).Count<Unit>() >= (double) Core.Config._Menu.DetonationMenu.CreepMenu.CreepsLimit.Value)
        {
          Core.Config._RemoteBombs.First<RemoteBomb>((Func<RemoteBomb, bool>) (x => (Entity) x._Unit == (Entity) Stack._Unit)).Detonate();
          Core.Config.Log.Warn("Detonate Creeps");
        }
      }
      foreach (BombStack bombStack in Core.Config._BombStacks.Where<BombStack>((Func<BombStack, bool>) (x => x.Necro)))
      {
        BombStack Stack = bombStack;
        if ((double) EntityManager<Unit>.Entities.Where<Unit>((Func<Unit, bool>) (x =>
        {
          if (x.Team != Core.Config._Hero.Team && x.IsAlive && (x.IsVisibleToEnemies && x.Name.Contains("necronomicon")))
            return (double) x.Distance2D(Stack._Unit, false) <= 425.0;
          return false;
        })).ToArray<Unit>().Length >= (double) Core.Config._Menu.DetonationMenu.CreepMenu.NecroLimit.Value)
        {
          Core.Config._RemoteBombs.First<RemoteBomb>((Func<RemoteBomb, bool>) (x => (Entity) x._Unit == (Entity) Stack._Unit)).Detonate();
          Core.Config.Log.Warn("Detonate Necro");
        }
      }
      foreach (BombStack bombStack in Core.Config._BombStacks.Where<BombStack>((Func<BombStack, bool>) (x => x.Manta)))
      {
        BombStack Stack = bombStack;
        if ((double) EntityManager<Hero>.Entities.Where<Hero>((Func<Hero, bool>) (x =>
        {
          if (x.IsIllusion && x.Team != Core.Config._Hero.Team && (x.IsAlive && x.IsVisibleToEnemies) && ((double) x.Distance2D(Stack._Unit, false) <= 425.0 && x.IsControllable))
            return !x.HasModifier("modifier_vengefulspirit_command_aura_illusion");
          return false;
        })).ToArray<Hero>().Length >= (double) Core.Config._Menu.DetonationMenu.CreepMenu.MantaLimit.Value)
        {
          Core.Config._RemoteBombs.First<RemoteBomb>((Func<RemoteBomb, bool>) (x => (Entity) x._Unit == (Entity) Stack._Unit)).Detonate();
          Core.Config.Log.Warn("Detonate Manta");
        }
      }
      foreach (BombStack bombStack in Core.Config._BombStacks.Where<BombStack>((Func<BombStack, bool>) (x => x.HeroCreeps)))
      {
        BombStack Stack = bombStack;
        if (Core.Config._Menu.DetonationMenu.HeroCreepMenu.Brood && (double) EntityManager<Unit>.Entities.Where<Unit>((Func<Unit, bool>) (x =>
        {
          if (x.Team != Core.Config._Hero.Team && x.IsAlive && (x.IsVisibleToEnemies && (double) x.Distance2D(Stack._Unit, false) <= 425.0))
            return x.ClassId == ClassId.CDOTA_Unit_Broodmother_Spiderling;
          return false;
        })).ToArray<Unit>().Length >= (double) Core.Config._Menu.DetonationMenu.HeroCreepMenu.BroodLimit.Value)
        {
          RemoteBomb remoteBomb = Core.Config._RemoteBombs.First<RemoteBomb>((Func<RemoteBomb, bool>) (x => (Entity) x._Unit == (Entity) Stack._Unit));
          Core.Config.Log.Warn("Detonate CreepBrood");
          remoteBomb.Detonate();
        }
        if (Core.Config._Menu.DetonationMenu.HeroCreepMenu.Furion && (double) EntityManager<Unit>.Entities.Where<Unit>((Func<Unit, bool>) (x =>
        {
          if (x.Team != Core.Config._Hero.Team && x.IsAlive && (x.IsVisibleToEnemies && (double) x.Distance2D(Stack._Unit, false) <= 425.0))
            return x.Name == "npc_dota_furion_treant";
          return false;
        })).ToArray<Unit>().Length >= (double) Core.Config._Menu.DetonationMenu.HeroCreepMenu.FurionLimit.Value)
        {
          RemoteBomb remoteBomb = Core.Config._RemoteBombs.First<RemoteBomb>((Func<RemoteBomb, bool>) (x => (Entity) x._Unit == (Entity) Stack._Unit));
          Core.Config.Log.Warn("Detonate CreepFurion");
          remoteBomb.Detonate();
        }
        if (Core.Config._Menu.DetonationMenu.HeroCreepMenu.Enigma && (double) EntityManager<Unit>.Entities.Where<Unit>((Func<Unit, bool>) (x =>
        {
          if (x.Team != Core.Config._Hero.Team && x.IsAlive && (x.IsVisibleToEnemies && (double) x.Distance2D(Stack._Unit, false) <= 425.0))
            return x.Name.ToString().Contains("eidolon");
          return false;
        })).ToArray<Unit>().Length >= (double) Core.Config._Menu.DetonationMenu.HeroCreepMenu.EnigmaLimit.Value)
        {
          RemoteBomb remoteBomb = Core.Config._RemoteBombs.First<RemoteBomb>((Func<RemoteBomb, bool>) (x => (Entity) x._Unit == (Entity) Stack._Unit));
          Core.Config.Log.Warn("Detonate CreepEnigma");
          remoteBomb.Detonate();
        }
      }
    }
  }
}
