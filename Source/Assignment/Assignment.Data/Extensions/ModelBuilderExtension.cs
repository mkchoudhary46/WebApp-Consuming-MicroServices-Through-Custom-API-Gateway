using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Assignment.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        //public static void ApplyConfigurationsFromAssembly(this ModelBuilder modelBuilder, Assembly assembly)
        //{
        //    var configurations = assembly.DefinedTypes.Where(t =>
        //        t.ImplementedInterfaces.Any(i =>
        //           i.IsGenericType &&
        //           i.Name.Equals(typeof(IEntityTypeConfiguration<>).Name,
        //                  StringComparison.InvariantCultureIgnoreCase)
        //         ) &&
        //         t.IsClass &&
        //         !t.IsAbstract &&
        //         !t.IsNested && t.Name.EndsWith("Map"))
        //         .ToList();

        //    foreach (var configuration in configurations)
        //    {
        //        var entityType = configuration.GetInterfaces().FirstOrDefault(c => c.Name.Equals(typeof(IEntityTypeConfiguration<>).Name)).GenericTypeArguments.SingleOrDefault(c => c.IsClass);
        //        if (entityType == null)
        //            continue;

        //        var applyConfigMethods = typeof(ModelBuilder).GetMethods().Where(m => m.Name.Equals("ApplyConfiguration") && m.IsGenericMethod);
        //        var applyConfigMethod = applyConfigMethods.Single(m => m.GetParameters().Any(p => p.ParameterType.Name.Equals(typeof(IEntityTypeConfiguration<>).Name)));

        //        var applyConfigGenericMethod = applyConfigMethod.MakeGenericMethod(entityType);

        //        applyConfigGenericMethod.Invoke(modelBuilder,
        //                     new object[] { Activator.CreateInstance(configuration) });
        //    }
        //}
    }
}
