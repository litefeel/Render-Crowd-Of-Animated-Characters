﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class AnimPlayer : MonoBehaviour {

    public Material[] materials;
    public string[] actionNames;

    private new MeshRenderer renderer;
    private MaterialPropertyBlock block;
    private int curAnimationIdx;
    private float curTime = 0;

    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
        block = new MaterialPropertyBlock();

        AnimPlayerManager.Instance.doUpdate += DoUpdate;

        //Play(curAnimationIdx, Random.Range(0, 2f));
    }
    
	public void Play(string name, float delay = 0)
    {
        var idx = System.Array.IndexOf(actionNames, name);
        Play(idx, delay);
    }
    public void Play(int nameId, float delay = 0)
    {
        if (nameId >= materials.Length || nameId < 0) return;
        curAnimationIdx = nameId;
        renderer.sharedMaterial = materials[nameId];
        curTime = delay;
        block.SetFloat("_CurTime", curTime);
        renderer.SetPropertyBlock(block);
    }

    public void DoUpdate(float deltaTime)
    {
        curTime += deltaTime;
        block.SetFloat("_CurTime", curTime);
        renderer.SetPropertyBlock(block);
    }

}
