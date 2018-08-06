using System;
using UnityEngine;

namespace ES3Types
{
	[ES3PropertiesAttribute("coordinates", "isOccupied", "position", "tileType", "isVisible", "visionField", "currentInfo")]
	public class ES3Type_HexCell : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_HexCell() : base(typeof(HexCell))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (HexCell)obj;
			
			writer.WriteProperty("coordinates", instance.coordinates);
			writer.WriteProperty("isOccupied", instance.isOccupied, ES3Type_bool.Instance);
			writer.WritePropertyByRef("position", instance.position);
			writer.WriteProperty("tileType", instance.tileType);
			writer.WriteProperty("isVisible", instance.isVisible, ES3Type_bool.Instance);
			writer.WriteProperty("visionField", instance.visionField, ES3Type_int.Instance);
			writer.WriteProperty("currentInfo", instance.currentInfo, ES3Type_TileInfo.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (HexCell)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "coordinates":
						instance.coordinates = reader.Read<HexCoordinates>();
						break;
					case "isOccupied":
						instance.isOccupied = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "position":
						instance.position = reader.Read<UnityEngine.Transform>(ES3Type_Transform.Instance);
						break;
					case "tileType":
						instance.tileType = reader.Read<TileType>();
						break;
					case "isVisible":
						instance.isVisible = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "visionField":
						instance.visionField = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "currentInfo":
						instance.currentInfo = reader.Read<TileInfo>(ES3Type_TileInfo.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_HexCellArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_HexCellArray() : base(typeof(HexCell[]), ES3Type_HexCell.Instance)
		{
			Instance = this;
		}
	}
}