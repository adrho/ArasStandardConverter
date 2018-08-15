using System.Xml;
using System.IO;
using System.Configuration;
using System.Diagnostics;
using Aras.IOM;
using Aras.ConversionFramework.Converter;
using Aras.ConversionFramework.Utilities;
using System.Collections.Generic;
using System;

[assembly: CLSCompliant(true)]
namespace ArasStandardConverter
{
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
	public sealed class ArasStandardConverter : IConverter
	{
		public IList<FileConversionResult> Convert(ConversionContext context)
		{
			if (null == context)
			{
				throw new ArgumentNullException("context");
			}
			Aras.ConversionFramework.Models.ConversionTask thisTask = (Aras.ConversionFramework.Models.ConversionTask)context.ConversionTask;
			string userData = thisTask.UserData;
			if (!string.IsNullOrEmpty(userData))
			{
				Item result = thisTask.Item.apply(userData);
				if (result.isError())
				{
					throw new Aras.ConversionFramework.Exceptions.ItemErrorException(result);
				}
			}

			return new List<FileConversionResult>();
		}
		public void Dispose() { }
	}
}
