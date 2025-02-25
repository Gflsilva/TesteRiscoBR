﻿using TesteRiscoBR.Entidates;
using TesteRiscoBR.Repository.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteRiscoBR.Repository
{
    public class TradeRepository : ITradeRepository
    {
        private const string TradesFilePath = "trades.json";
        private List<TradeEntity> trades;
        

        public TradeRepository()
        {
            LoadTrades();
        }

        public void LoadTrades()
        {
            if (File.Exists(TradesFilePath))
            {
                string json = File.ReadAllText(TradesFilePath);
                trades = JsonConvert.DeserializeObject<List<TradeEntity>>(json) ?? new List<TradeEntity>();
            }
            else
            {
                trades = new List<TradeEntity>();
            }
        }

        public void SaveTrades()
        {
            string json = JsonConvert.SerializeObject(trades, Formatting.Indented);
            File.WriteAllText(TradesFilePath, json);
        }

        public void AddTrade(TradeEntity trade)
        {
            trade.Id = trades.Count > 0 ? trades[^1].Id + 1 : 1;
            trades.Add(trade);
            SaveTrades();
        }

        public void RemoveTrades(int tradeId)
        {
            trades.RemoveAll(c => c.Id == tradeId);
            SaveTrades();
        }

        public List<TradeEntity> GetTrades()
        {
            return trades;
        }
    }
}
