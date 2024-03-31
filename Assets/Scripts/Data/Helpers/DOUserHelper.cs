using CodeStage.AntiCheat.ObscuredTypes;
using System;

public class DOUserHelper 
{
    public ObscuredString UserID;
    public ObscuredString UserName;
    //public ObscuredLong UserPoints;
    public ObscuredLong Money = 0;
    public ObscuredInt Gender = (int)GenderType.Man;
    public DateTime welcomePrizeCollectedAt = DateTime.MinValue;
    public ObscuredInt Level = 1;
    public ObscuredInt Experience = 0;


    //TODO: Restriction info for user

    //TODO: Statistics for user (number of kills, etc...)

    //TODO: Gender, etc...

    //TODO: First time prize, etc...
}
