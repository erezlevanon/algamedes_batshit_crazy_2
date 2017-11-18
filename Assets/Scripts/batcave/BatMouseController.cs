using UnityEngine;
using UnityEngine.EventSystems;
using Infra.Gameplay.UI;

namespace BatCave {
	/// <summary>
	/// A scriptable object that allows controlling the bat using the mouse.
	/// </summary>
	[CreateAssetMenu(menuName = "Bat Controller/Mouse")]

	public class BatMouseController : BatController {

		private bool wantsToFlyUp;

		/// <summary>
		/// Returns true if the mouse is held down.
		/// </summary>
		public override bool WantsToFlyUp() {
			return wantsToFlyUp;
		}

		protected void OnEnable() {
			wantsToFlyUp = false;
			GameInputCapture.OnTouchDown += OnTouchDown;
			GameInputCapture.OnTouchUp += OnTouchUp;
		}

		protected void OnDisable() {
			GameInputCapture.OnTouchDown -= OnTouchDown;
			GameInputCapture.OnTouchUp -= OnTouchUp;
		}

		private void OnTouchDown(PointerEventData e) {
			// Check that the event was not already handled by the GameManager.
			if (e.used) return;
			wantsToFlyUp = true;
		}

		private void OnTouchUp(PointerEventData e) {
			wantsToFlyUp = false;
		}
}
}
