﻿using MivaAccess.Configuration;
using MivaAccess.Models.Infrastructure;
using MivaAccess.Shared;
using System;

namespace MivaAccess.Models.Requests
{
	public class GetModifiedProductsRequest : MivaQuery
	{
		public GetModifiedProductsRequest( MivaCredentials credentials, DateTime lastMofiedDateUtc ) : base( credentials, "ProductList_Load_Query" )
		{
			this.Filters = new MivaRequestFilter[]
			{
				new MivaRequestSearchFilter(
					new MivaRequestFilterSearchValue[] { 
						new MivaRequestFilterSearchValue(){ Field = "dt_updated", Operator = "GE", Value = lastMofiedDateUtc.FromUtcTimeToEpoch().ToString() }
					}
				),
				new MivaRequestOnDemandFilter( new string[] { "descrip", "productimagedata", "categories" } )
			};
		}
	}
}