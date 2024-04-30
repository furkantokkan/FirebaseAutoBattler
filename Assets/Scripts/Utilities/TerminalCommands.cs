using QFSW.QC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalCommands : MonoBehaviour
{
    [Command("version")]
    public static void CommandVerion()
    {
        Debug.Log("Game Version: " + Application.version);
    }
}
