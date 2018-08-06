using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataController : MonoBehaviour {
	public HexTileCounter hexTileCounter;
	public TextMeshProUGUI goldTMPro;
	public int gold {get;set;}
	public int tileNum {get;set;}
	public int goldCostPerTurn {get;set;}
	public int goldInComePerTurn {get;set;}
	public int population {get;set;}
	public int turns{get;set;}//回合数

	void Awake(){
		gold = 500;
		tileNum = 0;
		goldCostPerTurn = 0;
		goldInComePerTurn = 0;
		population = 10000;
		turns = 1;
		goldTMPro.SetText(gold.ToString());
	}

	public void EndTurn(){
		goldCostPerTurn = hexTileCounter.GetAllTileCost();
		gold = gold - goldCostPerTurn + goldInComePerTurn;
		turns++;
		goldTMPro.SetText(gold.ToString());
	}
}
