# infrastructure

Azure resource templates for pieces of the deployment that live outside the
application code and the CI/CD pipeline.

## `logicapp_keepalive.json`

ARM deployment template for the **keep-api-alive** Logic App, which sends
`GET /api/skill` to the API every 20 minutes so the free-tier App Service instance
doesn't cold-start. See [ADR-007](../docs/decisions/ADR-007.md),
[ADR-008](../docs/decisions/ADR-008.md) and [ADR-009](../docs/decisions/ADR-009.md)
for the rationale. (ADR-008 was written for a 15-minute interval; the snapshot here
uses 20.)

This is a **hand-exported snapshot**, not the source of truth — the Logic App is
managed in the Azure portal, so changes made there won't appear here automatically.
Re-export (Logic App → Export template) after any portal change worth tracking.

Deploy with:

```bash
az deployment group create \
  --resource-group <rg> \
  --template-file logicapp_keepalive.json
```
