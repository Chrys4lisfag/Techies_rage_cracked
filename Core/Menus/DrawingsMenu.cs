// Decompiled with JetBrains decompiler
// Type: Core.Menus.DrawingsMenu
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

namespace Core.Menus
{
  [Ensage.SDK.Menu.Menu("Drawings")]
  public class DrawingsMenu
  {
    public DrawingsMenu()
    {
      this.BombsDrawings = new BombsDrawings();
      this.InfoDrawings = new InfoDrawings();
      this.ForceDrawings = new ForceDrawings();
    }

    [Ensage.SDK.Menu.Menu("Bomb Drawings")]
    public BombsDrawings BombsDrawings { get; set; }

    [Ensage.SDK.Menu.Menu("Info Drawings")]
    public InfoDrawings InfoDrawings { get; set; }

    [Ensage.SDK.Menu.Menu("Force Drawings")]
    public ForceDrawings ForceDrawings { get; set; }
  }
}
