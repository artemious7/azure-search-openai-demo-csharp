// Copyright (c) Microsoft. All rights reserved.

namespace MinimalApi.Extensions;

internal static class KeyVaultConfigurationBuilderExtensions
{
    internal static IConfigurationBuilder ConfigureAzureKeyVault(this IConfigurationBuilder builder)
    {
        var azureKeyVaultEndpoint = builder.Build().GetValue<string>("AZURE_KEY_VAULT_ENDPOINT");
        if (string.IsNullOrEmpty(azureKeyVaultEndpoint))
        {
            throw new InvalidOperationException("Azure Key Vault endpoint (\"AZURE_KEY_VAULT_ENDPOINT\") is not set.");
        }

        builder.AddAzureKeyVault(
            new Uri(azureKeyVaultEndpoint), new DefaultAzureCredential());

        return builder;
    }
}
