using UnityEngine;

public class Emissions : MonoBehaviour
{
    public GameObject BruteMeshPart1;
    public GameObject BruteMeshPart2;
    public GameObject BruteMeshPart3;
    public GameObject BruteMeshPart4;
    public GameObject BruteMeshPart5;
    public GameObject BruteMeshPart6;
    public GameObject BruteMeshPart7;
    public GameObject BruteMeshPart8;
    public GameObject CrimsonMesh;
    public GameObject ElDevilMesh;
    public GameObject JinMesh;

    SkinnedMeshRenderer CrimsonEmission;
    SkinnedMeshRenderer ElDevilEmission;
    SkinnedMeshRenderer JinEmission;
    SkinnedMeshRenderer BruteEmission1;
    SkinnedMeshRenderer BruteEmission2;
    SkinnedMeshRenderer BruteEmission3;
    SkinnedMeshRenderer BruteEmission4;
    SkinnedMeshRenderer BruteEmission5;
    SkinnedMeshRenderer BruteEmission6;
    SkinnedMeshRenderer BruteEmission7;
    SkinnedMeshRenderer BruteEmission8;

    private void Start()
    {
        BruteEmission1 = BruteMeshPart1.GetComponent<SkinnedMeshRenderer>();
        BruteEmission2 = BruteMeshPart2.GetComponent<SkinnedMeshRenderer>();
        BruteEmission3 = BruteMeshPart3.GetComponent<SkinnedMeshRenderer>();
        BruteEmission4 = BruteMeshPart4.GetComponent<SkinnedMeshRenderer>();
        BruteEmission5 = BruteMeshPart5.GetComponent<SkinnedMeshRenderer>();
        BruteEmission6 = BruteMeshPart6.GetComponent<SkinnedMeshRenderer>();
        BruteEmission7 = BruteMeshPart7.GetComponent<SkinnedMeshRenderer>();
        BruteEmission8 = BruteMeshPart8.GetComponent<SkinnedMeshRenderer>();
        CrimsonEmission = CrimsonMesh.GetComponent<SkinnedMeshRenderer>();
        ElDevilEmission = ElDevilMesh.GetComponent<SkinnedMeshRenderer>();
        JinEmission = JinMesh.GetComponent<SkinnedMeshRenderer>();
    }


    private void Update()
    {
        BruteEmission1.material.DisableKeyword("_EMISSION");
        BruteEmission2.material.DisableKeyword("_EMISSION");
        BruteEmission3.material.DisableKeyword("_EMISSION");
        BruteEmission4.material.DisableKeyword("_EMISSION");
        BruteEmission5.material.DisableKeyword("_EMISSION");
        BruteEmission6.material.DisableKeyword("_EMISSION");
        BruteEmission7.material.DisableKeyword("_EMISSION");
        BruteEmission8.material.DisableKeyword("_EMISSION");

        CrimsonEmission.materials[0].DisableKeyword("_EMISSION");
        CrimsonEmission.materials[1].DisableKeyword("_EMISSION");

        JinEmission.material.DisableKeyword("_EMISSION");
        ElDevilEmission.material.DisableKeyword("_EMISSION");
    }
}
