// Decompiled with JetBrains decompiler
// Type: TechiesRage.Drawings.Hello
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using SharpDX;
using System;
using Core.Helpers;

namespace TechiesRage.Drawings
{
  public static class Hello
  {
    public static void OnDraw(object sender, EventArgs eventArgs)
    {
      if (!Core.Config._Hello)
        return;
      string text = "Please read docs for Techies Rage at http://RageScript.pro";
      Vector2 position = HUDHelper.GetHPbarPosition((Unit) Core.Config._Hero) - new Vector2((float) ((double) Core.Config._Renderer.MessureText(text, 16f, "Calibri").X / 2.0 - 50.0), 80f);
      Core.Config._Renderer.DrawText(position, text, System.Drawing.Color.White, 16f, "Calibri");
    }
  }
}
