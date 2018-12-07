using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace ThreeBoilerplateGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] threepaths = { "\"three.js\"", "\"https://cdnjs.cloudflare.com/ajax/libs/three.js/97/three.js\"" };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.FileName = "index.html";
            svf.Filter = "HTML files|*.htm*";
            if (svf.ShowDialog() == true)
            {
                try
                {
                    StreamWriter writer = File.CreateText(svf.FileName);
                    writer.WriteLine(GenerateBoilerplateCode());
                    writer.Close();
                }
                catch(Exception ex) { MessageBox.Show(ex.Message); }
            }
            tbCode.Text = GenerateBoilerplateCode();
        }

        private string GenerateBoilerplateCode()
        {
            string code = "";
            code += Properties.Settings.Default.code_html_start;
            code += "Generated Three.js Code Sample"; // title
            code += Properties.Settings.Default.code_html_start2;
            code += Properties.Settings.Default.code_includes_start;

            if (cbLocal.IsChecked == true) { code += threepaths[0]; } // threejs path
            else { code += threepaths[1]; }

            code += Properties.Settings.Default.code_includes_start2;
            if (rbOrbit.IsChecked == true) { code += Properties.Settings.Default.code_orbit_include; }
            code += Properties.Settings.Default.code_script_start;
            code += Properties.Settings.Default.code_global_vars;
            code += Properties.Settings.Default.code_call_init_animate;
            code += Properties.Settings.Default.code_camera_scene;
            code += Properties.Settings.Default.code_sample_mesh;
            code += Properties.Settings.Default.code_renderer;
            if (rbOrbit.IsChecked == true) { code += Properties.Settings.Default.code_orbit_add;  }
            code += Properties.Settings.Default.code_resize_listen;
            code += Properties.Settings.Default.code_func_end;
            code += Properties.Settings.Default.code_resize_func;
            code += Properties.Settings.Default.code_animate_start;
            code += Properties.Settings.Default.code_sample_mesh_animate;
            if (rbOrbit.IsChecked == true)  { code += Properties.Settings.Default.code_orbit_update;  }
            code += Properties.Settings.Default.code_animate_end;
            code += Properties.Settings.Default.code_html_end;
            return code;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "HTML Files (*.html)|*.html|Obj models(.obj,.gltf,.dae)|*.obj;*.gltf;*.dae";
            if(ofd.ShowDialog()==true)
            {
                try
                {
                    string ext = System.IO.Path.GetExtension(ofd.FileName);
                    if (ext.Contains("obj") || ext.Contains("gltf") || ext.Contains("dae"))
                    {
                        List<string> filenames =  FindDependencies(ofd.FileName);
                        string s="Resource files not found: \n";
                        int len = s.Length;
                        foreach(string f in filenames)
                        {
                            if (!File.Exists(f)) s += f + "\n";
                        }
                        if (len < s.Length) MessageBox.Show(s,"All files not found");
                        else Console.WriteLine($"All {filenames.Count} files found");
                    }
                    else
                    {
                        tbCode.Text = File.ReadAllText(ofd.FileName);
                        btNew.Content = "Save";
                        btNew.IsEnabled = false; // TODO: enable if changed
                    }
                }
                catch (FileNotFoundException ex) { tbCode.Text = ex.Message; }
            }
        }

        /// <summary>
        /// Find filenames contained in model file
        /// </summary>
        /// <param name="filename">Tiedostopäätteen tunniste obj, mtl tai gltf</param>
        private  List<string> FindDependencies(string filename)
        {
            // TODO: try
            List<string> lista = File.ReadLines(filename).ToList<string>();

            List<string> filenames = new List<string>();
            if (System.IO.Path.GetExtension(filename).EndsWith("obj"))
            {
                foreach (string s in lista)
                {
                    if (s.Contains("mtllib")) { filenames.Add(s.Split(' ')[1]); }
                }
                if (filenames.Count == 1)
                {
                    lista = File.ReadLines(filename).ToList<string>();
                    foreach (string s in lista)
                    {
                        if (s.Contains("map_Kd")) { filenames.Add(s.Split(' ')[1]); }
                    }
                }
            }
            else if (System.IO.Path.GetExtension(filename).EndsWith("mtl"))
            {
                foreach (string s in lista)
                {
                    if (s.Contains("map_Kd")) { filenames.Add(s.Split(' ')[1]); }
                }
            }
            //TODO: dae - xml, glTF - json
            else if (System.IO.Path.GetExtension(filename).EndsWith("gltf"))
            {
                try
                {
                    using (StreamReader file = File.OpenText(filename))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        Gltf model = (Gltf)serializer.Deserialize(file, typeof(Gltf));
                        if (model.buffers.Count > 0) { filenames.Add(System.IO.Path.GetDirectoryName(filename)+"\\"+model.buffers[0].uri); }
                    }
                }
                catch (FileNotFoundException ex) { }
            }
            else if (System.IO.Path.GetExtension(filename).EndsWith("dae"))
            {
                filenames.AddRange(TestReader(filename));
            }
            return filenames;
        }

        List<String> TestReader(string filename)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Async = true;
            List<string> filenames = new List<string>();

            using (XmlReader reader = XmlReader.Create(filename, settings))
            {
                string currElement = "";
                string unclosedElem = "";
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            //Console.WriteLine("Start Element {0}", reader.Name);
                            unclosedElem = currElement;
                            currElement = reader.Name;
                            break;
                        case XmlNodeType.Text:
                            //Console.WriteLine("Text Node: {0}", reader.Value);
                            if (currElement.Contains("init_from")) // <image><init_from>filename<init_from><image>
                            {
                                Console.WriteLine($"{reader.Value} {unclosedElem}");
                                if (unclosedElem.CompareTo("image") == 0)
                                {
                                    filenames.Add(System.IO.Path.GetDirectoryName(filename) + "\\" + reader.Value);
                                }
                            }
                            break;
                        case XmlNodeType.EndElement:
                            //Console.WriteLine("End Element {0}", reader.Name);
                            unclosedElem = "";
                            break;
                        default:
                            //Console.WriteLine("Other node {0} with value {1}", reader.NodeType, reader.Value);
                            break;
                    }
                }
                
            }
            return filenames;
        }

        private void cbLocal_Checked(object sender, RoutedEventArgs e)
        {
            int n1= tbCode.Text.IndexOf(Properties.Settings.Default.code_includes_start);
            int n2= tbCode.Text.IndexOf(Properties.Settings.Default.code_includes_start2);
            MessageBox.Show($"Rows {n1} - {n2}");
            btNew.IsEnabled = true;
        }

        // any rb
        private void rbNone_Checked(object sender, RoutedEventArgs e)
        {
            int n1 = tbCode.Text.IndexOf(Properties.Settings.Default.code_includes_start2);
            int n2 = tbCode.Text.IndexOf(Properties.Settings.Default.code_script_start);
            MessageBox.Show($"Rows {n1} - {n2}");
            if (rbOrbit != null  && rbOrbit.IsChecked == true)
            {
                tbCode.Text = tbCode.Text.Insert(n2, Properties.Settings.Default.code_orbit_include);
            }
            btNew.IsEnabled = true;
        }
    }
}
