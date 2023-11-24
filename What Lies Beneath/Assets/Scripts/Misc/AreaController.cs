using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaController : MonoBehaviour
{

    public BattleGroup[] groupsArea1,groupsArea2;

    public List<BattleGroup[]> groups = new List<BattleGroup[]>();

    public int area;

    public static AreaController Instance;

    private void Awake()
    {
        groups.Add(groupsArea1);
        groups.Add(groupsArea2);
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
