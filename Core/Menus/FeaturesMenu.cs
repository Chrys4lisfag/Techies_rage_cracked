// Decompiled with JetBrains decompiler
// Type: Core.Menus.FeaturesMenu
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage.SDK.Menu;
using Ensage.SDK.Menu.Items;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Core.Menus
{
  [Ensage.SDK.Menu.Menu("Features")]
  public class FeaturesMenu
  {
    public bool DetonatekeyDown;

    public FeaturesMenu()
    {
      this.Detonatekey = new HotkeySelector(Key.L, new Action<MenuInputEventArgs>(this.DetonatekeyPressed), HotkeyFlags.Down | HotkeyFlags.Up);
    }

    [Item("Detonate under vision")]
    [DefaultValue(false)]
    public bool DetonateOnVision { get; set; }

    [Item("Detonate on hit")]
    [DefaultValue(false)]
    public bool DetonateOnHit { get; set; }

    [Item("Templar Ass - detonate on shiled")]
    [DefaultValue(true)]
    public bool DetonateOnTAShield { get; set; }

    [Item("Detonate on invisible")]
    [DefaultValue(false)]
    public bool DetonateOnInvisible { get; set; }

    [Item("Use old Prediction")]
    [DefaultValue(false)]
    public bool UseOldPrediction { get; set; }

    [Item("Use old Hero selctor")]
    [DefaultValue(false)]
    [Tooltip("Use this if you have problems with random detonation")]
    public bool UseOldHeroSelector { get; set; }

    [Item("Detonate key")]
    public HotkeySelector Detonatekey { get; set; }

    private void DetonatekeyPressed(MenuInputEventArgs obj)
    {
      this.DetonatekeyDown = obj.Flag == HotkeyFlags.Down;
    }
  }
}
