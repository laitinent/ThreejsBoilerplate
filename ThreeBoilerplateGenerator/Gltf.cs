using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBoilerplateGenerator
{
    public class Accessor
    {
        public int bufferView { get; set; }
        public int byteOffset { get; set; }
        public int componentType { get; set; }
        public int count { get; set; }
        public List<double> max { get; set; }
        public List<double> min { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }

    public class Asset
    {
        public string copyright { get; set; }
        public string generator { get; set; }
        public string version { get; set; }
    }

    public class BufferView
    {
        public int buffer { get; set; }
        public int byteLength { get; set; }
        public int byteOffset { get; set; }
        public string name { get; set; }
        public int target { get; set; }
        public int? byteStride { get; set; }
    }

    public class Buffer
    {
        public int byteLength { get; set; }
        public string name { get; set; }
        public string uri { get; set; }
    }

    public class PbrMetallicRoughness
    {
        public List<double> baseColorFactor { get; set; }
        public int metallicFactor { get; set; }
        public double roughnessFactor { get; set; }
    }

    public class Material
    {
        public string alphaMode { get; set; }
        public bool doubleSided { get; set; }
        public string name { get; set; }
        public PbrMetallicRoughness pbrMetallicRoughness { get; set; }
    }

    public class Attributes
    {
        public int COLOR_0 { get; set; }
        public int NORMAL { get; set; }
        public int POSITION { get; set; }
    }

    public class Primitive
    {
        public Attributes attributes { get; set; }
        public int indices { get; set; }
        public int material { get; set; }
        public int mode { get; set; }
    }

    public class Mesh
    {
        public string name { get; set; }
        public List<Primitive> primitives { get; set; }
    }

    public class Node
    {
        public List<int> matrix { get; set; }
        public int mesh { get; set; }
        public string name { get; set; }
    }

    public class Extras
    {
    }

    public class Scene
    {
        public Extras extras { get; set; }
        public string name { get; set; }
        public List<int> nodes { get; set; }
    }

    public class Gltf
    {
        public List<Accessor> accessors { get; set; }
        public Asset asset { get; set; }
        public List<BufferView> bufferViews { get; set; }
        public List<Buffer> buffers { get; set; }
        public List<Material> materials { get; set; }
        public List<Mesh> meshes { get; set; }
        public List<Node> nodes { get; set; }
        public int scene { get; set; }
        public List<Scene> scenes { get; set; }
    }    
}
