﻿using StartupProject_Asp.NetCore_PostGRE.Data.Repository.RepositoryInterfaces;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Repository.Wrapper
{
	public interface IRepositoryWrapper
	{
		//List all Repository Interfaces in here (from RepositoryInterfaces) so that all can be accessable through this interface
		IOrderRepository Order { get; }
		IProductRepository Product { get; }
		IOrderProductRepository OrderProduct { get; }
		void SaveAsync();
	}
}