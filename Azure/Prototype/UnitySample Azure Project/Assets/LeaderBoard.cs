using UnityEngine;
using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

public class LeaderBoard
{
    public string Id { get; set; }

    [JsonProperty(PropertyName="username")]
    public string UserName { get; set; }

    [JsonProperty(PropertyName = "score")]
    public int Score { get; set; }

    public override string ToString()
    {
        return UserName + " " + Score;
    }
}
