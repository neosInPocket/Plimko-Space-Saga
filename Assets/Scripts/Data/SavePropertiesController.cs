using System.Collections.Generic;
using UnityEngine;

public class SavePropertiesController : MonoBehaviour
{
	[SerializeField] private SaveProperties saveProperties;
	[SerializeField] private bool clearDataOnLoad;
	private Dictionary<SaveType, ISerializable> serializables;
	
	private void Awake()
	{
		serializables = new Dictionary<SaveType, ISerializable>();
		ISerializable property = null;
		
		foreach (var prop in saveProperties.Properties)
		{	
			switch (prop.PropertyType)
			{
				case PropertyType.Int:
				property = new SerializedProperty<int>(prop.SaveType, (int)prop.DefaultValue, clearDataOnLoad);
				serializables.Add(prop.SaveType, property);
				break;
				
				case PropertyType.Float:
				property = new SerializedProperty<float>(prop.SaveType, prop.DefaultValue, clearDataOnLoad);
				serializables.Add(prop.SaveType, property);
				break;
				
				case PropertyType.Bool:
				property = new SerializedProperty<bool>(prop.SaveType, ((int)prop.DefaultValue).Int2Bool(), clearDataOnLoad);
				serializables.Add(prop.SaveType, property);
				break;
			}
		}
	}
	
	public object GetPropertyValue(SaveType id, PropertyType propertyType)
	{
		if (propertyType == PropertyType.Int)
		{
			return ((SerializedProperty<int>)serializables[id]).Value;
		}
		
		if (propertyType == PropertyType.Float)
		{
			return ((SerializedProperty<float>)serializables[id]).Value;
		}
		
		if (propertyType == PropertyType.Bool)
		{
			return ((SerializedProperty<bool>)serializables[id]).Value;
		}
		
		return null;
	}
}

public static class Converter
{
	public static int Bool2Int(this bool value)
	{
		return value ? 1 : 0;
	}
	
	public static bool Int2Bool(this int value)
	{
		return value == 1 ? true : false;
	}
}
