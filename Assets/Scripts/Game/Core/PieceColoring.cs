using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;


public class PieceColoring : MonoBehaviour
{
	[SerializeField] private PieceColors pieceColors;

	public bool Enabled
	{
		get => isEnabled;
		set
		{
			isEnabled = value;
			if (value)
			{
				Touch.onFingerDown += OnFingerTouch;
			}
			else
			{
				Touch.onFingerDown -= OnFingerTouch;
			}
		}
	}

	private bool isEnabled;
	public Color CurrentColor
	{
		get => currentColor;
		set => currentColor = value;
	}
	private Color currentColor;

	private void Start()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();

		Enabled = true;
		Debug.LogError("Delete");

		currentColor = pieceColors.DefaultColor;
	}

	private void OnFingerTouch(Finger finger)
	{
		Vector2 worldPosition = Camera.main.ScreenToWorldPoint(finger.screenPosition);
		RaycastHit2D[] raycast = Physics2D.RaycastAll(worldPosition, Vector3.forward);

		var piece = raycast.First(x => x.collider.GetComponent<Piece>() != null);

		if (piece != null && piece.collider != null)
		{
			if (piece.collider.gameObject.TryGetComponent<Piece>(out Piece pieceGO))
			{
				pieceGO.ToggleMagnet(currentColor);
			}
		}
	}
}
