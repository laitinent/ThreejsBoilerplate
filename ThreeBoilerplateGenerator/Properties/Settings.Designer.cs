﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThreeBoilerplateGenerator.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.8.0.0")]
    public sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<script src=")]
        public string code_includes_start {
            get {
                return ((string)(this["code_includes_start"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\r\nfunction animate() {\r\n requestAnimationFrame( animate );\r\n")]
        public string code_animate_start {
            get {
                return ((string)(this["code_animate_start"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\r\n  renderer.render( scene, camera );\r\n}\r\n")]
        public string code_animate_end {
            get {
                return ((string)(this["code_animate_end"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(" var camera, scene, renderer;\r\n var mesh;\r\n")]
        public string code_global_vars {
            get {
                return ((string)(this["code_global_vars"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\r\nfunction onWindowResize() {\r\n  camera.aspect = window.innerWidth / window.inner" +
            "Height;\r\n  camera.updateProjectionMatrix();\r\n  renderer.setSize( window.innerWid" +
            "th, window.innerHeight );\r\n}\r\n")]
        public string code_resize_func {
            get {
                return ((string)(this["code_resize_func"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("window.addEventListener( \'resize\', onWindowResize, false );")]
        public string code_resize_listen {
            get {
                return ((string)(this["code_resize_listen"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(" renderer = new THREE.WebGLRenderer( { antialias: true } );\r\n renderer.setPixelRa" +
            "tio( window.devicePixelRatio );\r\n renderer.setSize( window.innerWidth, window.in" +
            "nerHeight );\r\n document.body.appendChild( renderer.domElement );\r\n")]
        public string code_renderer {
            get {
                return ((string)(this["code_renderer"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n <head>\r\n  <title>")]
        public string code_html_start {
            get {
                return ((string)(this["code_html_start"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\r\n  </script>\r\n </body>\r\n</html>")]
        public string code_html_end {
            get {
                return ((string)(this["code_html_end"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(" camera = new THREE.PerspectiveCamera( 70, window.innerWidth / window.innerHeight" +
            ", 1, 1000 );\r\n camera.position.z = 400;\r\n scene = new THREE.Scene();\r\n")]
        public string code_camera_scene {
            get {
                return ((string)(this["code_camera_scene"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(" var geometry = new THREE.BoxBufferGeometry( 200, 200, 200 );\r\n var material = ne" +
            "w THREE.MeshBasicMaterial( { color: \"red\"} );\r\n\r\n mesh = new THREE.Mesh( geometr" +
            "y, material );\r\n scene.add( mesh );\r\n")]
        public string code_sample_mesh {
            get {
                return ((string)(this["code_sample_mesh"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(" mesh.rotation.x += 0.005;\r\n mesh.rotation.y += 0.01;\r\n")]
        public string code_sample_mesh_animate {
            get {
                return ((string)(this["code_sample_mesh_animate"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(" init();\r\n animate();\r\n\r\n function init() {\r\n")]
        public string code_call_init_animate {
            get {
                return ((string)(this["code_call_init_animate"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<script>\r\n")]
        public string code_script_start {
            get {
                return ((string)(this["code_script_start"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\r\n}\r\n")]
        public string code_func_end {
            get {
                return ((string)(this["code_func_end"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"</title>
  <meta charset=""utf-8"">
  <meta name=""viewport"" content=""width=device-width, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0"">
  <style>
   body {
	margin: 0px;
	background-color: #000000;
	overflow: hidden;
   }
  </style>
 </head>
 <body>")]
        public string code_html_start2 {
            get {
                return ((string)(this["code_html_start2"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("></script>")]
        public string code_includes_start2 {
            get {
                return ((string)(this["code_includes_start2"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<script src=\"https://threejs.org/examples/js/controls/OrbitControls.js\"></script>" +
            "\r\n")]
        public string code_orbit_include {
            get {
                return ((string)(this["code_orbit_include"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("controls = new THREE.OrbitControls(camera, renderer.domElement);\r\n")]
        public string code_orbit_add {
            get {
                return ((string)(this["code_orbit_add"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("controls.update();\r\n")]
        public string code_orbit_update {
            get {
                return ((string)(this["code_orbit_update"]));
            }
        }
    }
}