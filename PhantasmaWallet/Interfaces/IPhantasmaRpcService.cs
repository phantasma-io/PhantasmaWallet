﻿using Phantasma.Wallet.RpcClient.API;

namespace Phantasma.Wallet.Interfaces
{
    public interface IPhantasmaRpcService
    {
        PhantasmaGetAccount GetAccount { get; }
        PhantasmaGetAccountTransactions GetAccountTransactions { get; }
        PhantasmaGetChains GetChains { get; }
        PhantasmaGetTxConfirmations GetTxConfirmations { get; }
        PhantasmaGetTokens GetTokens { get; }
        PhantasmaSendRawTx SendRawTx { get; }
    }
}