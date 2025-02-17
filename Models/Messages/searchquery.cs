#pragma warning disable CS1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExampleProject
{
	
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/new/")]
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("searchquery")]
	public partial class searchqueryRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public string entities
		{
			get
			{
				if (this.Parameters.Contains("entities"))
				{
					return ((string)(this.Parameters["entities"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["entities"] = value;
			}
		}
		
		public string search
		{
			get
			{
				if (this.Parameters.Contains("search"))
				{
					return ((string)(this.Parameters["search"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["search"] = value;
			}
		}
		
		public string orderby
		{
			get
			{
				if (this.Parameters.Contains("orderby"))
				{
					return ((string)(this.Parameters["orderby"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["orderby"] = value;
			}
		}
		
		public int top
		{
			get
			{
				if (this.Parameters.Contains("top"))
				{
					return ((int)(this.Parameters["top"]));
				}
				else
				{
					return default(int);
				}
			}
			set
			{
				this.Parameters["top"] = value;
			}
		}
		
		public bool count
		{
			get
			{
				if (this.Parameters.Contains("count"))
				{
					return ((bool)(this.Parameters["count"]));
				}
				else
				{
					return default(bool);
				}
			}
			set
			{
				this.Parameters["count"] = value;
			}
		}
		
		public int skip
		{
			get
			{
				if (this.Parameters.Contains("skip"))
				{
					return ((int)(this.Parameters["skip"]));
				}
				else
				{
					return default(int);
				}
			}
			set
			{
				this.Parameters["skip"] = value;
			}
		}
		
		public string propertybag
		{
			get
			{
				if (this.Parameters.Contains("propertybag"))
				{
					return ((string)(this.Parameters["propertybag"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["propertybag"] = value;
			}
		}
		
		public string facets
		{
			get
			{
				if (this.Parameters.Contains("facets"))
				{
					return ((string)(this.Parameters["facets"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["facets"] = value;
			}
		}
		
		public string options
		{
			get
			{
				if (this.Parameters.Contains("options"))
				{
					return ((string)(this.Parameters["options"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["options"] = value;
			}
		}
		
		public string filter
		{
			get
			{
				if (this.Parameters.Contains("filter"))
				{
					return ((string)(this.Parameters["filter"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["filter"] = value;
			}
		}
		
		public searchqueryRequest()
		{
			this.RequestName = "searchquery";
			this.search = default(string);
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/new/")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("searchquery")]
	public partial class searchqueryResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public searchqueryResponse()
		{
		}
		
		public string response
		{
			get
			{
				if (this.Results.Contains("response"))
				{
					return ((string)(this.Results["response"]));
				}
				else
				{
					return default(string);
				}
			}
		}
	}
}
#pragma warning restore CS1591
