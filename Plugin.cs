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
using System.Security.Cryptography;
using Utils;
using KaimiraGames;

namespace ModPageLib
{

	[Mod.SalemMod]
	class Main
	{
		public static void Start()
		{
			Debug.Log("Working?");
			//ReplaceTipText.list = FromResources.LoadString("FunFacts.resources.funfacts.txt").Split('/');
			ReplaceTipText.wlist = new(new List<WeightedListItem<string>>(){
				new("Fun Fact:", 500),
				new("<color=#87CEFA>Fun Fact:</color>", 1),
				new("Meow meow:", 1),
				new("Fun Daft:", 5),
				new("Fun Fact: Fun Fact: Fun Fact: Fun Fact: Fun Fact:", 1),
				new("Fun tcaF:", 1),
				new("(Not) Fun Fact:", 1),
				new("Scary Fact:", 1),
				new("Fun fact:", 20),
				new("fun fact:", 10),
				new("fun Fact:", 10),
				new("Did you know?", 50),
				new("Fun? Fact:", 20),
				new("Fact:", 34),
				new("Fun... Fact?", 10),
				new("FACT CHECKED BY REAL TOWN OF SALEM 2:", 1),
				new("Fun Trash", 3),
				new("asidhaudgauirhg:", 1),
			});
		}
	}

	[HarmonyPatch(typeof(TransitionOverlayController), "InitializeTipText")]
	static public class ReplaceTipText{
		//static public string[] list;
		static public WeightedList<string> wlist;
		public static bool Prefix(TransitionOverlayController __instance){
			Debug.LogWarning("Test");
			string[] list = FromResources.LoadString("FunFacts.resources.funfacts.txt").Split('/');
			int index = MiscUtils.GetSecureRandomNumber(0, list.Length);
			string text = list[index];
			__instance.TipText.SetText($"<color=yellow>{(wlist.Next())}{(UnityEngine.Random.Range(0, 1024) == 0 ? "" : "</color>")} {text}");
			__instance.TipText.gameObject.SetActive(true);
			return false;			
		}
	}
	
}
