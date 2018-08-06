using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum TileType{
	nil,Plain,GrassLand,Water,Hill,Island,Path,Pond,River,Mountain,
	CityCenter
}

public enum BuildingType{
	FarmLand,Pasture,Mine,Fishery,Dock,Sawmill,DatePalm,
	TownHall,Market,Guild,Monastery,Tavern,Forge,LookoutTower,Stable,Warehouse,Almshouse,
	Blacksmith,Mill,CharcoalMaker,BakeHouse,Brewery,Furrier,Carpenter,Mason,Vineyard,
	Barracks,Castle
}

public class TileInfo{
	public List<int> shapeOfTile;
	private int mainResNum,subResNum,grassMount;
	public TileType tileTypeName {get;set;}
	public int ID {get;set;}
	public int goldCost {get;set;}
	public int movePunish {get;set;}
	public int visionFieldPunish {get;set;}
	public int fertility {get;set;}
	public int mainResouceNum{
		get{
			return mainResNum;
		}
		set{
			mainResNum = value*fertility;
			//Debug.Log(value+" "+fertility);
		}
	}
	public int subResouceNum{
		get{
			return subResNum;
		}
		set{
			subResNum = value*fertility;
			//Debug.Log(value+" "+fertility);
		}
	}
	public int mineResouceNum {get;set;}
	public bool hasGrass {get;set;}
	public int GrassMount {
		get{
			return grassMount;
		}set{
			if(hasGrass){
				grassMount = value;
			}else{
				grassMount = 0;
			}
		}
	}
	//public List<string> canBuildSpecialBuilding {get;set;}
	public List<BuildingType> canBuildBuildingType{get; set;}
	public List<BuildingType> presetBuilding {get;set;}
	public bool isSpecial;
	//public int counter{get;set;}
	//public List<HexCell> cell{get;set;}

}