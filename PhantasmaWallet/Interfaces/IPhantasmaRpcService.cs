﻿using Phantasma.Wallet.RpcClient.API;

namespace Phantasma.Wallet.Interfaces
{
    public interface IPhantasmaRpcService
    {
        PhantasmaGetAccount GetAccount { get; }
        PhantasmaGetAccountTransactions GetAccountTransactions { get; }
        PhantasmaGetChains GetChains { get; }
        PhantasmaSendRawTx SendRawTx { get; }
    }
}