using System;
using UnityEngine;

namespace ES3Types
{
	[ES3PropertiesAttribute("shapeOfTile", "mainResNum", "subResNum", "grassMount", "<tileTypeName>k__BackingField", "<ID>k__BackingField", "<goldCost>k__BackingField", "<movePunish>k__BackingField", "<visionFieldPunish>k__BackingField", "<fertility>k__BackingField", "<hasGrass>k__BackingField", "<canBuildBuildingType>k__BackingField", "<presetBuilding>k__BackingField", "isSpecial")]
	public class ES3Type_TileInfo : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3Type_TileInfo() : base(typeof(TileInfo)){ Instance = this; }

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (TileInfo)obj;
			
			writer.WriteProperty("shapeOfTile", instance.shapeOfTile);
			writer.WritePrivateField("mainResNum", instance);
			writer.WritePrivateField("subResNum", instance);
			writer.WritePrivateField("grassMount", instance);
			writer.WritePrivateField("<tileTypeName>k__BackingField", instance);
			writer.WritePrivateField("<ID>k__BackingField", instance);
			writer.WritePrivateField("<goldCost>k__BackingField", instance);
			writer.WritePrivateField("<movePunish>k__BackingField", instance);
			writer.WritePrivateField("<visionFieldPunish>k__BackingField", instance);
			writer.WritePrivateField("<fertility>k__BackingField", instance);
			writer.WritePrivateField("<hasGrass>k__BackingField", instance);
			writer.WritePrivateField("<canBuildBuildingType>k__BackingField", instance);
			writer.WritePrivateField("<presetBuilding>k__BackingField", instance);
			writer.WriteProperty("isSpecial", instance.isSpecial, ES3Type_bool.Instance);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (TileInfo)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "shapeOfTile":
						instance.shapeOfTile = reader.Read<System.Collections.Generic.List<System.Int32>>();
						break;
					case "mainResNum":
					reader.SetPrivateField("mainResNum", reader.Read<System.Int32>(), instance);
					break;
					case "subResNum":
					reader.SetPrivateField("subResNum", reader.Read<System.Int32>(), instance);
					break;
					case "grassMount":
					reader.SetPrivateField("grassMount", reader.Read<System.Int32>(), instance);
					break;
					case "<tileTypeName>k__BackingField":
					reader.SetPrivateField("<tileTypeName>k__BackingField", reader.Read<TileType>(), instance);
					break;
					case "<ID>k__BackingField":
					reader.SetPrivateField("<ID>k__BackingField", reader.Read<System.Int32>(), instance);
					break;
					case "<goldCost>k__BackingField":
					reader.SetPrivateField("<goldCost>k__BackingField", reader.Read<System.Int32>(), instance);
					break;
					case "<movePunish>k__BackingField":
					reader.SetPrivateField("<movePunish>k__BackingField", reader.Read<System.Int32>(), instance);
					break;
					case "<visionFieldPunish>k__BackingField":
					reader.SetPrivateField("<visionFieldPunish>k__BackingField", reader.Read<System.Int32>(), instance);
					break;
					case "<fertility>k__BackingField":
					reader.SetPrivateField("<fertility>k__BackingField", reader.Read<System.Int32>(), instance);
					break;
					case "<hasGrass>k__BackingField":
					reader.SetPrivateField("<hasGrass>k__BackingField", reader.Read<System.Boolean>(), instance);
					break;
					case "<canBuildBuildingType>k__BackingField":
					reader.SetPrivateField("<canBuildBuildingType>k__BackingField", reader.Read<System.Collections.Generic.List<BuildingType>>(), instance);
					break;
					case "<presetBuilding>k__BackingField":
					reader.SetPrivateField("<presetBuilding>k__BackingField", reader.Read<System.Collections.Generic.List<BuildingType>>(), instance);
					break;
					case "isSpecial":
						instance.isSpecial = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new TileInfo();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}

	public class ES3Type_TileInfoArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_TileInfoArray() : base(typeof(TileInfo[]), ES3Type_TileInfo.Instance)
		{
			Instance = this;
		}
	}
}