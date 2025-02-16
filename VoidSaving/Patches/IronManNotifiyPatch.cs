﻿using CG.GameLoopStateMachine;
using CG.GameLoopStateMachine.GameStates;
using HarmonyLib;
using VoidManager.Utilities;

namespace VoidSaving.Patches
{
    [HarmonyPatch(typeof(GSIngame), "OnEnter")]
    internal class IronManNotifiyPatch
    {
        static void Postfix(IState previous)
        {
            if (previous is GSSpawn && GameSessionManager.InHub && SaveHandler.StartedAsHost)
            {
                if (SaveHandler.IsIronManMode)
                {
                    Messaging.Notification("Iron Man for the next session is ON");
                }
            }
        }
    }
}
