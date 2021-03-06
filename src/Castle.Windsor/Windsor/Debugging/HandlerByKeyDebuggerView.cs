﻿// Copyright 2004-2010 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Castle.Windsor.Debugging
{
	using System.Diagnostics;

	using Castle.Core.Internal;
	using Castle.MicroKernel;

	[DebuggerDisplay("{Key} / [{ServiceString}]")]
	public class HandlerByKeyDebuggerView
	{
		public HandlerByKeyDebuggerView(string key, IHandler service)
		{
			Key = key;
			Service = service;
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string Key { get; private set; }

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public IHandler Service { get; private set; }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string ServiceString
		{
			get
			{
				var value = Service.Service.Name;
				var impl = Service.ComponentModel.Implementation;
				if (impl == Service.Service)
				{
					return value;
				}
				value += " / ";
				if (impl == null)
				{
					value += "no type";
				}
				else if (impl == typeof(LateBoundComponent))
				{
					value += "late bound type";
				}
				else
				{
					value += impl.Name;
				}
				return value;
			}
		}
	}
}