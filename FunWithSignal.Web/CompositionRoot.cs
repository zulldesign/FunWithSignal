using System;
using System.Configuration;
using System.Web.Mvc;
using FunWithSignal.Domain.Repository;
using FunWithSignalDI.Web;

namespace FunWithSignal
{
    public class CompositionRoot
    {
        private readonly IControllerFactory _controllerFactory;
        private readonly System.Web.Http.Services.IDependencyResolver _dependencyResolver;

        public System.Web.Http.Services.IDependencyResolver DependencyResolver
        {
            get
            {
                return _dependencyResolver;
            }
        }

        public CompositionRoot()
        {
            IBlogPostRepository repository = CompositionRoot.InitializeRepository();
            _controllerFactory = new BlogControllerFactory(repository);
            _dependencyResolver = new WebApiDependencyResolver(repository);
        }

        private static IBlogPostRepository InitializeRepository()
        {
            string blogRepositoryTypeName = ConfigurationManager.AppSettings["BlogRepositoryType"];
            string connectionName = ConfigurationManager.ConnectionStrings["FunWithSignalDB"].Name;
            string schemaName = ConfigurationManager.AppSettings["schemaName"];
            var blogRepositoryType = Type.GetType(blogRepositoryTypeName, true);
            var repository = (IBlogPostRepository)Activator.CreateInstance(blogRepositoryType, new object[] { connectionName, schemaName });
            return repository;
        }

        public IControllerFactory ControllerFactory
        {
            get
            {
                return _controllerFactory;
            }
        }
    }
}