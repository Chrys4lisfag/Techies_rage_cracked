// Decompiled with JetBrains decompiler
// Type: Core.EnemyUpdater
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using Ensage.SDK.Helpers;
using System;
using System.Linq;
using TechiesRage.Drawings;

namespace Core
{
  public static class EnemyUpdater
  {
    public static void OnUpdate()
    {
      foreach (Hero hero in EntityManager<Hero>.Entities.Where<Hero>((Func<Hero, bool>) (x =>
      {
        if (x.Team != Config._Hero.Team)
          return !x.IsIllusion;
        return false;
      })))
      {
        string textureKey = hero.Name.Substring(14);
        if (!BombStack._Heroes.Contains(textureKey))
        {
          if (!Config._Renderer.TextureManager.LoadFromDota(textureKey, string.Format("resource\\flash3\\images\\heroes\\{0}.png", (object) textureKey)))
          {
            Config._Renderer.TextureManager.LoadFromDota(textureKey, "resource\\flash3\\images\\heroes\\selection\\fav_heart.png");
            BombStack._Heroes.Add(textureKey);
            Config._HeroesFullNames.Add(hero.Name);
          }
          else
          {
            BombStack._Heroes.Add(textureKey);
            Config._HeroesFullNames.Add(hero.Name);
          }
        }
      }
    }
  }
}
