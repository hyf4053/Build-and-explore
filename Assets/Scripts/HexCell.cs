using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HexCell : MonoBehaviour {

    public HexCoordinates coordinates;
    
    public RectTransform uiRect;
   //-- public Color color;

    //[SerializeField]
	public HexCell[] neighbors;

    public bool isOccupied;
    public Transform position;
    public TileType tileType;
    public bool isVisible;
    public int visionField;
    int elevation;
    public GameObject currentTile;
    public TileInfo currentInfo;
    void Awake(){
        isOccupied = false;
        visionField = 0;
        tileType = TileType.nil;//-1表明没有地形在当前网格内
        isVisible = false;
        currentInfo = null;
       // currentTile = null;
    }

    public HexCell GetNeighbor (HexDirection direction) {
		return neighbors[(int)direction];
	}

    public void SetInfo(TileInfo info){
        currentInfo = info;
        //ES3.Save<HexCell>("HexCell"+)
    }

    public void SetNeighbor (HexDirection direction, HexCell cell) {
		neighbors[(int)direction] = cell;
        cell.neighbors[(int)direction.Opposite()] = this;
	}

    public bool CheckNeighborHasTile(){
        for(int i=0;i<neighbors.Length;i++){
            try{if(neighbors[i].isOccupied){
                return true;
            }else{
                continue;
            }}catch{}
        }
        return false;
    }

    public void SetNeighborVisible(int rad){
        if(rad == 0){
            this.isVisible = true;
        }
        if(rad == 1){
            this.isVisible = true;
            for(int i = 0;i<this.neighbors.Length;i++){
                try{this.neighbors[i].isVisible = true;}catch{}
            }
        }
    }

    public void SetTileType(TileType type, HexCell cell){
        
    }

    public int Elevation {
		get {
			return elevation;
		}
		set {
			elevation = value;
            Vector3 position = transform.localPosition;
			//position.y = value * HexMetrics.elevationStep;
			transform.localPosition = position;
		}
	}
	
}
