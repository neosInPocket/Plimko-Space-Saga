using System;
using UnityEngine;

public class SerializedProperty<T> where T : struct
{
	protected string Identifier { get; }
	protected T DefaultValue { get; }
	public T Value
	{
		get
		{
			Deserialize();
			return _value;
		}
		set
		{
			_value = value;
			Serialize();
		}
	}
	
	private T _value;
	
	protected void Serialize()
	{
		Type propertyType = typeof(T);
		
		if (propertyType == typeof(int))
		{
			PlayerPrefs.SetInt(Identifier, (int)(object)Value);
			return;
		}
		
		if (propertyType == typeof(float))
		{
			PlayerPrefs.SetFloat(Identifier, (float)(object)Value);
			return;
		}
		
		if (propertyType == typeof(bool))
		{
			bool value = (bool)(object)Value;
			int result = value == true ? 1 : 0;
			
			PlayerPrefs.SetInt(Identifier, result);
			return;
		}
	}
	
	protected void Deserialize()
	{
		Type propertyType = typeof(T);
		
		if (propertyType == typeof(int))
		{
			_value = (T)(object)PlayerPrefs.GetInt(Identifier, (int)(object)DefaultValue);
			return;
		}
		
		if (propertyType == typeof(float))
		{
			_value = (T)(object)PlayerPrefs.GetFloat(Identifier, (float)(object)DefaultValue);
			return;
		}
		
		if (propertyType == typeof(bool))
		{
			var defaultValue = (bool)(object)DefaultValue;
			int result = defaultValue == true ? 1 : 0;
			
			var value = PlayerPrefs.GetInt(Identifier, (int)(object)defaultValue);
			bool valueResult = value == 1 ? true : false;
			_value = (T)(object)valueResult;
			return;
		}
	}
}
