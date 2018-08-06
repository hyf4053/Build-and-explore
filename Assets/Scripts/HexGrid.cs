using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour {

	//public int width = 6;
	//public int height = 6;
	public int chunkCountX = 4, chunkCountZ = 3;
	int cellCountX, cellCountZ;
	public HexCell cellPrefab;
	public HexCell[] cells;
	public HexGridChunk[] chunks;
	public Text cellLabelPrefab;
	//Canvas gridCanvas;
	//HexMesh hexMesh;
	public HexTiles hexTiles;
	public HexGridChunk chunkPrefab;
	public Color defaultColor = Color.white;
	public Color touchedColor = Color.magenta;
	public HexCell currentSelectedCell;
	public List<int> cellNum;

	void Start () {
	//	hexMesh.Triangulate(cells);
	}

	void Awake () {
		//gridCanvas = GetComponentInChildren<Canvas>();
	//	hexMesh = GetComponentInChildren<HexMesh>();
	//	gridCanvas = GetComponentInChildren<Canvas>();
		currentSelectedCell = null;
		cellNum = new List<int>();
		cellCountX = chunkCountX * HexMetrics.chunkSizeX;
		cellCountZ = chunkCountZ * HexMetrics.chunkSizeZ;

		CreateChunks();
		CreateCells();
	}
	
	void CreateChunks(){
		chunks = new HexGridChunk[chunkCountX * chunkCountZ];

		for (int z = 0, i = 0; z < chunkCountZ; z++) {
			for (int x = 0; x < chunkCountX; x++) {
				HexGridChunk chunk = chunks[i++] = Instantiate(chunkPrefab);
				chunk.transform.SetParent(transform);
			}
		}
	}
	void CreateCells(){
		cells = new HexCell[cellCountZ * cellCountX];
		for (int z = 0, i = 0; z < cellCountZ; z++) {
			for (int x = 0; x < cellCountX; x++) {
				CreateCell(x, z, i++);
			}
		}
		//存档 HexCell的occupied position tiletype visible visionfield elevation
	}
	
	public void SaveAllCells(){
		for(int i = 0;i<cells.Length;i++){
			if(cells[i].tileType!=TileType.nil){
					ES3.Save<HexCell>("HexCell"+i,cells[i]);
					cellNum.Add(i);
			}else{
				continue; 
			}
		}
		ES3.Save<List<int>>("cellNum",cellNum);
	}
	void CreateCell (int x, int z, int i) {
		Vector3 position;
		position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f);
		position.y = 0f;
		position.z = z * (HexMetrics.outerRadius * 1.5f);

		HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
		//cell.transform.SetParent(transform, false);
		cell.transform.localPosition = position;
		cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);
	//--	cell.color = defaultColor;

		if (x > 0) {
			cell.SetNeighbor(HexDirection.W, cells[i - 1]);
		}

		if (z > 0) {
			if ((z & 1) == 0) {
				cell.SetNeighbor(HexDirection.SE, cells[i - cellCountX]);
				if (x > 0) {
					cell.SetNeighbor(HexDirection.SW, cells[i - cellCountX - 1]);
				}
			}
			else {
				cell.SetNeighbor(HexDirection.SW, cells[i - cellCountX]);
				if (x < cellCountX - 1) {
					cell.SetNeighbor(HexDirection.SE, cells[i - cellCountX + 1]);
				}
			}
		}
		Text label = Instantiate<Text>(cellLabelPrefab);
		//label.rectTransform.SetParent(gridCanvas.transform, false);
		label.rectTransform.anchoredPosition =
			new Vector2(position.x, position.z);
		label.text = cell.coordinates.ToStringOnSeparateLines();
		cell.uiRect = label.rectTransform;
		AddCellToChunk(x, z, cell);
	}
	
	void AddCellToChunk (int x, int z, HexCell cell) {
		int chunkX = x / HexMetrics.chunkSizeX;
		int chunkZ = z / HexMetrics.chunkSizeZ;
		HexGridChunk chunk = chunks[chunkX + chunkZ * chunkCountX];

		int localX = x - chunkX * HexMetrics.chunkSizeX;
		int localZ = z - chunkZ * HexMetrics.chunkSizeZ;
		chunk.AddCell(localX + localZ * HexMetrics.chunkSizeX, cell);
	}

	void Update () {
		if (Input.GetMouseButton(0)) {
			HandleInput();
		}
	}

	void HandleInput () {
		Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(inputRay, out hit)) {
			currentSelectedCell = GetCell(hit.point);
		}
	}
	
	public HexCell GetCell (Vector3 position) {
		position = transform.InverseTransformPoint(position);
		HexCoordinates coordinates = HexCoordinates.FromPosition(position);
		Debug.Log("touched at " + coordinates.ToString());
		int index = 
			coordinates.X + coordinates.Z * cellCountX + coordinates.Z / 2;
		HexCell cell = cells[index];
	//--	cell.color = touchedColor;
		ClickSetTile(cell,0,0,0,1);
	//	hexMesh.Triangulate(cells);
		 //hexTiles.SetTileToLocation(1,cell.transform.localPosition,cell);
		return cells[index];
	}

	public void SetTile(HexCell cell,int collection,int tier,int index,int visionRad){
		hexTiles.InitTileSpawn(collection,tier,index,cell.transform.localPosition,cell,visionRad);
	}

	public void ClickSetTile(HexCell cell,int collection,int tier,int index,int visionRad){
		if(hexTiles.SetTileToCell(collection,tier,index,cell.transform.localPosition,cell,visionRad)){
			cell.isVisible = true;
			cell.visionField = 1;
		}
	}

	public void LoadAndSetTile(HexCell cell,int collection,int tier, int index,Vector3 position,int visionRad,TileInfo info){
		if(hexTiles.SetTileToCell(collection,tier,index,position,cell,visionRad,info)){
			cell.isVisible = true;
			cell.visionField = visionRad;
		}else{
			Debug.Log("Load Failed");
		}
	}
/* 
	public void SetCityCenter(HexCell cell){
		hexTiles.SetTileToLocationFromFunctionalTileCollection(0,0,cell.transform.localPosition,cell);
	}
	*/
}