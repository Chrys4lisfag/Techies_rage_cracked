// Decompiled with JetBrains decompiler
// Type: Core.Logics.ModWatcherLogic
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using Ensage.SDK.Extensions;
using Ensage.SDK.Helpers;
using System;
using System.Linq;

namespace Core.Logics
{
  public static class ModWatcherLogic
  {
    public static void OnUpdate()
    {
      foreach (Hero unit in EntityManager<Hero>.Entities.Where<Hero>((Func<Hero, bool>) (x =>
      {
        if (x.Team != Core.Config._Hero.Team)
          return !x.IsIllusion;
        return false;
      })))
      {
        if (unit.ClassId == ClassId.CDOTA_Unit_Hero_StormSpirit)
        {
          if (unit.HasModifier("modifier_storm_spirit_ball_lightning"))
            Core.Config._StormLastUlt = Game.RawGameTime;
        }
        else if (unit.ClassId == ClassId.CDOTA_Unit_Hero_EmberSpirit && unit.HasModifier("modifier_ember_spirit_fire_remnant"))
          Core.Config._EmberLastUlt = Game.RawGameTime;
      }
    }
  }
}
