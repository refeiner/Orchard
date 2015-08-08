﻿using Orchard.Environment.Configuration;
using Orchard.Environment.Extensions;
using Orchard.Localization;
using Orchard.Security;
using Orchard.UI.Navigation;

namespace Orchard.MultiTenancy {
    public class AdminMenu : INavigationProvider {
        private readonly ShellSettings _shellSettings;

        public AdminMenu(ShellSettings shellSettings) {
            _shellSettings = shellSettings;
        }

        public Localizer T { get; set; }

        public string MenuName { get { return "admin"; } }

        public void GetNavigation(NavigationBuilder builder) {
            if (_shellSettings.Name != ShellSettings.DefaultName)
                return;

            builder.Add(T("Tenants"), "90",
                menu => menu.Add(T("List"), "0", item => item.Action("Index", "Admin", new { area = "Orchard.MultiTenancy" })
                    .Permission(StandardPermissions.SiteOwner)));
        }
    }

    [OrchardFeature("Orchard.MultiTenancy.Commands")]
    public class CommandsAdminMenu : INavigationProvider
    {
        private readonly ShellSettings _shellSettings;

        public CommandsAdminMenu(ShellSettings shellSettings)
        {
            _shellSettings = shellSettings;
        }

        public Localizer T { get; set; }

        public string MenuName
        {
            get { return "admin"; }
        }

        public void GetNavigation(NavigationBuilder builder)
        {
            if (_shellSettings.Name != ShellSettings.DefaultName)
                return;

            builder.Add(T("Tenants"), "90",
                menu => menu.Add(T("Commands"), "1", item => item.Action("Index", "Commands", new { area = "Orchard.MultiTenancy" })
                    .Permission(StandardPermissions.SiteOwner)));

        }
    }
}
