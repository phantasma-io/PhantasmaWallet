﻿using Newtonsoft.Json;

namespace Phantasma.Wallet.DTOs
{
    public class SendRawTx
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        public static SendRawTx FromJson(string json) => JsonConvert.DeserializeObject<SendRawTx>(json, JsonUtils.Settings);
    }
}
