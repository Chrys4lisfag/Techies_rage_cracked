// Decompiled with JetBrains decompiler
// Type: Core.Logics.DetonationLogic
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using Ensage.Common.Objects;
using Ensage.SDK.Abilities.Items;
using Ensage.SDK.Extensions;
using Ensage.SDK.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Helpers;
using TechiesRage.Models;

namespace Core.Logics
{
    public static class DetonationLogic
    {
        public static async Task OnUpdateAsync()
        {
            try
            {
                List<BombStack>.Enumerator enumerator;
                enumerator = Core.Config._BombStacks.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        BombStack _Stack = enumerator.Current;
                        if (_Stack.DetonateOnHeroes == 1)
                        {
                            if (Core.Config._Menu.Features.UseOldHeroSelector)
                            {
                                foreach (Hero _Enemy in Heroes.GetByTeam(Team.Dire == Core.Config._Hero.Team ? Team.Dire : Team.Radiant).Where<Hero>((Func<Hero, bool>)(x =>
                               {
                                   if (!x.IsIllusion && TargetChecker.PreCheck(x) && TargetChecker.CheckPos(x, _Stack))
                                       return !TargetChecker.CanCounter(x);
                                   return false;
                               })))
                                    await DetonationLogic.SingleDetonationAsync(_Enemy, _Stack);
                            }
                            else
                            {
                                foreach (Hero _Enemy in EntityManager<Hero>.Entities.Where<Hero>((Func<Hero, bool>)(x =>
                               {
                                   if (x.Team != Core.Config._Hero.Team && !x.IsIllusion && (TargetChecker.PreCheck(x) && TargetChecker.CheckPos(x, _Stack)))
                                       return !TargetChecker.CanCounter(x);
                                   return false;
                               })))
                                    await DetonationLogic.SingleDetonationAsync(_Enemy, _Stack);
                            }
                        }
                        else
                        {
                            int num2 = 0;
                            int num3 = 0;
                            List<string> stringList = new List<string>();
                            IOrderedEnumerable<RemoteBomb> orderedEnumerable = Core.Config._RemoteBombs.Where<RemoteBomb>((Func<RemoteBomb, bool>)(x => (double)x._Unit.Distance2D(_Stack._Unit, false) <= 100.0)).OrderBy<RemoteBomb, float>((Func<RemoteBomb, float>)(x => x._Unit.CreateTime));
                            if (Core.Config._Menu.Features.UseOldHeroSelector)
                            {
                                foreach (Hero hero in Heroes.GetByTeam(Team.Dire == Core.Config._Hero.Team ? Team.Dire : Team.Radiant).Where<Hero>((Func<Hero, bool>)(x =>
                               {
                                   if (!x.IsIllusion && TargetChecker.PreCheck(x) && TargetChecker.CheckPos(x, _Stack))
                                       return !TargetChecker.CanCounter(x);
                                   return false;
                               })))
                                {
                                    Hero _Enemy = hero;
                                    List<RemoteBomb> list = Core.Config._RemoteBombs.Where<RemoteBomb>((Func<RemoteBomb, bool>)(x =>
                                   {
                                       if (x.IsHit(_Enemy))
                                           return (double)x._Unit.Distance2D(_Stack._Unit, false) <= 100.0;
                                       return false;
                                   })).OrderBy<RemoteBomb, float>((Func<RemoteBomb, float>)(x => x._Unit.CreateTime)).ToList<RemoteBomb>();
                                    int kill = DamageManager.NeedToKill(_Enemy, list);
                                    if (list.Count >= kill)
                                    {
                                        if (kill > num3 && kill < 100)
                                            num3 = kill;
                                        ++num2;
                                        stringList.Add(_Enemy.Name);
                                    }
                                }
                            }
                            else
                            {
                                foreach (Hero hero in EntityManager<Hero>.Entities.Where<Hero>((Func<Hero, bool>)(x =>
                               {
                                   if (x.Team != Core.Config._Hero.Team && !x.IsIllusion && (TargetChecker.PreCheck(x) && TargetChecker.CheckPos(x, _Stack)))
                                       return !TargetChecker.CanCounter(x);
                                   return false;
                               })))
                                {
                                    Hero _Enemy = hero;
                                    List<RemoteBomb> list = Core.Config._RemoteBombs.Where<RemoteBomb>((Func<RemoteBomb, bool>)(x =>
                                   {
                                       if (x.IsHit(_Enemy))
                                           return (double)x._Unit.Distance2D(_Stack._Unit, false) <= 100.0;
                                       return false;
                                   })).OrderBy<RemoteBomb, float>((Func<RemoteBomb, float>)(x => x._Unit.CreateTime)).ToList<RemoteBomb>();
                                    int kill = DamageManager.NeedToKill(_Enemy, list);
                                    if (list.Count >= kill)
                                    {
                                        if (kill > num3 && kill < 100)
                                            num3 = kill;
                                        ++num2;
                                        stringList.Add(_Enemy.Name);
                                    }
                                }
                            }
                            if (num2 >= _Stack.DetonateOnHeroes)
                            {
                                foreach (string Name in stringList)
                                    Sleeper.Sleep(Name, 1f);
                                int num4 = 0;
                                Core.Config.Log.Warn("DetonateOnStack Multi");
                                foreach (RemoteBomb remoteBomb in (IEnumerable<RemoteBomb>)orderedEnumerable)
                                {
                                    remoteBomb.Detonate();
                                    ++num4;
                                    if (num4 >= num3)
                                        break;
                                }
                            }
                        }
                    }
                }
                finally
                {
                    enumerator.Dispose();
                }
                enumerator = new List<BombStack>.Enumerator();
            }
            catch (Exception ex)
            {
                Core.Config.Log.Error(ex.ToString());
            }
        }

        private static async Task SingleDetonationAsync(Hero _Enemy, BombStack _Stack)
        {
            int _Detonated;
            int _NtK;
            List<RemoteBomb>.Enumerator enumerator;

            List<RemoteBomb> list = Core.Config._RemoteBombs.Where<RemoteBomb>((Func<RemoteBomb, bool>)(x =>
           {
               if (x.IsHit(_Enemy))
                   return (double)x._Unit.Distance2D(_Stack._Unit, false) <= 100.0;
               return false;
           })).OrderBy<RemoteBomb, float>((Func<RemoteBomb, float>)(x => x._Unit.CreateTime)).ToList<RemoteBomb>();
            _NtK = DamageManager.NeedToKill(_Enemy, list);
            if (list.Count < _NtK)
                return;
            _Detonated = 0;
            if (Core.Config._Menu.DamageHelpersMenu.UseEtherial && Core.Config._Items.Etherial != null && (Core.Config._Items.Etherial.CanBeCasted && (double)Core.Config._Hero.Distance2D((Unit)_Enemy, false) <= (double)Core.Config._Items.Etherial.CastRange))
            {
                Core.Config._Items.Etherial.UseAbility((Unit)_Enemy);
                Sleeper.Sleep(_Enemy.Name, 0.6f);
                return;
            }
            enumerator = list.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    RemoteBomb B = enumerator.Current;
                    if (_Enemy.HasModifier("modifier_eul_cyclone"))
                    {
                        Sleeper.Sleep(_Enemy.Name, 200f);
                        break;
                    }
                    bool flag = false;
                    Item itemById = _Enemy.GetItemById(AbilityId.item_aeon_disk);
                    float num2 = (float)_Enemy.Health - (float)_Enemy.MaximumHealth * 0.8f;
                    if ((Entity)itemById != (Entity)null && (double)itemById.Cooldown == 0.0 && (double)_Enemy.Health > (double)num2)
                        flag = true;
                    if (!flag)
                    {
                        if (Core.Config._Menu.DamageHelpersMenu.UseVeil)
                        {
                            item_veil_of_discord veil = Core.Config._Items.Veil;
                            if (veil != null && veil.CanBeCasted && (double)Core.Config._Hero.Distance2D((Unit)_Enemy, false) < (double)veil.CastRange)
                            {
                                veil.UseAbility(_Enemy.Position);
                                await Task.Delay(50);
                            }
                        }
                        if (Core.Config._Menu.DamageHelpersMenu.UseDagon)
                        {
                            Item dagon = DagonManager.GetDagon();
                            if ((Entity)dagon != (Entity)null && (double)dagon.Cooldown == 0.0 && (double)Core.Config._Hero.Distance2D((Unit)_Enemy, false) < (double)dagon.CastRange)
                            {
                                dagon.UseAbility((Unit)_Enemy);
                                await Task.Delay(50);
                            }
                        }
                    }
                    if (!_Enemy.HasModifier("modifier_black_king_bar_immune"))
                    {
                        B.Detonate();
                        ++_Detonated;
                        if (_Detonated < _NtK)
                            B = (RemoteBomb)null;
                        else
                            break;
                    }
                    else
                        break;
                }
            }
            finally
            {
                enumerator.Dispose();
            }
            enumerator = new List<RemoteBomb>.Enumerator();
            Core.Config.Log.Warn("DetonateOnStack Single " + (object)_Enemy);
            Sleeper.Sleep(_Enemy.Name, 1f);
        }
    }
}
