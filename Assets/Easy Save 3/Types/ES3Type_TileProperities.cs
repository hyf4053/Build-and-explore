using System;
using UnityEngine;

namespace ES3Types
{
	[ES3PropertiesAttribute("tileTpye")]
	public class ES3Type_TileProperities : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_TileProperities() : base(typeof(TileProperities))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (TileProperities)obj;
			
			writer.WriteProperty("tileTpye", instance.tileTpye);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (TileProperities)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "tileTpye":
						instance.tileTpye = reader.Read<TileType>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_TileProperitiesArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_TileProperitiesArray() : base(typeof(TileProperities[]), ES3Type_TileProperities.Instance)
		{
			Instance = this;
		}
	}
}