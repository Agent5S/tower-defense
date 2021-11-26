using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PositionRaycaster : MonoBehaviour
{
    public GameObject prefab;
    public MeshRenderer prev;
    public BulkMoveComponent teamA;
    public CooldownTimer timer;

    private Camera cam;
    private Collider coll;
    private MeshRenderer rend;
    private RaycastHit result;
    private Vector2 mousePos;
    private DefaultInputActions input;

    private void Awake()
    {
        this.cam = Camera.main;
        this.coll = GetComponent<Collider>();
        this.rend = GetComponent<MeshRenderer>();
        this.input = new DefaultInputActions();
    }

    private void OnEnable()
    {
        this.rend.enabled = true;
        this.input.Enable();
        this.input.UI.Point.performed += OnPoint;
        this.input.UI.Click.performed += OnClick;
    }

    private void OnDisable()
    {
        this.rend.enabled = false;
        this.prev.enabled = false;
        this.input.Disable();
        this.input.UI.Point.performed -= OnPoint;
        this.input.UI.Click.performed -= OnClick;
    }

    void OnPoint(InputAction.CallbackContext context)
    {
        this.mousePos = context.ReadValue<Vector2>();
        var ray = cam.ScreenPointToRay(mousePos);

        var hit = coll.Raycast(ray, out result, float.PositiveInfinity);

        if (hit)
        {
            var position = result.point;
            this.prev.transform.position = position;
            this.prev.enabled = true;
            return;
        }

        this.prev.enabled = false;
    }

    void OnClick(InputAction.CallbackContext context)
    {
        var ray = cam.ScreenPointToRay(mousePos);

        var hit = coll.Raycast(ray, out result, float.PositiveInfinity);

        if (hit)
        {
            var position = result.point;
            var character = Instantiate(prefab);
            character.transform.position = position;
            //character.transform.parent = teamA;
            var moveComp = character.GetComponent<MoveComponent>();
            moveComp.defaultMove = teamA;
            timer.StartTicking();
        }

        this.prev.enabled = false;
        this.enabled = false;
    }
}
