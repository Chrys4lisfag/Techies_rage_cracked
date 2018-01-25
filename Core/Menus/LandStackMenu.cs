// Decompiled with JetBrains decompiler
// Type: Core.Menus.LandStackMenu
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage.SDK.Menu;
using Ensage.SDK.Menu.Items;
using System;
using System.Windows.Input;

namespace Core.Menus
{
  [Ensage.SDK.Menu.Menu("Land Stacks")]
  public class LandStackMenu
  {
    public LandStackMenu()
    {
      this.PlaceKey = new HotkeySelector(Key.K, new Action<MenuInputEventArgs>(this.PlaceKeyPressed), HotkeyFlags.Up);
    }

    [Item("Stack Key")]
    public HotkeySelector PlaceKey { get; set; }

    private void PlaceKeyPressed(MenuInputEventArgs obj)
    {
      LandStackManager.CreateNewStack();
    }

    [Item("Run for kill?")]
    public bool RunKill { get; set; }
  }
}
