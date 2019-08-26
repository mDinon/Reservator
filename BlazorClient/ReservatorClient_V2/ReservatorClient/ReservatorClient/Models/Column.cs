using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservatorClient.Models
{
	public class Column
	{
		public string Path { get; set; }
		public string Label { get; set; }
		public RenderFragment Content { get; set; }
	}
}
