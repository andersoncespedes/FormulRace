using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Interface;
using Infrastructure.UnitOfWork;

namespace FormulRaceAPI.Extension;
public static class AppServiceExtension
{
    public static void AddExtension(this IServiceCollection services){
        services.AddScoped<IUnitOfWork,UnitOfWork>();
    }
}
