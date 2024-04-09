using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConst
{
    public const string USER_NAME_LOGIN_KEY = "userName";
    public const string USER_PASSWORD_KEY = "password";

    public static readonly Dictionary<ShopeType, string> NameOfShopeCollection = new Dictionary<ShopeType, string>()
    {
        {ShopeType.CropField, "Crop Field"},
        {ShopeType.Bakery, "Bakery"},
        {ShopeType.HuntersHut, "Hunter's Hut"},
        {ShopeType.Blacksmith, "Blacksmith"},
        {ShopeType.Market, "Market"},
        {ShopeType.Tavern, "Tavern"},
        {ShopeType.Mine, "Mine"},
        {ShopeType.Lumbermill, "Lumbermill"},
        {ShopeType.Vineyard, "Vineyard"},
        {ShopeType.Jwellery, "Jwellery"},
        {ShopeType.Tailor, "Tailor"},
    };
}
