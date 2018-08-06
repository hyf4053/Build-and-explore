using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMapGenerator : MonoBehaviour {
	public HexGrid hexGrid;
	[SerializeField]
	HexGridChunk[] hexGridChunk;
	public HexMapCamera hexMapCamera;
	public HexCell hexCell;
	public HexTileCounter hexTileCounter;
	void Start(){
		hexGridChunk = hexGrid.chunks;
		//SetBaseCity();
		LoadSaveFile();
	}

	public void LoadSaveFile(){
		List<int> cellNum = new List<int>();
		HexCell cell = new HexCell();
		cellNum = ES3.Load<List<int>>("cellNum");
		for(int i=0; i<cellNum.Count;i++){
			ES3.LoadInto<HexCell>("HexCell"+cellNum[i],cell);
			LoadTileToCell(hexGrid.cells[cellNum[i]],
							   cell.currentInfo.shapeOfTile[0],
							   cell.currentInfo.shapeOfTile[1],
							   cell.currentInfo.shapeOfTile[2],
							   hexGrid.cells[cellNum[i]].transform.localPosition,
							   cell.visionField,
							   cell.currentInfo);
				hexTileCounter.SetTiletoList(cell.currentInfo);
		}


/*

		for(int i=0;i<10000;i++){
			if(ES3.KeyExists("HexCell"+i)){
				Debug.Log("Find Key: "+"HexCell"+i);
				LoadTileToCell(hexGrid.cells[i],
							   ES3.Load<HexCell>("HexCell"+i).currentInfo.shapeOfTile[0],
							   ES3.Load<HexCell>("HexCell"+i).currentInfo.shapeOfTile[1],
							   ES3.Load<HexCell>("HexCell"+i).currentInfo.shapeOfTile[2],
							   hexGrid.cells[i].transform.localPosition,
							   ES3.Load<HexCell>("HexCell"+i).visionField,
							   ES3.Load<HexCell>("HexCell"+i).currentInfo);
				hexTileCounter.SetTiletoList(ES3.Load<HexCell>("HexCell"+i).currentInfo);
							
				//hexGrid.cells[i] = hexCell;
				//Debug.Log(coordinates);
			}else{
				continue;
			}
		} */
	}


	void LoadTileToCell(HexCell cell,int collection,int tier, int index,Vector3 position,int visionRad,TileInfo info){
		hexGrid.LoadAndSetTile(cell,
							   collection,
							   tier,
							   index,
							   position,
							   visionRad,
							   info);
		hexMapCamera.AdjustPosition(cell.transform.localPosition);
	}

	public void SetBaseCity(){
		int chunk = Randomize.GetRandomInt(0,hexGridChunk.Length-1);
		int cell = Randomize.GetRandomInt(0,24);

		while(hexGridChunk[chunk].cells[cell].neighbors.Length!=6){
			Debug.Log("Try to find new tile");
			cell = Randomize.GetRandomInt(0,24);
		}
		//放置城镇中心，2,0,0
		hexGrid.SetTile(hexGridChunk[chunk].cells[cell],2,0,0,1);
		hexGridChunk[chunk].cells[cell].isVisible = true;
		hexGridChunk[chunk].cells[cell].visionField = 0;

		hexMapCamera.AdjustPosition(hexGridChunk[chunk].cells[cell].transform.localPosition);
		HexMapCamera.ValidatePostion();

		for(int i=0;i<6;i++){
			if(hexGridChunk[chunk].cells[cell].neighbors[i].tileType==(TileType)0){
				hexGrid.SetTile(hexGridChunk[chunk].cells[cell].neighbors[i],2,0,Randomize.GetRandomInt(1,4),1);
				hexGridChunk[chunk].cells[cell].neighbors[i].isVisible = true;
				hexGridChunk[chunk].cells[cell].neighbors[i].visionField = 1;
			}
		}
	}


}
