using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBeaverDesktop.Models
{
	public class User
	{
		public int ID { get; set; }
		public string Username { get; set; }
		public DateTime DateCreated { get; set; }
	}

	public class BudgetCategory
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public int DollarLimit { get; set; }
	}

	public class BudgetEntry
	{
		public int ID { get; set; }
		public DateTime DateEntered { get; set; }
		public int DollarAmount { get; set; }
		public int BudgetCategory { get; set; }
	}
}
