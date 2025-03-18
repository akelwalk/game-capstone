// namespace Assets.Scripts
// {
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class DragIngredient : MonoBehaviour, IDragHandler
    {
        private RectTransform panelTransform;

        [SerializeField]
        public Canvas canvas;

        private Vector2 botLeftBoundary = Vector2.zero;

        private void Start()
        {
            this.panelTransform = GetComponent<RectTransform>();
        }


        public void OnDrag(PointerEventData eventData)
        {

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
// }
