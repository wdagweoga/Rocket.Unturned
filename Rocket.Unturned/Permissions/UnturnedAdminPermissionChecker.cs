﻿using System.Threading.Tasks;
using Rocket.API.Permissions;
using Rocket.Core.ServiceProxies;
using Rocket.Unturned.Player;

namespace Rocket.Unturned.Permissions
{
    [ServicePriority(Priority = ServicePriority.Lowest)]
    public class UnturnedAdminPermissionChecker : IPermissionChecker
    {
        public bool SupportsTarget(IPermissionActor target)
        {
            if (target is UnturnedUser user)
                return user.Player.IsAdmin;

            return false;
        }

        public Task<PermissionResult> CheckPermissionAsync(IPermissionActor target, string permission) => Task.FromResult(PermissionResult.Grant);

        public string ServiceName { get; } = "Unturned Admin Checker";
    }
}