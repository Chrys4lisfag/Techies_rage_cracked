// Decompiled with JetBrains decompiler
// Type: TechiesRage.Drawings.LandTimer
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using SharpDX;
using System;
using System.Linq;
using Core.Helpers;
using TechiesRage.Models;

namespace TechiesRage.Drawings
{
  public static class LandTimer
  {
    public static void OnDraw(object sender, EventArgs eventArgs)
    {
      if (!Core.Config._Menu.DrawingsMenu.BombsDrawings.LandBombTimer)
        return;
      foreach (LandBomb landBomb in Core.Config._LandBombs.Where<LandBomb>((Func<LandBomb, bool>) (x => x._OnVision)))
      {
        Vector2 hpbarPosition = HUDHelper.GetHPbarPosition(landBomb._Unit);
        float landBombWidth = HUDHelper.LandBombWidth;
        double num1 = 1.60000002384186 - ((double) Game.RawGameTime - (double) landBomb._VisionDate);
        float num2 = (float) (num1 / 1.60000002384186);
        float num3 = landBombWidth * num2;
        string text = Math.Round(num1, 2).ToString("0.00");
        float num4 = (float) (((double) landBombWidth - (double) Core.Config._Renderer.MessureText(text, 13f, "Calibri").X) / 2.0);
        Core.Config._Renderer.DrawFilledRectangle(new SharpDX.RectangleF(hpbarPosition.X, hpbarPosition.Y + 15f, landBombWidth, 15f), System.Drawing.Color.Black, System.Drawing.Color.DarkGray, 1f);
        Core.Config._Renderer.DrawFilledRectangle(new SharpDX.RectangleF(hpbarPosition.X, hpbarPosition.Y + 15f, (float) (int) Math.Ceiling((double) num3), 15f), System.Drawing.Color.Black, System.Drawing.Color.Green, 0.0f);
        Core.Config._Renderer.DrawText(new Vector2(hpbarPosition.X + num4, hpbarPosition.Y + 15f), text, System.Drawing.Color.Black, 13f, "Calibri");
      }
    }
  }
}
