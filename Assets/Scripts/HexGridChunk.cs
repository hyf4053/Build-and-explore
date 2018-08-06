using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGridChunk : MonoBehaviour {
	public HexCell[] cells;
	HexMesh hexMesh;
	Canvas gridCanvas;

	

	void Awake () {
		gridCanvas = GetComponentInChildren<Canvas>();
		hexMesh = GetComponentInChildren<HexMesh>();

		cells = new HexCell[HexMetrics.chunkSizeX * HexMetrics.chunkSizeZ];
	}
	
	void Start () {
		hexMesh.Triangulate(cells);
		//ES3.Save<HexCell[]>("CellList",cells);
	}

	public void AddCell (int index, HexCell cell) {
		cells[index] = cell;
		cell.transform.SetParent(transform, false);
		cell.uiRect.SetParent(gridCanvas.transform, false);
	}
}
