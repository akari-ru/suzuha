﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace suzuha.strings {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("suzuha.strings.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Help about suzuha commandline tool.
        /// </summary>
        internal static string help {
            get {
                return ResourceManager.GetString("help", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hello World Suzuhaa!.
        /// </summary>
        internal static string msgIntro {
            get {
                return ResourceManager.GetString("msgIntro", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Informations about suzuha.
        /// </summary>
        internal static string progamInfo {
            get {
                return ResourceManager.GetString("progamInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to suzuha.
        /// </summary>
        internal static string programName {
            get {
                return ResourceManager.GetString("programName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to v 0.07.
        /// </summary>
        internal static string programVersion {
            get {
                return ResourceManager.GetString("programVersion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure to quit suzuha ?.
        /// </summary>
        internal static string promptAbort {
            get {
                return ResourceManager.GetString("promptAbort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter the filepath: .
        /// </summary>
        internal static string promptFilepath {
            get {
                return ResourceManager.GetString("promptFilepath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to suzuha [subcommand] [flags] [file]*.
        /// </summary>
        internal static string usage {
            get {
                return ResourceManager.GetString("usage", resourceCulture);
            }
        }
    }
}
