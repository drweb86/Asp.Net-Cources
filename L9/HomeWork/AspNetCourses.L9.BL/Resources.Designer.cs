﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AspNetCourses.L9.BL {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AspNetCourses.L9.BL.Resources", typeof(Resources).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Login.
        /// </summary>
        public static string UserViewModel_Login {
            get {
                return ResourceManager.GetString("UserViewModel_Login", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Login must not exceed 255 chars..
        /// </summary>
        public static string UserViewModel_LoginLengthExceeds255Chars {
            get {
                return ResourceManager.GetString("UserViewModel_LoginLengthExceeds255Chars", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Name.
        /// </summary>
        public static string UserViewModel_Name {
            get {
                return ResourceManager.GetString("UserViewModel_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Name must not exceed 255 chars..
        /// </summary>
        public static string UserViewModel_NameLengthExceeds255Chars {
            get {
                return ResourceManager.GetString("UserViewModel_NameLengthExceeds255Chars", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Password.
        /// </summary>
        public static string UserViewModel_Password {
            get {
                return ResourceManager.GetString("UserViewModel_Password", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Password must not exceed 255 chars..
        /// </summary>
        public static string UserViewModel_PasswordLengthExceeds255Chars {
            get {
                return ResourceManager.GetString("UserViewModel_PasswordLengthExceeds255Chars", resourceCulture);
            }
        }
    }
}
