﻿using System;
using System.Data;
using System.Configuration;

namespace BUSINESS
{
    public class Player
    {
        public static DataTable GetPlayer()
        {
            return DATA.Players.GetPlayers();
        }
        public static void AddPlayer(string Name, string LastName, decimal MoneyAccount)
        {
            DATA.Players.AddPlayer(Name, LastName, MoneyAccount);
        }

        public static void UpdatePlayer(int IdPlayer, string Name, string LastName, decimal MoneyAccount)
        {
            DATA.Players.UpdatePlayer(IdPlayer, Name, LastName, MoneyAccount);
        }

        public static void DeletePlayer(int IdPlayer)
        {
            DATA.Players.DeletePlayer(IdPlayer);
        }
        public static void CatchExceptions(Exception ex)
        {
            DATA.Players.CatchException(ex);
        }
    }
}
