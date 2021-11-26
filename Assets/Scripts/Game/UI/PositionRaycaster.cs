using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PositionRaycaster : MonoBehaviour
{
    public GameObject prefab;
    public MeshRenderer prev;
    public BulkMoveComponent teamA;

    private Camera cam;
    private Collider coll;
    private MeshRenderer rend;
    private RaycastHit result;
    private Vector2 mousePos;
    private PlayerInput input;

    private void Awake()
    {
        this.cam = Camera.main;
        this.coll = GetComponent<Collider>();
        this.rend = GetComponent<MeshRenderer>();
        this.input = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        this.rend.enabled = true;
        this.input.enabled = true;
    }

    private void OnDisable()
    {
        this.rend.enabled = false;
        this.input.enabled = false;
        this.prev.enabled = false;
    }

    void OnPoint(InputValue value)
    {
        this.mousePos = value.Get<Vector2>();
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

    void OnClick(InputValue value)
    {
        if (value.isPressed) { return; }

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
        }

        this.prev.enabled = false;
        this.enabled = false;
    }
}
