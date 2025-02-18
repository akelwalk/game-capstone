using UnityEngine;

public class Drag : MonoBehaviour {
  private bool dragging = false;
  private Vector3 offset;

  void Update() {
    if (dragging) {
      // Move object, taking into account original offset.
      transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    }
  }

  private void OnMouseDown() {
    // Record the difference between the objects center, and the clicked point on the camera plane.
    offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    dragging = true;
  }

  private void OnMouseUp() {
    // Stop dragging.
    dragging = false;
  }
}