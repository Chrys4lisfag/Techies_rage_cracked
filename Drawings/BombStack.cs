// Decompiled with JetBrains decompiler
// Type: TechiesRage.Drawings.BombStack
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
  public static class BombStack
  {
    private static readonly System.Drawing.Color _BG = System.Drawing.Color.FromArgb(170, 60, 60, 60);
    private static readonly System.Drawing.Color _BG2 = System.Drawing.Color.FromArgb(200, 20, 20, 20);
    private static readonly System.Drawing.Color _BG3 = System.Drawing.Color.FromArgb(200, 50, 245, 0);
    public static List<string> _Heroes = new List<string>();

    public static void OnDraw(object sender, EventArgs eventArgs)
    {
      foreach (Models.BombStack bombStack in Config._BombStacks)
      {
        Vector2 vector2_1 = HUDHelper.GetHPbarPosition(bombStack._Unit) + new Vector2(-30f, -75f);
        Config._Renderer.DrawFilledRectangle(new SharpDX.RectangleF(vector2_1.X, vector2_1.Y, 150f, 90f), System.Drawing.Color.Black, BombStack._BG, 2f);
        Config._Renderer.DrawTexture("Run", new SharpDX.RectangleF(vector2_1.X - 20f, vector2_1.Y + 12f, 15f, 15f), 0.0f, 1f);
        Config._Renderer.DrawTexture("RunRed", new SharpDX.RectangleF(vector2_1.X - 20f, vector2_1.Y + 32f, 15f, 15f), 0.0f, 1f);
        Config._Renderer.DrawFilledRectangle(new SharpDX.RectangleF(vector2_1.X - 21f, vector2_1.Y + 50f, 18f, 18f), System.Drawing.Color.Black, bombStack.HeroCreeps ? BombStack._BG3 : BombStack._BG2, 0.0f);
        Config._Renderer.DrawTexture("enigma_demonic_conversion", new SharpDX.RectangleF(vector2_1.X - 19f, vector2_1.Y + 52f, 15f, 15f), 0.0f, 1f);
        string damage = bombStack.GetDamage();
        Vector2 vector2_2 = Config._Renderer.MessureText(damage, 12f, "Calibri");
        Config._Renderer.DrawText(vector2_1 + new Vector2((float) ((150.0 - (double) vector2_2.X) / 2.0), -17f), damage, System.Drawing.Color.DarkRed, 12f, "Calibri");
        Config._Renderer.DrawTexture("RemoteMine", new SharpDX.RectangleF(vector2_1.X + 5f, vector2_1.Y + 5f, 20f, 25f), 0.0f, 1f);
        Config._Renderer.DrawText(vector2_1 + new Vector2(27f, 2f), bombStack.RemotesAround(), System.Drawing.Color.WhiteSmoke, 25f, "Calibri");
        Config._Renderer.DrawTexture("LandMine", new SharpDX.RectangleF(vector2_1.X + 50f, vector2_1.Y + 5f, 25f, 25f), 0.0f, 1f);
        Config._Renderer.DrawText(vector2_1 + new Vector2(72f, 2f), bombStack.LandsAround(), System.Drawing.Color.WhiteSmoke, 25f, "Calibri");
        Config._Renderer.DrawTexture("ArrowRight", new SharpDX.RectangleF(vector2_1.X + 135f, vector2_1.Y + 10f, 12f, 12f), 0.0f, 1f);
        Config._Renderer.DrawFilledRectangle(new SharpDX.RectangleF(vector2_1.X + 113f, vector2_1.Y + 6f, 20f, 20f), System.Drawing.Color.Black, BombStack._BG2, 1f);
        Config._Renderer.DrawText(vector2_1 + new Vector2(118f, 2f), bombStack.DetonateOnHeroes.ToString(), System.Drawing.Color.WhiteSmoke, 22f, "Calibri");
        Config._Renderer.DrawTexture("ArrowLeft", new SharpDX.RectangleF(vector2_1.X + 99f, vector2_1.Y + 10f, 12f, 12f), 0.0f, 1f);
        int num = 5;
        int index = 0;
        foreach (string hero in BombStack._Heroes)
        {
          Config._Renderer.DrawFilledRectangle(new SharpDX.RectangleF(vector2_1.X + (float) num, vector2_1.Y + 30f, 28f, 28f), System.Drawing.Color.Black, bombStack._Disabler[index] ? BombStack._BG3 : BombStack._BG2, 0.0f);
          Config._Renderer.DrawTexture(hero, new SharpDX.RectangleF(vector2_1.X + 2f + (float) num, vector2_1.Y + 32f, 25f, 25f), 0.0f, 1f);
          ++index;
          num += 28;
        }
        Config._Renderer.DrawFilledRectangle(new SharpDX.RectangleF(vector2_1.X + 5f, vector2_1.Y + 60f, 28f, 28f), System.Drawing.Color.Black, bombStack.Necro ? BombStack._BG3 : BombStack._BG2, 0.0f);
        Config._Renderer.DrawTexture("necronomicon", new SharpDX.RectangleF(vector2_1.X + 8f, vector2_1.Y + 62f, 24f, 25f), 0.0f, 1f);
        Config._Renderer.DrawFilledRectangle(new SharpDX.RectangleF(vector2_1.X + 33f, vector2_1.Y + 60f, 28f, 28f), System.Drawing.Color.Black, bombStack.Manta ? BombStack._BG3 : BombStack._BG2, 0.0f);
        Config._Renderer.DrawTexture("manta", new SharpDX.RectangleF(vector2_1.X + 36f, vector2_1.Y + 62f, 24f, 25f), 0.0f, 1f);
        Config._Renderer.DrawFilledRectangle(new SharpDX.RectangleF(vector2_1.X + 61f, vector2_1.Y + 60f, 28f, 28f), System.Drawing.Color.Black, bombStack.Creeps ? BombStack._BG3 : BombStack._BG2, 0.0f);
        Config._Renderer.DrawTexture("furion_treant", new SharpDX.RectangleF(vector2_1.X + 64f, vector2_1.Y + 62f, 24f, 25f), 0.0f, 1f);
        Config._Renderer.DrawTexture("Detonate", new SharpDX.RectangleF(vector2_1.X + 91f, vector2_1.Y + 62f, 25f, 25f), 0.0f, 1f);
        Config._Renderer.DrawTexture("Detonate", new SharpDX.RectangleF(vector2_1.X + 117f, vector2_1.Y + 72f, 14f, 14f), 0.0f, 1f);
        Config._Renderer.DrawTexture("Detonate", new SharpDX.RectangleF(vector2_1.X + 134f, vector2_1.Y + 72f, 14f, 14f), 0.0f, 1f);
      }
    }

    public static void OnUpdate()
    {
      foreach (Models.BombStack bombStack in Config._BombStacks)
        Config._ParticleManager.DrawRange(bombStack._Unit, bombStack.Id.ToString(), 100f, SharpDX.Color.Red);
    }
  }
}
