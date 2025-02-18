<<<<<<< Updated upstream
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
>>>>>>> Stashed changes
using UnityEngine;

public class Drag : MonoBehaviour {
  private bool dragging = false;
  private Vector3 offset;

  void Update() {
    if (dragging) {
      // Move object, taking into account original offset.
      transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    }
<<<<<<< Updated upstream
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
=======
}
=======
namespace Assets.Scripts
{
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class DragIngredients : MonoBehaviour, IDragHandler
    {
        private RectTransform panelTransform;

        [SerializeField] private Canvas canvas;

        private Vector2 botLeftBoundary = Vector2.zero;
        [HideInInspector] public bool canDrag = true;

        private Transform originalTransform;

        

        private void Awake()
        {
            originalTransform = gameObject.transform;
        }

        private void Start()
        {
            this.panelTransform = GetComponent<RectTransform>();
        }

        public void resetLocation() {
            canDrag = true;
            gameObject.SetActive(true);
            gameObject.transform.position = originalTransform.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!canDrag) {return;}

            var corners = new Vector3[4];
            var botLeft = Vector2.zero;
            var topRight = Vector2.zero;


            this.panelTransform.GetWorldCorners(corners);

            if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
            {
                var bl = Camera.main.WorldToScreenPoint(corners[0]);
                var tr = Camera.main.WorldToScreenPoint(corners[2]);
                botLeft = new Vector2(bl.x, bl.y) + eventData.delta / canvas.scaleFactor;
                topRight = new Vector2(tr.x, tr.y) + eventData.delta / canvas.scaleFactor;
            }
            else if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
            {
                botLeft = new Vector2(corners[0].x, corners[0].y) + eventData.delta / canvas.scaleFactor;
                topRight = new Vector2(corners[2].x, corners[2].y) + eventData.delta / canvas.scaleFactor;
            }

            if (botLeft.x > botLeftBoundary.x && botLeft.y > botLeftBoundary.y && topRight.x < Screen.width && topRight.y < Screen.height)
            {
                // Move the object by mouse delta movement and divide by canvas scale
                // Note: Divide by scale factor to keep the mouse in the correct spot on object you are moving.
                this.panelTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            }
        }
    }
}
>>>>>>> Stashed changes
=======
namespace Assets.Scripts
{
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class DragIngredients : MonoBehaviour, IDragHandler
    {
        private RectTransform panelTransform;

        [SerializeField] private Canvas canvas;

        private Vector2 botLeftBoundary = Vector2.zero;
        [HideInInspector] public bool canDrag = true;

        private Transform originalTransform;

        

        private void Awake()
        {
            originalTransform = gameObject.transform;
        }

        private void Start()
        {
            this.panelTransform = GetComponent<RectTransform>();
        }

        public void resetLocation() {
            canDrag = true;
            gameObject.SetActive(true);
            gameObject.transform.position = originalTransform.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!canDrag) {return;}

            var corners = new Vector3[4];
            var botLeft = Vector2.zero;
            var topRight = Vector2.zero;


            this.panelTransform.GetWorldCorners(corners);

            if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
            {
                var bl = Camera.main.WorldToScreenPoint(corners[0]);
                var tr = Camera.main.WorldToScreenPoint(corners[2]);
                botLeft = new Vector2(bl.x, bl.y) + eventData.delta / canvas.scaleFactor;
                topRight = new Vector2(tr.x, tr.y) + eventData.delta / canvas.scaleFactor;
            }
            else if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
            {
                botLeft = new Vector2(corners[0].x, corners[0].y) + eventData.delta / canvas.scaleFactor;
                topRight = new Vector2(corners[2].x, corners[2].y) + eventData.delta / canvas.scaleFactor;
            }

            if (botLeft.x > botLeftBoundary.x && botLeft.y > botLeftBoundary.y && topRight.x < Screen.width && topRight.y < Screen.height)
            {
                // Move the object by mouse delta movement and divide by canvas scale
                // Note: Divide by scale factor to keep the mouse in the correct spot on object you are moving.
                this.panelTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            }
        }
    }
}
>>>>>>> Stashed changes
>>>>>>> Stashed changes
