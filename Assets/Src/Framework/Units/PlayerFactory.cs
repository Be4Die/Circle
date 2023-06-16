using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerFactory
{
    public PlayerBehaviour Create(PlayerSkin skin, int circleCount, float speed)
    {
        var playerGameObject = new GameObject("Player");
        var background = CreateBackground(skin, playerGameObject.transform);
        var circlesContainer = new GameObject("CirclesContainer");
        List<Transform> circles = new List<Transform>();
        circlesContainer.transform.SetParent(playerGameObject.transform);

        float curAngle = 0;
        for (int i = 0; i < circleCount; i++)
        {
            Debug.Log(curAngle);
            var newPos = new Vector3(Mathf.Cos(curAngle), Mathf.Sin(curAngle), 0);
            circles.Add(CreateCircle(skin, circlesContainer.transform, newPos));
            curAngle += Mathf.PI*2 / circleCount;
        }

        var playerBehaviour = playerGameObject.AddComponent<PlayerBehaviour>();
        playerBehaviour.m_backgroundScale = Vector3.one;
        playerBehaviour.m_circlesScale = Vector3.one;
        playerBehaviour.m_radius = 1;
        playerBehaviour.Init(speed, background, circles);
        return playerBehaviour;
    }

    private Transform CreateCircle(PlayerSkin skin, Transform parent, Vector3 position)
    {
        var circleGameObject = new GameObject("Circle");
        circleGameObject.transform.position = position;
        circleGameObject.transform.SetParent(parent);

        var circleRenderer = circleGameObject.AddComponent<SpriteRenderer>();
        circleRenderer.sprite = skin.CircleShape;
        circleRenderer.color = skin.CircleColor;

        foreach (var effect in skin.Effects)
        {
            circleGameObject.AddComponent(effect.GetType());
        }
        return circleGameObject.transform;
    }

    private Transform CreateBackground(PlayerSkin skin, Transform parent)
    {
        var background = new GameObject("Background");
        background.transform.SetParent(parent);
        var backgroundRenderer = background.AddComponent<SpriteRenderer>();
        backgroundRenderer.sprite = skin.BackgroundSprite;
        backgroundRenderer.color = skin.BackgroundColor;
        Debug.Log(background.transform);
        return background.transform;
    }
}
