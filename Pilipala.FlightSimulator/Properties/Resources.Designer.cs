﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pilipala.FlightSimulator.Properties {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Pilipala.FlightSimulator.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Aalborg	(GMT+01:00) Brussels, Copenhagen, Madrid, Paris	Denmark	57.02888870239258	9.917778015136719	Romance Standard Time
        ///Abbotsford, BC	(GMT-08:00) Pacific Time (US &amp; Canada); Tijuana	Canada	49.06638717651367	-122.30000305175781	Pacific Standard Time
        ///Aberdeen	(GMT) Dublin, Edinburgh, Lisbon, London	United Kingdom	57.150001525878906	-2.0999999046325684	GMT Standard Time
        ///Abidjan	(GMT) Greenwich Mean Time	Cote d&apos;Ivoire	5.336389064788818	-4.027777671813965	Greenwich Standard Time
        ///Abu Dhabi	(GMT+04:00) Abu  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Cities {
            get {
                return ResourceManager.GetString("Cities", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The line must be a tab seperated value with 6 elements..
        /// </summary>
        internal static string CityLineMistHaveSixElements {
            get {
                return ResourceManager.GetString("CityLineMistHaveSixElements", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The fourth and fifth elements of the tab seperated value must be the floating point representation of the latitude and longtitude..
        /// </summary>
        internal static string CityLineMustContainLatitudeAndLongtitude {
            get {
                return ResourceManager.GetString("CityLineMustContainLatitudeAndLongtitude", resourceCulture);
            }
        }
    }
}
