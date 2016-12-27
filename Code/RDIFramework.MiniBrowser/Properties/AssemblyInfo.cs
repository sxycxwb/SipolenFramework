using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("MiNiWeb 浏览器")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("XuWangBin")]
[assembly: AssemblyProduct("MiniWeb Browser")]
[assembly: AssemblyCopyright("Copyright © 柯锐特软件 2010-2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("eeccc379-2e61-479b-babd-84b7e29e9602")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("3.0.*")]
//[assembly: AssemblyFileVersion("3.0.*")]
// Require FullTrust permission
[assembly: PermissionSet(SecurityAction.RequestMinimum, Name="FullTrust")]
[assembly: CLSCompliant(true)]