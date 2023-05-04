using UnityEngine;

namespace Framework.Circle
{
    [CreateAssetMenu(fileName = "new CircleSkin", menuName = "Circle/Skins/new Skin")]
    public class CircleSkin : ScriptableObject
    {
        public GameObject SmallCirclePrefab { get => m_smallCirclePrefab; }
        [SerializeField] private GameObject m_smallCirclePrefab;

        public GameObject BackgroundPrefab { get => m_backgroundPrefab; }
        [SerializeField] private GameObject m_backgroundPrefab;
    }
}
