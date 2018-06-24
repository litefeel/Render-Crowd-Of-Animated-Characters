using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayerManager : MonoBehaviour {

    private static AnimPlayerManager _Instance;
	public static AnimPlayerManager Instance
    {
        get
        {
            if(!_Instance)
            {
                _Instance = new GameObject("AnimPlayerManager").AddComponent<AnimPlayerManager>();
            }
            return _Instance;
        }
    }

    public delegate void DoUpdate(float deltaTime);

    public event DoUpdate doUpdate;

    private void Awake()
    {
        
    }

    private void Update()
    {
        doUpdate.Invoke(Time.deltaTime);
    }
}
