using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fractals : MonoBehaviour
{
    // Declare mesh, material, depths and scale
    public Mesh[] meshs;
    public Material material;
    public int maxDepth;
    public float childScale;
    public float spawnProbability;
    public float maxRotationSpeed;
    public float maxtTwist;
    

    private int _depth;
    private float _rotationSpeed;
    
    // use Arrays to tidy code below - easy to expand fractal size
    private static Vector3[] _childDirections =
    {
        Vector3.up,
        Vector3.right,
        Vector3.left,
        Vector3.forward, 
        Vector3.back 
    };

    private static Quaternion[] _childOrientations =
    {
        Quaternion.identity, 
        Quaternion.Euler(0f, 0f, -90f),
        Quaternion.Euler(0f, 0f, 90f),
        Quaternion.Euler(90f, 0f, 0f),
        Quaternion.Euler(-90f, 0f, 0f)
    };

    // comma (,) -> 2D array
    private Material[,] _materials;

    // Start is called before the first frame update
    // Corotine to interrupt frames to build step-by-step
    void Start()
    {
        _rotationSpeed = Random.Range(-maxRotationSpeed, maxRotationSpeed);
        transform.Rotate(Random.Range(-maxtTwist, maxtTwist), 0f, 0f);
        
        if (_materials == null)
        {
            InitializeMaterials();
        }
        
        gameObject.AddComponent<MeshFilter>().mesh = meshs[Random.Range(0, meshs.Length)];
        gameObject.AddComponent<MeshRenderer>().material = _materials[_depth, Random.Range(0, 2)];
        
        if (_depth < maxDepth)
        {
            StartCoroutine(CreateChildren());
        }
    }

    //use childIndex to loop arrays
    private void Initialize(Fractals parent, int childIndex)
    {
        maxRotationSpeed = parent.maxRotationSpeed;
        maxtTwist = parent.maxtTwist;
        meshs = parent.meshs;
        _materials = parent._materials;
        maxDepth = parent.maxDepth;
        _depth = parent._depth + 1;
        childScale = parent.childScale;
        spawnProbability = parent.spawnProbability;

        transform.parent = parent.transform;
        transform.localScale = Vector3.one * childScale;
        transform.localPosition = _childDirections[childIndex] * (0.5f + 0.5f * childScale);
        transform.localRotation = _childOrientations[childIndex];
    }

    private void InitializeMaterials()
    {
        _materials = new Material[maxDepth + 1, 2];
        for (int i = 0; i <= maxDepth; i++)
        {
            _materials[i, 0] = new Material(material);
            _materials[i, 0].color = Color.Lerp(Color.white, Color.yellow, (float)i/maxDepth);
            
            _materials[i, 1] = new Material(material);
            _materials[i, 1].color = Color.Lerp(Color.white, Color.cyan, (float)i/maxDepth);
        }

        _materials[maxDepth, 0].color = Color.magenta;
        _materials[maxDepth, 1].color = Color.red;
    }

    //Iterator to build fractal step-by-step
    private IEnumerator CreateChildren()
    {
        for (int i = 0; i < _childOrientations.Length; i++)
        {
            if (Random.value < spawnProbability)
            {
                yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
                new GameObject("Fractal Child").AddComponent<Fractals>().Initialize(this, i);   
            }
        }
    }

    private void Update()
    {
        transform.Rotate(0f, _rotationSpeed * Time.deltaTime, 0f);
    }
}
