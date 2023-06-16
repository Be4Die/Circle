using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerFactory : MonoBehaviour
{
    [SerializeField] private PlayerSkin m_playerskin;
    [SerializeField] private int m_count;
    // Start is called before the first frame update
    void Start()
    {
        var factory = new PlayerFactory();
        factory.Create(m_playerskin, m_count, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
