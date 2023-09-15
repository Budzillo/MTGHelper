using MTGHelper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;
using MTGHelper.Models;

namespace MTGHelper.Helpers
{
    public class SettingsHelper
    {
        public static void SaveLifeCounterConfig(LifeCounterPageViewModel lifeCounterPageViewModel)
        {
            Preferences.Default.Set("player_count", lifeCounterPageViewModel.PlayerCount);
            Preferences.Default.Set("life_total", lifeCounterPageViewModel.LifeTotal);
            SavePlayerConfig(lifeCounterPageViewModel.Player1,1);
            SavePlayerConfig(lifeCounterPageViewModel.Player2,2);
            SavePlayerConfig(lifeCounterPageViewModel.Player3,3);
            SavePlayerConfig(lifeCounterPageViewModel.Player4,4);
            SavePlayerConfig(lifeCounterPageViewModel.Player5,5);
            SavePlayerConfig(lifeCounterPageViewModel.Player6,6);
        }
        public static void SavePlayerConfig(PlayerModel player,int playerIndex)
        {
            Preferences.Default.Set($"player{playerIndex}_name", player.PlayerName);
            Preferences.Default.Set($"player{playerIndex}_isEnergyVisible", player.IsEnergyCounterVisible);
            Preferences.Default.Set($"player{playerIndex}_isPoisonVisible", player.IsPoisonCounterVisible);
            Preferences.Default.Set($"player{playerIndex}_isGreen", player.IsGreen);
            Preferences.Default.Set($"player{playerIndex}_isBlue", player.IsBlue);
            Preferences.Default.Set($"player{playerIndex}_isRed", player.IsRed);
            Preferences.Default.Set($"player{playerIndex}_isWhite", player.IsWhite);
            Preferences.Default.Set($"player{playerIndex}_isBlack", player.IsBlack);
        }
        public static void LoadPlayersConfig(LifeCounterPageViewModel lifeCounterPageViewModel)
        {
            LoadPlayerConfig(lifeCounterPageViewModel.Player1, 1);
            LoadPlayerConfig(lifeCounterPageViewModel.Player2, 2);
            LoadPlayerConfig(lifeCounterPageViewModel.Player3, 3);
            LoadPlayerConfig(lifeCounterPageViewModel.Player4, 4);
            LoadPlayerConfig(lifeCounterPageViewModel.Player5, 5);
            LoadPlayerConfig(lifeCounterPageViewModel.Player6, 6);
        }
        public static void LoadPlayerConfig(PlayerModel player,int playerIndex)
        {
            player.PlayerName = Preferences.Default.Get($"player{playerIndex}_name", player.PlayerName);
            player.IsEnergyCounterVisible = Preferences.Default.Get($"player{playerIndex}_isEnergyVisible", player.IsEnergyCounterVisible);
            player.IsPoisonCounterVisible = Preferences.Default.Get($"player{playerIndex}_isPoisonVisible", player.IsPoisonCounterVisible);
            player.IsGreen = Preferences.Default.Get($"player{playerIndex}_isGreen", player.IsGreen);
            player.IsBlue = Preferences.Default.Get($"player{playerIndex}_isBlue", player.IsBlue);
            player.IsRed = Preferences.Default.Get($"player{playerIndex}_isRed", player.IsRed);
            player.IsWhite = Preferences.Default.Get($"player{playerIndex}_isWhite", player.IsWhite);
            player.IsBlack = Preferences.Default.Get($"player{playerIndex}_isBlack", player.IsBlack);
        }
        public static void LoadLifeCounterConfig(LifeCounterPageViewModel lifeCounterPageViewModel)
        {
            lifeCounterPageViewModel.PlayerCount = Preferences.Default.Get("player_count", 4);
            lifeCounterPageViewModel.LifeTotal = Preferences.Default.Get("life_total", 40);
        }
    }
}
