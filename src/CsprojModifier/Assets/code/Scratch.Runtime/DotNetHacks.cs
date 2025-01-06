#if !NET5_0_OR_GREATER
namespace System.Runtime.CompilerServices
{
	/// Allows support for C# 9 records in Mono.
	/// Must be declared in each assembly where it's used.
	internal static class IsExternalInit { }
}
#endif
