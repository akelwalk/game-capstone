
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragIngredient : MonoBehaviour
// , IDragHandler, IBeginDragHandler
{
    private bool isDragging = false;
    private bool movement = false;
    public float duration = 3f; // Time to move between positions
    private float elapsedTime = 0f;
    private RectTransform panelTransform;

    void Awake()
    {
        this.panelTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (isDragging)
        {
            transform.position = GetMousePosition();
        }
        if (Input.GetMouseButtonUp(0)) // Left mouse button released
        {
            StopDragging();
        }
        if (movement) {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            transform.position = Vector3.Lerp(transform.position, transform.parent.transform.position, t);

            if (t >= 1 || Vector3.Distance(transform.position, transform.parent.transform.position) < 0.3f) {
                movement = false; // Stop moving when lerp is complete
                Destroy(gameObject);
            }
        }

    }

    public void StartDragging()
    {
        isDragging = true;
        elapsedTime = 0f;
    }

    public void StopDragging()
    {
        isDragging = false;
        movement = true;
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.x = Mathf.Clamp(mousePos.x, 65/2, Screen.width - (65/2));
        mousePos.y = Mathf.Clamp(mousePos.y, 100/2, Screen.height - (100/2));
        mousePos.z = 10f; // Adjust based on camera distance
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}

