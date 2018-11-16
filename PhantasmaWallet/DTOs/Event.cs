﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Phantasma.Wallet.DTOs
{
    public class Event
    {
        [JsonProperty("address")]
        public string EventAddress { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("kind")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EvtKind EvtKind { get; set; }
    }

    public enum EvtKind
    {
        ChainCreate,
        TokenCreate,
        TokenInfo,
        TokenSend,
        TokenReceive,
        TokenMint,
        TokenBurn,
        AddressRegister,
        FriendAdd,
        FriendRemove,
    }
}
