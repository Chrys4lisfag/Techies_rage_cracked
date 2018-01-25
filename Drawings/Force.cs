// Decompiled with JetBrains decompiler
// Type: TechiesRage.Drawings.Force
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using Ensage.SDK.Extensions;
using Ensage.SDK.Helpers;
using SharpDX;
using System;
using System.Linq;

namespace TechiesRage.Drawings
{
  public static class Force
  {
    public static void OnUpdate()
    {
      if (Core.Config._Menu.DrawingsMenu.ForceDrawings.FrocePath && Core.Config._Menu.DrawingsMenu.BombsDrawings.ForcePos && Core.Config._Items.Force != null)
      {
        foreach (Hero unit in EntityManager<Hero>.Entities.Where<Hero>((Func<Hero, bool>) (x =>
        {
          if (x.Team != Core.Config._Hero.Team && !x.IsIllusion && x.IsValid)
            return (double) x.Distance2D((Unit) Core.Config._Hero, false) <= 2000.0;
          return false;
        })))
        {
          Vector3 endPosition = unit.InFront(600f);
          Core.Config._ParticleManager.DrawTargetLine((Unit) unit, unit.Name + "force", endPosition, new Color?(Color.RoyalBlue));
        }
      }
      if (!Core.Config._Menu.DrawingsMenu.ForceDrawings.FroceRange || Core.Config._Items.Force == null)
        return;
      Core.Config._ParticleManager.DrawRange((Unit) Core.Config._Hero, "TR_ForceRange", Core.Config._Items.Force.CastRange, Color.RoyalBlue);
    }
  }
}
