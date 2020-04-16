

using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace CineManager.Services
{
    public class CustomEmailTokenProv
    {
    }

    //Provedor personalizado para a validade do token de usuario de segurança
    public class CustomEmailTokenProv<TUser> : DataProtectorTokenProvider<TUser> where TUser : class
    {
        public CustomEmailTokenProv(IDataProtectionProvider dataProtectionProvider,
            IOptions<ConfimacaoEmailTokenOpt> options,
            ILogger<DataProtectorTokenProvider<TUser>> logger)
                                              : base(dataProtectionProvider, options, logger)
        {

        }
    }
    public class ConfimacaoEmailTokenOpt : DataProtectionTokenProviderOptions
    {
        public ConfimacaoEmailTokenOpt()
        {
            Name = "EmailDataProtectorTokenProvider";
            TokenLifespan = TimeSpan.FromHours(4);
        }
    }
}
