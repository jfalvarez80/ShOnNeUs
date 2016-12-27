using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SfSoft.ShOnNeUs.Entities.Enums;

namespace SfSoft.ShOnNeUs.Entities
{
	public class ShutdownEntry
	{
		public MeasureUnit MeasureUnit { get; set; }

		public int PoolingTimeout { get; set; }

		public int PoolingSuccessCount { get; set; }
	}
}