// Decompiled with JetBrains decompiler
// Type: TechiesRage.Drawings.Info
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using Ensage.SDK.Extensions;
using Ensage.SDK.Helpers;
using Ensage.SDK.Renderer;
using SharpDX;
using System;
using System.Linq;
using Core.Helpers;

namespace TechiesRage.Drawings
{
  public static class Info
  {
    public static void OnDraw(object sender, EventArgs eventArgs)
    {
      Info.DrawOnHeroes();
      Info.DrawOnTopPanel();
    }

    public static void DrawOnHeroes()
    {
      if (!Core.Config._Menu.DrawingsMenu.InfoDrawings.InfoTop)
        return;
      foreach (Hero _Enemy in EntityManager<Hero>.Entities.Where<Hero>((Func<Hero, bool>) (x =>
      {
        if (x.Team != Core.Config._Hero.Team && !x.IsIllusion)
          return (double) x.Distance2D((Unit) Core.Config._Hero, false) <= 2000.0;
        return false;
      })))
      {
        if (!_Enemy.IsVisible || !_Enemy.IsAlive)
          break;
        Vector2 hpbarPosition = HUDHelper.GetHPbarPosition((Unit) _Enemy);
        string text = ((float) _Enemy.Health + _Enemy.HealthRegeneration - DamageManager._SuicideDemage(_Enemy)).ToString("####");
        Vector2 vector2 = Core.Config._Renderer.MessureText(text, 13f, "Calibri");
        Core.Config._Renderer.DrawText(new SharpDX.RectangleF((float) ((double) hpbarPosition.X - (double) vector2.X - 5.0), hpbarPosition.Y, vector2.X, vector2.Y), text, System.Drawing.Color.Red, RendererFontFlags.Left, 13f, "Calibri");
      }
    }

    public static void DrawOnTopPanel()
    {
      if (!Core.Config._Menu.DrawingsMenu.InfoDrawings.InfoTop)
        return;
      foreach (Hero hero in EntityManager<Hero>.Entities.Where<Hero>((Func<Hero, bool>) (x =>
      {
        if (x.Team != Core.Config._Hero.Team)
          return !x.IsIllusion;
        return false;
      })))
      {
        Vector2 vector2_1 = HUDHelper.GetTopPanelPosition(hero) + new Vector2(Core.Config._Menu.DrawingsMenu.InfoDrawings.TopX.Value, Core.Config._Menu.DrawingsMenu.InfoDrawings.TopY.Value);
        string text1 = (int) Core.Config._QSpell.Level == 0 ? "∞" : DamageManager.NeedToKillLand(hero, false).ToString() + "/" + (object) DamageManager.NeedToKillLand(hero, true);
        string text2 = (int) Core.Config._QSpell.Level == 0 ? "∞" : DamageManager.NeedToKillRemote(hero, false).ToString() + "/" + (object) DamageManager.NeedToKillRemote(hero, true);
        string text3 = (int) Core.Config._QSpell.Level == 0 ? "∞" : ((double) hero.Health - (double) DamageManager._SuicideDemage(hero) > 0.0 ? "No" : "Yes");
        Core.Config._Renderer.DrawTexture("LandMine", new SharpDX.RectangleF(vector2_1.X, vector2_1.Y, 18f, 18f), 0.0f, 1f);
        Core.Config._Renderer.DrawTexture("RemoteMine", new SharpDX.RectangleF(vector2_1.X, vector2_1.Y + 20f, 18f, 18f), 0.0f, 1f);
        Core.Config._Renderer.DrawTexture("KillHimself", new SharpDX.RectangleF(vector2_1.X, vector2_1.Y + 40f, 18f, 18f), 0.0f, 1f);
        Vector2 vector2_2 = Core.Config._Renderer.MessureText(text1, 13f, "Calibri");
        Core.Config._Renderer.DrawText(new SharpDX.RectangleF(vector2_1.X + 20f, vector2_1.Y, vector2_2.X, vector2_2.Y), text1, System.Drawing.Color.WhiteSmoke, RendererFontFlags.Left, 13f, "Calibri");
        Vector2 vector2_3 = Core.Config._Renderer.MessureText(text2, 13f, "Calibri");
        Core.Config._Renderer.DrawText(new SharpDX.RectangleF(vector2_1.X + 20f, vector2_1.Y + 18f, vector2_3.X, vector2_3.Y), text2, System.Drawing.Color.WhiteSmoke, RendererFontFlags.Left, 13f, "Calibri");
        Vector2 vector2_4 = Core.Config._Renderer.MessureText(text3, 13f, "Calibri");
        Core.Config._Renderer.DrawText(new SharpDX.RectangleF(vector2_1.X + 20f, vector2_1.Y + 36f, vector2_4.X, vector2_4.Y), text3, System.Drawing.Color.WhiteSmoke, RendererFontFlags.Left, 13f, "Calibri");
      }
    }
  }
}
