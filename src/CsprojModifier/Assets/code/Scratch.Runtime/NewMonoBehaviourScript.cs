#nullable enable

global using UnityEngine;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEditor;
//using UnityEngine;

// file-scoped namespace (C# 10)
namespace Scratch.Runtime;

public class NewMonoBehaviourScript : MonoBehaviour
{
	[MenuItem("Blo/Log C# version")]
	static void LogCsharpVersion()
	{
		var mscorlib = typeof(object).Assembly;
		Debug.Log(@$"
Environment.Version: {Environment.Version}
FrameworkDescription: {RuntimeInformation.FrameworkDescription}
Assembly: {mscorlib}
	ImageRuntimeVersion: {mscorlib.ImageRuntimeVersion}
	AssemblyFileVersion: {mscorlib.GetCustomAttribute<AssemblyFileVersionAttribute>().Version}
CSHARP_7_3_OR_NEWER {Constants.CSHARP_7_3_OR_NEWER}
UNITY_EDITOR_ONLY_COMPILATION {Constants.UNITY_EDITOR_ONLY_COMPILATION}
NET_STANDARD {Constants.NET_STANDARD}
NET_STANDARD_2_0 {Constants.NET_STANDARD_2_0}
NET_STANDARD_2_1 {Constants.NET_STANDARD_2_1}
NETSTANDARD {Constants.NETSTANDARD}
NETSTANDARD2_1 {Constants.NETSTANDARD2_1}
NET_4_6 {Constants.NET_4_6}
NET_UNITY_4_8 {Constants.NET_UNITY_4_8}
".Trim());
	}

	void TestNullable1([CanBeNull] object o) { }
	void TestNullable2(object? o) { }
}

static class Constants
{
	public const bool NETSTANDARD =
#if NETSTANDARD
		true;
#else
		false;
#endif

	public const bool NETSTANDARD2_1 =
#if NETSTANDARD2_1
		true;
#else
		false;
#endif

	public const bool NET_STANDARD =
#if NET_STANDARD
		true;
#else
		false;
#endif

	public const bool NET_STANDARD_2_0 =
#if NET_STANDARD_2_0
		true;
#else
		false;
#endif

	public const bool NET_STANDARD_2_1 =
#if NET_STANDARD_2_1
		true;
#else
		false;
#endif

	public const bool CSHARP_7_OR_LATER =
#if CSHARP_7_OR_LATER
		true;
#else
		false;
#endif

	public const bool CSHARP_7_3_OR_NEWER =
#if CSHARP_7_3_OR_NEWER
		true;
#else
		false;
#endif

	public const bool UNITY_EDITOR_ONLY_COMPILATION =
#if UNITY_EDITOR_ONLY_COMPILATION
		true;
#else
		false;
#endif

	public const bool NET_4_6 =
#if NET_4_6
		true;
#else
		false;
#endif

	public const bool NET_UNITY_4_8 =
#if NET_UNITY_4_8
		true;
#else
		false;
#endif
}



/*--------- C# 10 --------*/

#region record struct (C# 10)

//public record RecordClass(int i);
public record struct RecordStruct(int i); // (C# 10)

#endregion

#region struct field initializer + default ctor (C# 10)

public struct StructFieldInitializer
{
	public int i = 3;

	public StructFieldInitializer() { }

	[MenuItem("Blo/StructFieldInitializer default")]
	static void Test()
	{
		Debug.Log(default(StructFieldInitializer).i);
		Debug.Log(new StructFieldInitializer().i);
	}
}

#endregion

#region extended property pattern (C# 10)

/* nope, misunderstood that one, it's for pattern matching not initialization
public class NestedPropertyInitializer // (C# 10)
{
	public GUIStyle style = new(GUI.skin.box)
	{
		alignment = TextAnchor.LowerCenter,
		normal = { background = Texture2D.blackTexture, },
		hover.background = Texture2D.blackTexture,
	};
}
*/

#endregion



/*--------- C# 11 ---------*/

#region generic attribute (C# 11)

public class GenericAttribute<T> : Attribute { }

[Generic<int>]
public class AnnotatedWithGenericAttribute { }


#endregion



/*--------- C# 11, unsupported by Unity's Mono ---------*/

#region static abstract in interfaces

#if (CSHARP_11 || UNITY_EDITOR_ONLY_COMPILATION) && false
interface IAbstract
{
	static abstract int Zero { get; }
}
#endif

#endregion

#region generic math (requires static abstract I suppose?)

#if (CSHARP_11 || UNITY_EDITOR_ONLY_COMPILATION) && false
static class GenericMath
{
	static T Add<T>(T left, T right)
		where T : System.Numerics.INumber<T>
	{
		return left + right;
	}
}
#endif

#endregion

#region file-scoped classes (C# 11, not supported in Unity's Mono)

#if (CSHARP_11 || UNITY_EDITOR_ONLY_COMPILATION) && false
file class HiddenClass
{
	public string Render()
	{
		return "Rendering file scoped Hidden Class";
	}
}
#endif

#endregion
