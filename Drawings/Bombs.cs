// Decompiled with JetBrains decompiler
// Type: TechiesRage.Drawings.Bombs
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using Ensage.SDK.Renderer.Particle;
using SharpDX;
using TechiesRage.Models;

namespace TechiesRage.Drawings
{
  public static class Bombs
  {
    public static void OnUpdate()
    {
      if (Core.Config._Menu.DrawingsMenu.BombsDrawings.RemoteBombRange)
      {
        foreach (RemoteBomb remoteBomb in Core.Config._RemoteBombs)
          Core.Config._ParticleManager.DrawRange(remoteBomb._Unit, remoteBomb._Unit.Handle.ToString(), 400f, Color.Bisque);
      }
      if (Core.Config._Menu.DrawingsMenu.BombsDrawings.LandBombRange)
      {
        foreach (LandBomb landBomb in Core.Config._LandBombs)
          Core.Config._ParticleManager.DrawRange(landBomb._Unit, landBomb._Unit.Handle.ToString(), 400f, landBomb.DrawingsColor());
      }
      foreach (StasisBomb stasisBomb in Core.Config._StasisBombs)
      {
        uint handle;
        if (Core.Config._Menu.DrawingsMenu.BombsDrawings.StasisBombRange)
        {
          IParticleManager particleManager = Core.Config._ParticleManager;
          Unit unit = stasisBomb._Unit;
          handle = stasisBomb._Unit.Handle;
          string id = handle.ToString();
          double num = 400.0;
          Color blue = Color.Blue;
          particleManager.DrawRange(unit, id, (float) num, blue);
        }
        if (Core.Config._Menu.DrawingsMenu.BombsDrawings.StasisBombSubRange)
        {
          IParticleManager particleManager = Core.Config._ParticleManager;
          Unit unit = stasisBomb._Unit;
          string str1 = "st";
          handle = stasisBomb._Unit.Handle;
          string str2 = handle.ToString();
          string id = str1 + str2;
          double num = 600.0;
          Color darkCyan = Color.DarkCyan;
          particleManager.DrawRange(unit, id, (float) num, darkCyan);
        }
      }
    }
  }
}
