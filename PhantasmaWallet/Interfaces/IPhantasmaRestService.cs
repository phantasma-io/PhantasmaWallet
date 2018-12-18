﻿using System.Threading.Tasks;
using Phantasma.RpcClient.DTOs;

namespace Phantasma.Wallet.Interfaces
{
    public interface IPhantasmaRestService
    {
        Task<Account> GetAccount(string address);
        Task<Block> GetBlock(string blockHash);
        Task<AccountTransactions> GetAccountTxs(string address, int amount);
    }
}