// Decompiled with JetBrains decompiler
// Type: Core.Config
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using Ensage.SDK.Handlers;
using Ensage.SDK.Renderer;
using Ensage.SDK.Renderer.Particle;
using Ensage.SDK.TargetSelector;
using NLog;
using System.Collections.Generic;
using System.Reflection;
using Core.Menus;
using TechiesRage.Models;

namespace Core
{
  public static class Config
  {
    public static ItemBindings _Items = new ItemBindings();
    public static Logger Log = LogManager.GetCurrentClassLogger();
    public static List<string> _HeroesFullNames = new List<string>();
    public static List<BombStack> _BombStacks = new List<BombStack>();
    public static List<LandStack> _LandStacks = new List<LandStack>();
    public static List<RemoteBomb> _RemoteBombs = new List<RemoteBomb>();
    public static List<StasisBomb> _StasisBombs = new List<StasisBomb>();
    public static List<LandBomb> _LandBombs = new List<LandBomb>();
    public static readonly Dictionary<Unit, double> _EnemyAttakers = new Dictionary<Unit, double>();
    public static Dictionary<string, TimeModel> _Delays = new Dictionary<string, TimeModel>();
    public static readonly string[] _BlockModiffers = new string[10]
    {
      "modifier_ember_spirit_sleight_of_fist_caster",
      "modifier_abaddon_borrowed_time",
      "modifier_shredder_timber_chain",
      "modifier_storm_spirit_ball_lightning",
      "modifier_ember_spirit_sleight_of_fist_caster_invulnerability",
      "modifier_item_combo_breaker_buff",
      "modifier_item_aeon_disk_buff",
      "modifier_eul_cyclone",
      "modifier_black_king_bar_immune",
      "modifier_skeleton_king_reincarnation_scepter_active"
    };
    public static bool _Hello = true;
    public static Assembly _Assembly;
    public static Hero _Hero;
    public static Menu _Menu;
    public static IRendererManager _Renderer;
    public static IParticleManager _ParticleManager;
    public static ITargetSelectorManager _TargetSelector;
    public static TaskHandler _EULComboTask;
    public static float _StormLastUlt;
    public static float _EmberLastUlt;
    public static string Debug;

    public static Ensage.Ability _QSpell { get; set; }

    public static Ensage.Ability _WSpell { get; set; }

    public static Ensage.Ability _ESpell { get; set; }

    public static Ensage.Ability _RSpell { get; set; }
  }
}
