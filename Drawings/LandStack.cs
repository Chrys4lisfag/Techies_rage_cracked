// Decompiled with JetBrains decompiler
// Type: TechiesRage.Drawings.LandStack
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using SharpDX;
using System;
using System.Collections.Generic;
using Core;
using Core.Helpers;

namespace TechiesRage.Drawings
{
  public static class LandStack
  {
    private static readonly System.Drawing.Color _BG = System.Drawing.Color.FromArgb(170, 60, 60, 60);
    private static readonly System.Drawing.Color _BG2 = System.Drawing.Color.FromArgb(200, 20, 20, 20);
    private static readonly System.Drawing.Color _BG3 = System.Drawing.Color.FromArgb(200, 50, 245, 0);
    public static List<string> _Heroes = new List<string>();

    public static void OnDraw(object sender, EventArgs eventArgs)
    {
      foreach (Models.LandStack landStack in Config._LandStacks)
      {
        Vector2 vector2_1 = HUDHelper.GetHPbarPosition(landStack._Unit) + new Vector2(20f, -45f);
        Config._Renderer.DrawFilledRectangle(new SharpDX.RectangleF(vector2_1.X, vector2_1.Y, 60f, 60f), System.Drawing.Color.Black, LandStack._BG, 2f);
        string damage = landStack.GetDamage();
        Vector2 vector2_2 = Config._Renderer.MessureText(damage, 12f, "Calibri");
        Config._Renderer.DrawText(vector2_1 + new Vector2((float) ((60.0 - (double) vector2_2.X) / 2.0), -17f), damage, System.Drawing.Color.DarkRed, 12f, "Calibri");
        Config._Renderer.DrawTexture("LandMine", new SharpDX.RectangleF(vector2_1.X + 5f, vector2_1.Y + 5f, 25f, 25f), 0.0f, 1f);
        Config._Renderer.DrawText(vector2_1 + new Vector2(30f, 2f), landStack.LandsAround(), System.Drawing.Color.WhiteSmoke, 25f, "Calibri");
        Config._Renderer.DrawTexture("Run", new SharpDX.RectangleF(vector2_1.X + 5f, vector2_1.Y + 32f, 23f, 23f), 0.0f, 1f);
        Config._Renderer.DrawFilledRectangle(new SharpDX.RectangleF(vector2_1.X + 30f, vector2_1.Y + 30f, 27f, 27f), System.Drawing.Color.Black, landStack.MoveForKill ? LandStack._BG3 : LandStack._BG2, 0.0f);
        Config._Renderer.DrawTexture("RunRed", new SharpDX.RectangleF(vector2_1.X + 32f, vector2_1.Y + 32f, 23f, 23f), 0.0f, 1f);
      }
    }

    public static void OnUpdate()
    {
      foreach (Models.LandStack landStack in Config._LandStacks)
        Config._ParticleManager.DrawRange(landStack._Unit, landStack.Id.ToString(), 100f, SharpDX.Color.Red);
    }
  }
}
