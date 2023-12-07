using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

[CreateAssetMenu(menuName = "Properties")]
public class SaveProperties : ScriptableObject
{
	[SerializeField] private List<SerializedProperty> properties;
	public List<SerializedProperty> Properties => properties;
}
