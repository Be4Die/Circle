using UnityEngine;

namespace Framework.Circle
{
    public class CircleRenderer : MonoBehaviour
    {
        [SerializeField] private CircleSkin m_skin;
        [SerializeField] private float m_scale;
        [SerializeField] private uint m_smallCircleCount;

        private GameObject m_background;

        void Start () { UpdateSkin(); }

        public void SetUp(CircleSkin skin, float scale, uint smallCircleCount) 
        {
            m_skin = skin;
            m_scale = scale;
            m_smallCircleCount = smallCircleCount;

            UpdateSkin();
        }

        public void ChangeSkin(CircleSkin skin)
        {
            m_skin = skin;

            if (m_background != null)
                Destroy(m_background);
            Generate();
        }

        private void UpdateSkin()
        {
            if (m_background != null)
                Destroy(m_background);
            Generate();
        }

        private void Generate()
        {
            m_background = Instantiate(m_skin.BackgroundPrefab, transform);
            m_background.transform.SetParent(transform);
            m_background.transform.localScale *= m_scale;
            GenerateSmallCircles();
        }

        private void GenerateSmallCircles()
        {
            float sectionAngle = Mathf.PI * 2 / m_smallCircleCount;
            for (int i = 0; i < m_smallCircleCount; i++)
            {
                float angle = i * sectionAngle;
                float x = Mathf.Cos(angle);
                float y = Mathf.Sin(angle);
                Vector3 pos =  new Vector3(x, y)*0.5f;
                GameObject obj = Instantiate(m_skin.SmallCirclePrefab, m_background.transform);
                obj.transform.SetParent(m_background.transform);
                obj.transform.localScale = obj.transform.localScale * 0.25f * m_scale / m_background.transform.localScale.x; 
                obj.transform.localPosition = pos;
            }
        }
    }
}
