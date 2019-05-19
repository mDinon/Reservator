using Reservator.DAL.Repositories.Interfaces;
using Reservator.Model;
using Reservator.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Reservator.Service.Services
{
	public class ServiceBase
	{
		public readonly IUnitOfWork UnitOfWork;
		public ServiceBase(IUnitOfWork unitOfWork)
		{
			UnitOfWork = unitOfWork;
		}
	}
}
