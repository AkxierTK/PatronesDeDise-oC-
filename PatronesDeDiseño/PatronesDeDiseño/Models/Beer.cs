using System;
using System.Collections.Generic;

namespace PatronesDeDiseño.Models;

//Esta clase ha sigo generada por EntityFramework Core SQL Server y EntityFrameworkCore.Tools
//Necesitas tener sql en local una vez implementados los paquetes y ejecutar 
//El comando de abajo debes remplazar ServerName, DataBase y OutPut Dir por la configuración correspondiente. Trusted_Connection=True es si la conexión es por Windows
//Scaffold-DbContext "Server=servername; Database=database; Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force para forzar
public partial class Beer
{
    public int BeerId { get; set; }

    public string Name { get; set; } = null!;

    public string Style { get; set; } = null!;
}
