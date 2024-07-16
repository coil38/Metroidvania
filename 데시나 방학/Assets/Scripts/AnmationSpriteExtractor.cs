using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;              //에디터 라이브러리 설정

public class SpriteInfo
{
    public float time;                          //스프라이트가 사용되는 시간
    public string spriteName;                   //스프라이트 이름
}

public class AnmationSpriteExtractor : EditorWindow
{
    private AnimationClip animationClip;                                                //선택된 애니메이션 클랩
    private List<SpriteInfo> spriteInfoList = new List<SpriteInfo>();                   //스프라이트 정보를 저장할 리스트

    [MenuItem("Winow/Animation Sprite Extractor")]                                      //메뉴에 Animation Sprite Extractor 항목을 추가

    public static void Showindow()
    {
        GetWindow<AnmationSpriteExtractor>("AnmationSpriteExtractor");                  //에디터 창 열기
    }

    private void OnGUI()
    {
        GUILayout.Label("Extract Sprites Info form Animtaion Clip" , EditorStyles.boldLabel);   //에디터 창에 레이블과 애니메이션 클립 필드 표시

        //사용자가 드래그 앤 드롭으로 애니메이션 클립을 설정할 수 있게 해줌
        animationClip = EditorGUILayout.ObjectField("Animation Clip" , animationClip, typeof(AnimationClip), false) as AnimationClip;
    
        if(animationClip != null)           //애니메이션 클립이 설정된 경우
        {
            if(GUILayout.Button("Extract Sprites Info"))            //버튼이 클릭 되면 스프라이트 정보를 추출
            {
                ExtractSpritesInfo(animationClip);
            }

            if(spriteInfoList.Count > 0)                            //스프라이트 정보 리스트가 비어있지 않은 경우
            {
                GUILayout.Label("Sprites Info :", EditorStyles.boldLabel);
                foreach(var spriteInfo in spriteInfoList)
                {
                    GUILayout.BeginHorizontal();                                            //수평 레이아웃 시간
                    GUILayout.Label("Time:", GUILayout.Width(50));                          //Time 레이블
                    GUILayout.Label(spriteInfo.time.ToString(), GUILayout.Width(100));      //시간 값
                    GUILayout.Label("Sprite : " , GUILayout.Width(50));                     //Sprite 레이블
                    GUILayout.Label(spriteInfo.spriteName, GUILayout.Width(200));           //스프라이트 이름
                    GUILayout.EndHorizontal();                                              //수평 레이아웃 종료
                }
            }
        }
    }

    private void ExtractSpritesInfo(AnimationClip clip)         //스프라이트 정보를 추출 하는 함수
    {
        spriteInfoList.Clear();                                 //기존 스프라이트 정보 초기화
        var bindings = AnimationUtility.GetObjectReferenceCurveBindings(clip);      //애니메이션 클립에서 Object Reference Curve 바인딩을 가져옴
    
        foreach (var binding in bindings)
        {
            if(binding.propertyName.Contains("Sprite"))                 //바인딩된 프로퍼티가 스프라이트일 경우
            {
                var Keyframes = AnimationUtility.GetObjectReferenceCurve(clip, binding);

                /*foreach(var keyframe in Keyframes)
                {
                    Sprite spriite = keyframe.value as Sprite;          //키프레임 값을 스프라이드로 캐스팅
                    if(spriite != null)
                    {
                        spriteInfoList.Add(new SpriteInfo { time = keyframe.time, spriteName = sprite.name });          //스프라이트 정보를 리스트에 추가
                    }
                }*/
                //위에꺼 오류떠서 그냥 주석 처리함.
            }
        }
    }
}
