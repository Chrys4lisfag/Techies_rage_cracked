// Decompiled with JetBrains decompiler
// Type: Core.LandStackManager
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using Ensage.SDK.Extensions;
using SharpDX;
using System;
using System.Linq;
using TechiesRage.Models;

namespace Core
{
  public static class LandStackManager
  {
    public static void CreateNewStack()
    {
      Vector3 _Pos = Game.MousePosition;
      if (Config._LandStacks.Any<LandStack>((Func<LandStack, bool>) (x => (double) x._Unit.Distance2D(_Pos) <= 400.0)))
        return;
      LandBomb landBomb = Config._LandBombs.FirstOrDefault<LandBomb>((Func<LandBomb, bool>) (x => (double) x._Unit.Distance2D(_Pos) <= 400.0));
      if (landBomb == null)
        return;
      Config._LandStacks.Add(new LandStack(landBomb._Unit));
    }
  }
}
