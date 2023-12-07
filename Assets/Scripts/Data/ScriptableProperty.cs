using UnityEngine;

public class ScriptableProperty : MonoBehaviour
{
	[SerializeField] private PropertyType propertyType;
	
}

public enum PropertyType
{
	Int,
	Float,
	Bool
}
