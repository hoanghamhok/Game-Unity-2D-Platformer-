using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBounce : MonoBehaviour
{
    public float amplitude = 1f; // Độ cao nảy
    public float frequency = 3f;  // Tốc độ nảy

    private TMP_Text tmpText;
    private TMP_TextInfo textInfo;
    private float[] charOffset;

    void Awake()
    {
        tmpText = GetComponent<TMP_Text>();
    }

    void Start()
    {
        tmpText.ForceMeshUpdate();
        textInfo = tmpText.textInfo;
        charOffset = new float[textInfo.characterCount];
    }

    void Update()
    {
        tmpText.ForceMeshUpdate();
        textInfo = tmpText.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            if (!textInfo.characterInfo[i].isVisible)
                continue;

            Vector3[] verts = textInfo.meshInfo[textInfo.characterInfo[i].materialReferenceIndex].vertices;
            int index = textInfo.characterInfo[i].vertexIndex;

            // Tính vị trí y dao động theo sóng sin
            float offset = Mathf.Sin(Time.time * frequency + i * 0.5f) * amplitude;

            // Dịch chuyển toàn bộ 4 đỉnh của chữ cái đó
            for (int j = 0; j < 4; j++)
            {
                verts[index + j].y += offset;
            }
        }

        // Cập nhật lại mesh
        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            TMP_MeshInfo meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            tmpText.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}
