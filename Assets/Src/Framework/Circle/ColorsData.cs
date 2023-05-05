using UnityEngine;

namespace Framework.Circle
{
    [CreateAssetMenu(fileName = "new ColorData", menuName = "Circle/Circles Rendering/new ColorsData")]
    public class ColorsData : ScriptableObject
    {
        private static readonly Color m_undefined = new Color(227f/255f, 0f, 1f);
        public Color White { get => m_white; }
        [SerializeField] private Color m_white;

        public Color Red { get => m_red; }
        [SerializeField] private Color m_red;

        public Color Green { get => m_green; }
        [SerializeField] private Color m_green;

        public Color Blue { get => m_blue; }
        [SerializeField] private Color m_blue;

        public Color GetColor(Types.Colors type) 
        {
            switch (type)
            {
                case Types.Colors.White:
                    return m_white;
                case Types.Colors.Red:
                    return m_red;
                case Types.Colors.Green:
                    return m_green;
                case Types.Colors.Blue:
                    return m_blue;
                default:
                    throw new System.Exception("You can try no static color");
            }
        }
    }
}
