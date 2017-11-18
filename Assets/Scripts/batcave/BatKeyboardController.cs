using UnityEngine;

namespace BatCave {
	/// <summary>
	/// A scriptable object that allows getting control from several bat controllers.
	/// </summary>
	[CreateAssetMenu(menuName = "Bat Controller/Keyboard")]

	public class BatKeyboardController : BatController {

		private bool wantsToFlyUp;

		/// <summary>
		/// Returns true if any of the controllers wants the bat to fly up.
		/// </summary>
		public override bool WantsToFlyUp() {
			// Handle keyboard input.
			if (Input.GetKeyDown(KeyCode.Space)) {
				wantsToFlyUp = true;
			} else if (Input.GetKeyUp(KeyCode.Space)) {
				wantsToFlyUp = false;
			}
			return wantsToFlyUp;
		}
}
}
