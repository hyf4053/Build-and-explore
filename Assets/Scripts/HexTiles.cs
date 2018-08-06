using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HexTiles : MonoBehaviour {

	  //public Transform[] tilePrefabs;
	  																	//↓这个是地图生成时所使用的地块集合，后面不再会从中间调用，第一位的城镇中心只能在这里被调用
																		//大组是玩家初始选择的势力类型
	public HexTileCollection[] tileCollection,functionalTileCollection,mapGenerateTileCollection;
	[SerializeField]
	HexTileCollection[][] Collections = new HexTileCollection[3][];
	//public GameObject instance;

	//public HexCell cell;
	
	Transform container;

	void Awake(){
		container = new GameObject("TileMap Container").transform;
		container.SetParent(transform,false);
		Collections.SetValue(tileCollection,0);
		Collections.SetValue(functionalTileCollection,1);
		Collections.SetValue(mapGenerateTileCollection,2);
	}
	
	public bool SetTileToCell(int collection,int tier, int index, Vector3 position, HexCell cell,int visionRad,TileInfo info){
		HexTileCollection[] localCollection = Collections[collection];
			if(!cell.isOccupied&&cell.tileType==TileType.nil){
				GameObject instance = Instantiate(localCollection[tier].Pick(index));
				instance.transform.localPosition = position;
				instance.transform.SetParent(container,false);
				instance.GetComponent<TileProperities>().cell = cell;
				instance.GetComponent<TileProperities>().shapeOfTile = new List<int>(){collection,tier,index};
				switch(info.tileTypeName){
					case TileType.CityCenter:
						instance.GetComponent<TileProperities>().cityCenter = info;
					break;
					case TileType.Plain:
						instance.GetComponent<TileProperities>().plain = info;
					break;
				}
		//		NetworkServer.Spawn(instance);1111111111111111111111111111
				cell.isOccupied=true;
				cell.tileType = instance.GetComponent<TileProperities>().tileTpye;
				cell.SetNeighborVisible(visionRad);
				return true;
			}else{
				Debug.Log("Invalid Position");
				return false;
		  }
	}


	public bool SetTileToCell(int collection,int tier, int index, Vector3 position, HexCell cell,int visionRad){

		if(cell.isVisible&&cell.CheckNeighborHasTile()){
			HexTileCollection[] localCollection = Collections[collection];
			if(!cell.isOccupied&&cell.tileType==TileType.nil){
				GameObject instance = Instantiate(localCollection[tier].Pick(index));
				instance.transform.localPosition = position;
				instance.transform.SetParent(container,false);
				instance.GetComponent<TileProperities>().cell = cell;
				instance.GetComponent<TileProperities>().shapeOfTile = new List<int>(){collection,tier,index};
		//		NetworkServer.Spawn(instance);1111111111111111111111111111
				cell.isOccupied=true;
				cell.tileType = instance.GetComponent<TileProperities>().tileTpye;
				cell.SetNeighborVisible(visionRad);

				//ES3.Save<HexCell>()
				//this.cell = cell;
				return true;
			}else{
				Debug.Log("Invalid Position");
				return false;
		  }
		}else{
			Debug.Log("You cannot set tile to unseen grid and tile need next to your own tile");
			return false;
		}

	}

	public bool InitTileSpawn(int collection,int tier, int index, Vector3 position, HexCell cell,int visionRad){
		HexTileCollection[] localCollection = Collections[collection];
			if(!cell.isOccupied&&cell.tileType==TileType.nil){
				GameObject instance = Instantiate(localCollection[tier].Pick(index));
				instance.transform.localPosition = position;
				instance.transform.SetParent(container,false);
				instance.GetComponent<TileProperities>().cell = cell;
				instance.GetComponent<TileProperities>().shapeOfTile = new List<int>(){collection,tier,index};
		//		NetworkServer.Spawn(instance);1111111111111111111111111111
				cell.isOccupied=true;
				cell.tileType = instance.GetComponent<TileProperities>().tileTpye;
				cell.SetNeighborVisible(visionRad);
				//cell.currentInfo = instance.GetComponent<TileInfo>().
				//Debug.Log(cell.currentInfo);
				return true;
			}else{
				Debug.Log("Invalid Position");
				return false;
		  }
	}
	/*
	public void SetTileToLocationFromTileCollection(int tier,int i, Vector3 position, HexCell cell){
		  if(!cell.isOccupied&&cell.tileType==TileTpye.nil){
			  Transform instance = Instantiate(tileCollection[tier].Pick(i));
			  instance.localPosition = position;
			  instance.SetParent(container,false);
			  cell.isOccupied=true;
			  cell.tileType = TileTpye.GrassLand;
		  }else{
			  Debug.Log("Invalid Position");
			  return;
		  }
	}

	public void SetTileToLocationFromFunctionalTileCollection(int tier,int i, Vector3 position, HexCell cell){
		  if(!cell.isOccupied&&cell.tileType==TileTpye.nil){
			  Transform instance = Instantiate(functionalTileCollection[tier].Pick(i));
			  instance.localPosition = position;
			  instance.SetParent(container,false);
			  cell.isOccupied=true;
			  cell.tileType = TileTpye.CityCenter;
		  }else{
			  Debug.Log("Invalid Position");
			  return;
		  }
	}



	public Transform SelectTileFromTileCollection(int tier,int index){
		Transform instance = Instantiate(tileCollection[tier].Pick(index));
		return instance;
	}

 */

}
