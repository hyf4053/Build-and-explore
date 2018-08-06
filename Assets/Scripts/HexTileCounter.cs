using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTileCounter : MonoBehaviour {
	//public int totalNumOfTiles;
	public List<TileInfo> plainTileList,cityCenterList;
	public int plainTileNum,cityCenterTileNum;
	public  HexGrid hexGrid;
	//public List<string> plainSpecBuilding;
	//public List<HexCell> plainCellCollection;
	//public int sizeOfPlain;

//	HexCellCreationConverter listCellConverter = new HexCellCreationConverter();

	//public TileInfo grassLand;

	void Update(){

	}

	void Awake(){
		plainTileList = new List<TileInfo>();
		cityCenterList = new List<TileInfo>();
		//plainSpecBuilding.Add("FarmLand");
		//plainSpecBuilding.Add("Pasture");
		//GenerateCellObjectData();
	}

	void UpdateAllTileNumber(){
		plainTileNum = plainTileList.Count;
		cityCenterTileNum = cityCenterList.Count;
		//hexGrid.SaveAllCells();
		Debug.Log("Count of plain: "+plainTileList.Count+" Count of cc: "+cityCenterList.Count);
	}
	public void SetTiletoList(TileInfo tileInfo){
		switch(tileInfo.tileTypeName){
			case TileType.CityCenter:
				cityCenterList.Add(tileInfo);
				UpdateAllTileNumber();
			break;
			case TileType.Plain:
				plainTileList.Add(tileInfo);
				UpdateAllTileNumber();
			break;
			case TileType.GrassLand:
				//Debug.Log("GrassLand");
			break;
			case TileType.Hill:
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
				//Debug.Log("Pond");
			break;
			case TileType.River:
				//Debug.Log("River");
			break;
			case TileType.Water:
				//Debug.Log("Water");
			break;
		}
		//ES3.Save<List<TileInfo>>("listTile",plainTileList);
	}

	public int GetAllTileCost(){
		UpdateAllTileNumber();
		return (int)(plainTileNum*0.5f);
	}
	
	void OnApplicationQuit(){
		hexGrid.SaveAllCells();
	}

	/*
	public void GenerateCellObjectData(){
			grassLand = new TileInfo(){
			tileTypeName = "Plain",
			ID = 1,
			goldCost = 1,
			movePunish=0,
			visionFieldPunish=0,
			fertility=Randomize.GetRandomInt(10,80),
			mainResouceNum=Randomize.GetRandomInt(1000,5000),
			subResouceNum = Randomize.GetRandomInt(500,2000),
			hasGrass = Randomize.GetRandomGrass(),
			grassMount = Randomize.GetRandomInt(1000,1500),
			specialBuilding = plainSpecBuilding,
			counter = 0,
			//cell = plainCellCollection
		};
	}

	public void AssignCellToPlain(HexCell cell){
		//grassLand.cell.Add(cell);
		//sizeOfPlain = grassLand.cell.Count;
		//ES3.Save<TileInfo>("GrassLand",grassLand);
	}
	 */
}
