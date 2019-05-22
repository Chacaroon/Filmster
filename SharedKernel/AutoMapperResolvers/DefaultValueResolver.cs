using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace SharedKernel.AutoMapperResolvers
{
	public class DefaultValueResolver : IMemberValueResolver<object, object, object, object>
	{
		public object Resolve(object source, object destination, object sourceMember, object destinationMember, ResolutionContext context)
		{
			return sourceMember ?? destinationMember;
		}
	}
}
