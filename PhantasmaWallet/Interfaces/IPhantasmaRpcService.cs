﻿using Phantasma.Wallet.RpcClient.API;

namespace Phantasma.Wallet.Interfaces
{
    public interface IPhantasmaRpcService
    {
        PhantasmaGetAccount GetAccount { get; }
        PhantasmaGetAccountTransactions GetAccountTransactions { get; }
        PhantasmaGetApplications GetApplications { get; }
        PhantasmaGetBlockByHash GetBlockByHash { get; }
        PhantasmaGetChains GetChains { get; }
        PhantasmaGetTokens GetTokens { get; }
        PhantasmaGetTxConfirmations GetTxConfirmations { get; }
        PhantasmaSendRawTx SendRawTx { get; }
    }
}