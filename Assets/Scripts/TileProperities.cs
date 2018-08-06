using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class TileProperities : MonoBehaviour {
	
	public List<int> shapeOfTile;
	public TileType tileTpye;
	public HexTileCounter hexTileCounter;
	public HexCell cell;
	public TileInfo cityCenter,plain,grassland,hill,island,nil,path,pond,river,water;
	//public List<string> canBuildPlainSpecBuilding;
	void Start(){
		hexTileCounter = GameObject.FindObjectOfType<HexTileCounter>();

		//canBuildPlainSpecBuilding.Add("FarmLand");
		//canBuildPlainSpecBuilding.Add("Pasture");
		//Debug.Log("Cell is: "+cell.coordinates);
		//cell = this.GetComponent<HexCell>();
		SetTileToDataCollection(cell);
		cell.currentTile = this.gameObject;
	}


	//根据方块类型，将方块注册到当前玩家的数据管理类中去
	public void SetTileToDataCollection(HexCell cell){
		switch(tileTpye){
			case TileType.CityCenter:
				//public TileInfo cityCenter = new TileInfo();
				GenerateCityCenterData();
				hexTileCounter.SetTiletoList(cityCenter);
				cell.SetInfo(cityCenter);
				//cell.currentInfo = cityCenter;
				//cell.currentInfo.shapeOfTile = shapeOfTile;
				//Debug.Log("City Center");
			break;
			case TileType.Plain:
				GeneratePlainData();
				hexTileCounter.SetTiletoList(plain);
				cell.SetInfo(plain);
				//cell.currentInfo = plain;
				//cell.currentInfo.shapeOfTile = shapeOfTile;
				//Debug.Log("Plain");
			break;
			case TileType.GrassLand:
				//Debug.Log("GrassLand");
			break;
			case TileType.Hill:
			 	GenerateHillData();
				hexTileCounter.SetTiletoList(hill);
				cell.SetInfo(hill);
				//Debug.Log("Hill");
			break;
			case TileType.Island:
				//Debug.Log("Island");
			break;
			case TileType.Mountain:
				//Debug.Log("Mountain");
			break;
			case TileType.nil:
				//Debug.Log("NULL");
			break;
			case TileType.Path:
				//Debug.Log("Path");
			break;
			case TileType.Pond:
				GeneratePondData();
				hexTileCounter.SetTiletoList(pond);
				cell.SetInfo(pond);
				//Debug.Log("Pond");
			break;
			case TileType.River:
				//Debug.Log("River");
			break;
			case TileType.Water:
				//Debug.Log("Water");
			break;
		}
	}

	public void GeneratePlainData(){
		plain = new TileInfo(){
			shapeOfTile = this.shapeOfTile,
			tileTypeName = TileType.Plain,
			ID = 1,
			goldCost = 1,
			movePunish=0,
			visionFieldPunish=0,
			fertility=Randomize.GetRandomInt(10,80),
			mainResouceNum=Randomize.GetRandomInt(1000,5000),
			subResouceNum = Randomize.GetRandomInt(500,2000),
			hasGrass = Randomize.GetRandomGrass(),
			GrassMount = Randomize.GetRandomInt(1000,1500),
			canBuildBuildingType = new List<BuildingType>(){BuildingType.FarmLand,BuildingType.Pasture},
			presetBuilding = new List<BuildingType>(){},
			isSpecial = false
		};
	}
	public void GenerateCityCenterData(){
		cityCenter = new TileInfo(){
			shapeOfTile = this.shapeOfTile,
			tileTypeName = TileType.CityCenter,
			ID = 2,
			goldCost = 1,
			movePunish=0,
			visionFieldPunish=0,
			fertility=Randomize.GetRandomInt(10,30),
			mainResouceNum=Randomize.GetRandomInt(500,1000),
			subResouceNum=0,
			hasGrass = false,
			GrassMount = 0,
			canBuildBuildingType = new List<BuildingType>(){},
			presetBuilding = new List<BuildingType>(){BuildingType.TownHall},
			isSpecial = true
		};
	}
	public void GenerateHillData(){
		hill = new TileInfo(){
			shapeOfTile = this.shapeOfTile,
			tileTypeName = TileType.Hill,
			ID = 3,
			goldCost = 2,
			movePunish = -2,
			visionFieldPunish = 1,
			fertility = Randomize.GetRandomInt(5,70),
			mainResouceNum = Randomize.GetRandomInt(1000,5000),
			subResouceNum = Randomize.GetRandomInt(500,2000),
			hasGrass = false,
			GrassMount = 0,
			canBuildBuildingType = new List<BuildingType>(){BuildingType.FarmLand,BuildingType.Mine,BuildingType.LookoutTower},
			presetBuilding = new List<BuildingType>(){},
			mineResouceNum = Randomize.GetRandomInt(1000,3000),
			isSpecial = false
		};
	}
	public void GeneratePondData(){
		pond = new TileInfo(){
			shapeOfTile = this.shapeOfTile,
			tileTypeName = TileType.Pond,
			ID=4,
			goldCost = 1,
			movePunish = -1,
			visionFieldPunish = 0,
			fertility = Randomize.GetRandomInt(30,80),
			mainResouceNum = Randomize.GetRandomInt(2000,8000),
			subResouceNum = Randomize.GetRandomInt(1000,2500),
			hasGrass = false,
			GrassMount = 0,
			canBuildBuildingType =  new List<BuildingType>(){BuildingType.Fishery,BuildingType.FarmLand},
			presetBuilding  =  new List<BuildingType>(){},
			isSpecial = false
		};
	}


	

}
