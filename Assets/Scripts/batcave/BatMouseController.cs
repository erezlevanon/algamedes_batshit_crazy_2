using UnityEngine;
using UnityEngine.EventSystems;
using Infra.Gameplay.UI;

namespace BatCave {
	/// <summary>
	/// A scriptable object that allows getting control from several bat controllers.
	/// </summary>
	[CreateAssetMenu(menuName = "Bat Controller/Mouse")]

	public class BatMouseController : BatController {

		private bool wantsToFlyUp;

		/// <summary>
		/// Returns true if any of the controllers wants the bat to fly up.
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
