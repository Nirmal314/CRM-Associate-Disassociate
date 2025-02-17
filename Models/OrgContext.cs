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

[assembly: Microsoft.Xrm.Sdk.Client.ProxyTypesAssemblyAttribute()]

namespace ExampleProject
{
	
	
	/// <summary>
	/// Represents a source of entities bound to a Dataverse service. It tracks and manages changes made to the retrieved entities.
	/// </summary>
	public partial class OrgContext : Microsoft.Xrm.Sdk.Client.OrganizationServiceContext
	{
		
		/// <summary>
		/// Constructor.
		/// </summary>
		public OrgContext(Microsoft.Xrm.Sdk.IOrganizationService service) : 
				base(service)
		{
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="ExampleProject.cr267_Projecttask"/> entities.
		/// </summary>
		public System.Linq.IQueryable<ExampleProject.cr267_Projecttask> cr267_ProjecttaskSet
		{
			get
			{
				return this.CreateQuery<ExampleProject.cr267_Projecttask>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="ExampleProject.new_Project"/> entities.
		/// </summary>
		public System.Linq.IQueryable<ExampleProject.new_Project> new_ProjectSet
		{
			get
			{
				return this.CreateQuery<ExampleProject.new_Project>();
			}
		}
	}
}
#pragma warning restore CS1591
