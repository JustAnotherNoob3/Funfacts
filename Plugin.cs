using SML;
using HarmonyLib;
using System.Reflection;
using UnityEngine;
using System.Linq;
using Server.Shared.Extensions;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using SalemModLoaderUI;
using Home.Common.Tooltips;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using Home.LoginScene;
using System.Net.NetworkInformation;
using System;
using Home.Common;

namespace ModPageLib
{

	[Mod.SalemMod]
	class Main
	{
		public static void Start()
		{
			Debug.Log("Working?");
			//ReplaceTipText.list = FromResources.LoadString("FunFacts.resources.funfacts.txt").Split('/');
		}
	}

	[HarmonyPatch(typeof(TransitionOverlayController), "InitializeTipText")]
	static public class ReplaceTipText{
		//static public string[] list;
		public static bool Prefix(TransitionOverlayController __instance){
			Debug.LogWarning("Test");
			string[] list = FromResources.LoadString("FunFacts.resources.funfacts.txt").Split('/');
			int index = UnityEngine.Random.Range(0, list.Length);
			string text = list[index];
			__instance.TipText.SetText($"<color=yellow>{(UnityEngine.Random.Range(0, 11) == 0 ? "Did you know? ":"Fun Fact: ")}</color>{text}");
			__instance.TipText.gameObject.SetActive(true);
			return false;			
		}
	}
	
}
