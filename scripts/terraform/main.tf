provider "azurerm" {
   features {
     key_vault {
      purge_soft_delete_on_destroy    = true
      recover_soft_deleted_key_vaults = true
    }
   }
}

data "azuread_client_config" "current" {}

resource  "azurerm_resource_group"  "article-app-rg" {
    name  =  "${var.kv_name}-rg"
    location  =  "West Europe"
}

resource "azurerm_key_vault" "article-kv" {
  name                        = "${var.kv_name}-kv"
  location                    = azurerm_resource_group.article-app-rg.location
  resource_group_name         = azurerm_resource_group.article-app-rg.name
  enabled_for_disk_encryption = true
  tenant_id                   = data.azurerm_client_config.current.tenant_id
  soft_delete_retention_days  = 7
  purge_protection_enabled    = false

  sku_name = "standard"

  access_policy {
    tenant_id = data.azurerm_client_config.current.tenant_id
    object_id = data.azurerm_client_config.current.object_id

    key_permissions = [
      "Get",
    ]

    secret_permissions = [
      "Get",
    ]

    storage_permissions = [
      "Get",
    ]
  }
}

resource "azurerm_key_vault_secret" "client-id-kv" {
  name         = "ArticleClientId"
  value        = var.api_client_id
  key_vault_id = azurerm_key_vault.article-kv.id
}

resource "azurerm_key_vault_secret" "client-secret-kv" {
  name         = "ArticleClientSecret"
  value        = var.api_secret
  key_vault_id = azurerm_key_vault.article-kv.id
}

resource "azurerm_key_vault_secret" "connection-string-kv" {
  name         = "ArticleConnectionString"
  value        = var.api_connection_string
  key_vault_id = azurerm_key_vault.article-kv.id
}

resource "azurerm_key_vault_secret" "tenant-id-kv" {
  name         = "SharedTenantId"
  value        = var.shared_tenant_id
  key_vault_id = azurerm_key_vault.article-kv.id
}

resource "azurerm_key_vault_secret" "domain-kv" {
  name         = "SharedDomain"
  value        = var.shared_domain
  key_vault_id = azurerm_key_vault.article-kv.id
}
