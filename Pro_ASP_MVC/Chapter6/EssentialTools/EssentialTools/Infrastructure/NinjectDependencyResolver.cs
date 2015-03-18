﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using EssentialTools.Models;
using Ninject;

namespace EssentialTools.Infrastructure {
    public class NinjectDependencyResolver : IDependencyResolver {

        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel) {
            this.kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType) {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings() {
            kernel.Bind<IValueCalculator>().To<LinqValueCalculator>().InSingletonScope();
            kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithConstructorArgument("discountSize", 50m);
            kernel.Bind<IDiscountHelper>().To<FlexibleDiscountHelper>().WhenInjectedInto<LinqValueCalculator>();
        }
    }
}