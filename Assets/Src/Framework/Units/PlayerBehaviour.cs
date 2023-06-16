using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private readonly float m_speedScale = 10;

    [SerializeField] private bool m_isPause;
    [SerializeField] private bool m_isRightRotate;
    [SerializeField] private float m_speed;
    [Header("Sizes")]
    [SerializeField] public Vector3 m_backgroundScale;
    [SerializeField] public Vector3 m_circlesScale;
    [SerializeField][Range(.1f, 1.5f)] public float m_radius;

    private Transform m_background;
    private List<Transform> m_circles;

    public void Init(float speed, Transform background, List<Transform> circles)
    {
        m_speed = speed;
        m_background = background;
        m_circles = circles;
        Resize();
    }

    private void Update()
    {
        RotationTick();
    }

    private void OnValidate()
    {
        Resize();
    }

    private void Resize()
    {
        m_background.transform.localScale = m_backgroundScale;
        foreach (var circle in m_circles)
        {
            circle.localScale = m_circlesScale;
            circle.localPosition *= m_radius;
        }
    }

    private void RotationTick()
    {
        if (m_isPause)
            return;

        var angle = m_speed * Time.deltaTime * m_speedScale;

        if (!m_isRightRotate)
            angle = -angle;

        transform.Rotate(0, 0, angle);
    }
}
