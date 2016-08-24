﻿//
// MonoBtlsX509LookupMethod.cs
//
// Author:
//       Martin Baulig <martin.baulig@xamarin.com>
//
// Copyright (c) 2016 Xamarin Inc. (http://www.xamarin.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
#if SECURITY_DEP
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

#if MONOTOUCH
using MonoTouch;
#endif

namespace Mono.Btls
{
	class MonoBtlsX509LookupMethod : MonoBtlsObject
	{
		internal class BoringX509LookupMethodHandle : MonoBtlsHandle
		{
			public BoringX509LookupMethodHandle (IntPtr handle)
				: base (handle, true)
			{
			}

			protected override bool ReleaseHandle ()
			{
				mono_btls_x509_lookup_method_free (handle);
				return true;
			}
		}

		new internal BoringX509LookupMethodHandle Handle {
			get { return (BoringX509LookupMethodHandle)base.Handle; }
		}

		[MethodImpl (MethodImplOptions.InternalCall)]
		extern static IntPtr mono_btls_x509_lookup_method_by_file ();

		[MethodImpl (MethodImplOptions.InternalCall)]
		extern static IntPtr mono_btls_x509_lookup_method_by_hash_dir ();

		[MethodImpl (MethodImplOptions.InternalCall)]
		extern static void mono_btls_x509_lookup_method_free (IntPtr handle);

		internal MonoBtlsX509LookupMethod (BoringX509LookupMethodHandle handle)
			: base (handle)
		{
		}

		public static MonoBtlsX509LookupMethod ByFile ()
		{
			var handle = mono_btls_x509_lookup_method_by_file ();
			if (handle == IntPtr.Zero)
				return null;
			return new MonoBtlsX509LookupMethod (new BoringX509LookupMethodHandle (handle));
		}

		public static MonoBtlsX509LookupMethod ByHashDir ()
		{
			var handle = mono_btls_x509_lookup_method_by_hash_dir ();
			if (handle == IntPtr.Zero)
				return null;
			return new MonoBtlsX509LookupMethod (new BoringX509LookupMethodHandle (handle));
		}
	}
}
#endif
