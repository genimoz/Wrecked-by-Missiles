/*
* Author : Genimoz
* Copyright (c) 2018 Patriano Genio
* All Rights Reserved.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteShadowFX : MonoBehaviour
{
    public Vector2 offset = new Vector2(-1f, -1f);
    public Material material;
    public Color color;

    private SpriteRenderer rendererCaster;
    private SpriteRenderer rendererShadow;

    private Transform caster;
    private Transform shadow;

	void Start ()
	{
        caster = transform;
        shadow = new GameObject().transform; // Instantiate new empty object
        shadow.parent = caster; // Set shadow to be the child of sprite
        shadow.localRotation = Quaternion.identity;
        shadow.localScale = new Vector2(1, 1);
        shadow.gameObject.name = "ShadowFX";

        rendererCaster = GetComponent<SpriteRenderer>();
        rendererShadow = shadow.gameObject.AddComponent<SpriteRenderer>();
        rendererShadow.material = material;
        rendererShadow.color = color;

        rendererShadow.sortingOrder = rendererCaster.sortingOrder - 2;
	}
	
	void LateUpdate ()
	{
        shadow.position = new Vector2(caster.position.x + offset.x, caster.position.y + offset.y);
        rendererShadow.sprite = rendererCaster.sprite;
	}
}
