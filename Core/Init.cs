// Decompiled with JetBrains decompiler
// Type: Core.Init
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using System.Reflection;

namespace Core
{
  public static class Init
  {
    public static void Prepare()
    {
      Config._Assembly = Assembly.GetExecutingAssembly();
      Config._Renderer.TextureManager.LoadFromResource("ArrowLeft", "Images.ArrowLeft.png", Config._Assembly);
      Config._Renderer.TextureManager.LoadFromResource("ArrowRight", "Images.ArrowRight.png", Config._Assembly);
      Config._Renderer.TextureManager.LoadFromResource("RemoteMine", "Images.RemoteMine.png", Config._Assembly);
      Config._Renderer.TextureManager.LoadFromResource("LandMine", "Images.LandMine.png", Config._Assembly);
      Config._Renderer.TextureManager.LoadFromResource("StasisMine", "Images.StasisMine.png", Config._Assembly);
      Config._Renderer.TextureManager.LoadFromResource("Detonate", "Images.Detonate.png", Config._Assembly);
      Config._Renderer.TextureManager.LoadFromDota("manta", "resource\\flash3\\images\\items\\manta.png");
      Config._Renderer.TextureManager.LoadFromDota("necronomicon", "resource\\flash3\\images\\items\\necronomicon.png");
      Config._Renderer.TextureManager.LoadFromDota("furion_treant", "resource\\flash3\\images\\spellicons\\furion_force_of_nature.png");
      Config._Renderer.TextureManager.LoadFromDota("techies_focused_detonate", "resource\\flash3\\images\\spellicons\\techies_focused_detonate.png");
      Config._Renderer.TextureManager.LoadFromDota("enigma_demonic_conversion", "resource\\flash3\\images\\spellicons\\enigma_demonic_conversion.png");
      Config._Renderer.TextureManager.LoadFromDota("KillHimself", "resource\\flash3\\images\\spellicons\\techies_suicide.png");
      Config._Renderer.TextureManager.LoadFromResource("Run", "Images.Run.png", Config._Assembly);
      Config._Renderer.TextureManager.LoadFromResource("RunRed", "Images.RunRed.png", Config._Assembly);
      Config._Renderer.TextureManager.LoadFromResource("TR_Logo", "Images.IngameLogo.png", Config._Assembly);
    }
  }
}
