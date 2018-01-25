// Decompiled with JetBrains decompiler
// Type: Core.Menus.EULComboMenu
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage.SDK.Menu;
using Ensage.SDK.Menu.Items;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Core.Logics;

namespace Core.Menus
{
  [Ensage.SDK.Menu.Menu("EUL Combo")]
  public class EULComboMenu
  {
    public bool CombokeyDown;
    private bool Togle;

    public EULComboMenu()
    {
      this.Combokey = new HotkeySelector(Key.L, new Action<MenuInputEventArgs>(this.CombokeyPressed), HotkeyFlags.Down | HotkeyFlags.Up);
    }

    [Item("Use Remote")]
    [DefaultValue(true)]
    public bool UseRemote { get; set; }

    [Item("Use Land")]
    [DefaultValue(true)]
    public bool UseLand { get; set; }

    [Item("Combo key")]
    public HotkeySelector Combokey { get; set; }

    private void CombokeyPressed(MenuInputEventArgs obj)
    {
      this.CombokeyDown = obj.Flag == HotkeyFlags.Down;
      if (this.CombokeyDown)
      {
        if (this.Togle)
          return;
        EULComboLogic._Status = 0;
        Config._EULComboTask.RunAsync();
        this.Togle = true;
      }
      else
      {
        this.Togle = false;
        Config._EULComboTask.Cancel(false);
      }
    }
  }
}
