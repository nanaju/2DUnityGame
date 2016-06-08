using UnityEngine;
using System.Collections;

public class Enemy : Token
{
    public static int Count = 4;
    ///開始
    void Start()
    {

        //サイズを設定
        SetSize(SpriteWidth / 2, SpriteHeight / 2);

        // ランダムな方向に移動
        //方向をランダムに決定
        float dir = Random.Range(0, 359);
        //速さ2
        float spd = 2;
        SetVelocity(dir, spd);

    }

    void Update()
    {
        //カメラの左下座標を取得
        Vector2 min = GetWorldMin();
        Vector2 max = GetWorldMax();

        if (X < min.x || max.x < X)
        {
            //画面の外に出たので、Xの移動量を反転
            VX *= -1;
            //画面内に移動
            ClampScreen();
        }

        if (Y < min.y || max.y < Y)
        {
            VY *= -1;
            ClampScreen();
        }
    }
    public void OnMouseDown()
    {
        Count--;
         //パーティクルを生成
        for (int i = 0; i < 32; i++)
        {
            Particle.Add(X, Y);
        }

        //破棄する
        DestroyObj();
    }


}
