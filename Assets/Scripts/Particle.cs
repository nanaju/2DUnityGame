using UnityEngine;
using System.Collections;

public class Particle : Token
{
    //プレハブ
    static GameObject _prefab = null;
    //パーティクルの生成
    public static Particle Add(float x, float y)
    {
        //プレハブを取得
        _prefab = GetPrefab(_prefab, "Particle");
        //プレハブからインスタンスを生成
        return CreateInstance2<Particle>(_prefab, x, y);

    }   


    // Use this for initialization
    IEnumerator Start()
    {
        //移動方向と速さをランダムに
        float dir = Random.Range(0, 359);
        float spd = Random.Range(10.0f, 20.0f);
        SetVelocity(dir, spd);

        //見えなくなるまで小さくする
        while (ScaleX > 0.01f)
        {
            //0.0秒ゲームループに制御を返す
            yield return new WaitForSeconds(0.01f);
            //だんだん小さくする
            MulScale(0.9f);
            //だんだん減速
            MulVelocity(0.9f);

        }

        DestroyObj();
    }

}
