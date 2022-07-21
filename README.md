# About
Utilizzo del protocollo JsonRpc per esporre e interrogare una sorgente dati json

# Setup
1. Scaricare/clonare il repository
2. Aprire il file soluzione OilBackendProject.Web/OilBackendProject.sln
3. Sul progetto OilBackendProject.Web installare tramite nuget le dipendenze
4. Avviare il progetto  OilBackendProject.Web 

# Usage test
Sull'interfaccia Swagger inviare un richiesta con i seguenti parametri

<pre>
{
  "id": "1",
  "jsonrpc": "2.0",
  "method": "oil.getOilPriceTrend",
  "params": {
    "startDateISO8601": "2020-01-01",
     "endDateISO8601": "2020-01-05"
  }
}
</pre>
