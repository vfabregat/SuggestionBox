// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Shrew.Web.DependencyResolution
{
    using System.Configuration;
    using System.Web.Mvc;
    using Raven.Client;
    using Raven.Client.Document;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using StructureMap.Web;
    public class DefaultRegistry : Registry
    {
        #region Constructors and Destructors

        public DefaultRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.LookForRegistries();
                    scan.AssemblyContainingType<DefaultRegistry>();
                    scan.AddAllTypesOf(typeof(IModelBinder));
                    scan.AddAllTypesOf(typeof(IModelBinderProvider));
                    scan.With(new ControllerConvention());
                });
            ForSingletonOf<IDocumentStore>().Use(() => CreateDocumentStore());

            For<IDocumentSession>().HybridHttpOrThreadLocalScoped()
                .Use(context => context.GetInstance<IDocumentStore>().OpenSession());

            For<IAsyncDocumentSession>().HybridHttpOrThreadLocalScoped()
                .Use(context => context.GetInstance<IDocumentStore>().OpenAsyncSession());


        }

        #endregion
        private IDocumentStore CreateDocumentStore()
        {
            var connectionStringName = ConfigurationManager.AppSettings["ConnectionStringName"] ?? "DefaultRavenDbConnection";

            var documentStore = new DocumentStore();
            documentStore.ConnectionStringName = connectionStringName;
            documentStore.Initialize();

            return documentStore;
        }
    }
}