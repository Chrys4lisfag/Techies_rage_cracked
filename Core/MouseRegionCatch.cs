// Decompiled with JetBrains decompiler
// Type: Core.MouseRegionCatch
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage.SDK.Extensions;
using Ensage.SDK.Input;
using SharpDX;
using Core.Helpers;
using TechiesRage.Models;

namespace Core
{
  public static class MouseRegionCatch
  {
    public static void Input_MouseClick(object sender, MouseEventArgs e)
    {
      if (e.Buttons != MouseButtons.LeftUp)
        return;
      foreach (BombStack bombStack in Config._BombStacks)
      {
        Vector2 vector2 = HUDHelper.GetHPbarPosition(bombStack._Unit) + new Vector2(-30f, -75f);
        if (e.Position.IsUnderRectangle(vector2.X + 135f, vector2.Y + 10f, 12f, 12f))
        {
          if (bombStack.DetonateOnHeroes < 5)
            ++bombStack.DetonateOnHeroes;
        }
        else if (e.Position.IsUnderRectangle(vector2.X + 99f, vector2.Y + 10f, 12f, 12f))
        {
          if (bombStack.DetonateOnHeroes > 1)
            --bombStack.DetonateOnHeroes;
        }
        else if (e.Position.IsUnderRectangle(vector2.X + 5f, vector2.Y + 30f, 28f, 28f))
          bombStack._Disabler[0] = !bombStack._Disabler[0];
        else if (e.Position.IsUnderRectangle(vector2.X + 33f, vector2.Y + 30f, 28f, 28f))
          bombStack._Disabler[1] = !bombStack._Disabler[1];
        else if (e.Position.IsUnderRectangle(vector2.X + 61f, vector2.Y + 30f, 28f, 28f))
          bombStack._Disabler[2] = !bombStack._Disabler[2];
        else if (e.Position.IsUnderRectangle(vector2.X + 89f, vector2.Y + 30f, 28f, 28f))
          bombStack._Disabler[3] = !bombStack._Disabler[3];
        else if (e.Position.IsUnderRectangle(vector2.X + 117f, vector2.Y + 30f, 28f, 28f))
          bombStack._Disabler[4] = !bombStack._Disabler[4];
        else if (e.Position.IsUnderRectangle(vector2.X + 5f, vector2.Y + 60f, 28f, 28f))
          bombStack.Necro = !bombStack.Necro;
        else if (e.Position.IsUnderRectangle(vector2.X + 30f, vector2.Y + 60f, 28f, 28f))
          bombStack.Manta = !bombStack.Manta;
        else if (e.Position.IsUnderRectangle(vector2.X + 58f, vector2.Y + 60f, 28f, 28f))
          bombStack.Creeps = !bombStack.Creeps;
        else if (e.Position.IsUnderRectangle(vector2.X + 5f, vector2.Y + 5f, 20f, 25f))
        {
          if ((double) Config._RSpell.Cooldown == 0.0)
            Config._RSpell.UseAbility(bombStack._Unit.Position);
        }
        else if (e.Position.IsUnderRectangle(vector2.X - 20f, vector2.Y + 12f, 15f, 15f))
          bombStack.MoveToStack();
        else if (e.Position.IsUnderRectangle(vector2.X - 20f, vector2.Y + 32f, 15f, 15f))
          bombStack.MoveLandToStack();
        else if (e.Position.IsUnderRectangle(vector2.X - 20f, vector2.Y + 52f, 15f, 15f))
          bombStack.HeroCreeps = !bombStack.HeroCreeps;
        if (e.Position.IsUnderRectangle(vector2.X + 91f, vector2.Y + 62f, 25f, 25f))
          bombStack.Detonate1();
        else if (e.Position.IsUnderRectangle(vector2.X + 117f, vector2.Y + 72f, 14f, 14f))
          bombStack.Detonate2();
        else if (e.Position.IsUnderRectangle(vector2.X + 134f, vector2.Y + 72f, 14f, 14f))
          bombStack.Detonate3();
      }
      foreach (LandStack landStack in Config._LandStacks)
      {
        Vector2 vector2 = HUDHelper.GetHPbarPosition(landStack._Unit) + new Vector2(20f, -45f);
        if (e.Position.IsUnderRectangle(vector2.X + 5f, vector2.Y + 32f, 23f, 23f))
          landStack.MoveToStack();
        else if (e.Position.IsUnderRectangle(vector2.X + 32f, vector2.Y + 32f, 23f, 23f))
          landStack.MoveForKill = !landStack.MoveForKill;
      }
    }
  }
}
