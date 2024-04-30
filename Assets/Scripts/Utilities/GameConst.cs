using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConst
{
    public const string USER_NAME_LOGIN_KEY = "userName";
    public const string USER_PASSWORD_KEY = "password";

#if UNITY_EDITOR
    public const int minShopPerNeighbourhood = 5;
    public const int maxShopPerNeighbourhood = 7;

    public const int minTributeCollectionDuration = 150;
    public const int maxTributeCollectionDuration = 400;

    public const int minTributeCollectionAmount = 100;
    public const int maxTributeCollectionAmount = 500;
#endif
    public static readonly Dictionary<ShopeType, string> NameOfShopeCollection = new Dictionary<ShopeType, string>()
    {
        { ShopeType.Alchemist, "Alchemist`s Workshop" },
        { ShopeType.Blacksmith, "Blacksmith" },
        { ShopeType.Church, "Church" },
        { ShopeType.CropField, "CropField" },
        { ShopeType.Jwellery, "Jwellery" },
        { ShopeType.Lumbermill, "Lumbermill" },
        { ShopeType.Malthouse, "Malthouse" },
        { ShopeType.Market, "Market" },
        { ShopeType.Stables, "Stables" },
        { ShopeType.Tailor, "Tailor" },
        { ShopeType.Tannery, "Tannery" },
        { ShopeType.Tavern, "Tavern" },
        { ShopeType.Weaver, "Weaver`s Workshop" }
    };
}
