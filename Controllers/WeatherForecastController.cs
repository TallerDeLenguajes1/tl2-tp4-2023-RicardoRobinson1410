using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Collections.Generic;
namespace tl2_tp4_2023_RicardoRobinson1410.Controllers;

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase
{
    private Cadeteria cadeteria;
    private readonly ILogger<CadeteriaController> _logger;

    public CadeteriaController(ILogger<CadeteriaController> logger)
    {
        _logger = logger;
        cadeteria=Cadeteria.GetCadeteria(@"C:\Users\USUARIO\tl2-tp4-2023-RicardoRobinson1410\Models\Cadeterias.json",@"C:\Users\USUARIO\tl2-tp4-2023-RicardoRobinson1410\Models\Cadetes .json");
           
    }   

    [HttpGet("GetPedidos")]
    public ActionResult<IEnumerable<Pedido>> GetPedidos()
    {
        return(Ok(cadeteria.GetPedidos()));
    }
    [HttpGet("GetCadetes")]
    public ActionResult<IEnumerable<Cadete>> GetCadetes()
    {
        return(Ok(cadeteria.GetCadetes()));  
    }

    [HttpGet("GetInforme")]
    public ActionResult<Informe> Getinforme()
    {
        return(Ok(cadeteria.Getinforme()));
    }

    [HttpPost("AgregarPedido")]
    public ActionResult<Pedido> AgregarPedido(Pedido pedido)
    {
        cadeteria.AgregarPedido(pedido);
        return(Ok(pedido));
    }

    [HttpPut("AsignarPedido")]

    public ActionResult<Pedido> AsignarPedido(int idPedido, int idCadete)
    {
        cadeteria.AsignarCadeteaPedidoPorId(idCadete,idPedido);
        return(Ok(cadeteria.buscarPedidoPorId(idPedido)));
    }

    [HttpPut("CambiarEstadoPedido")]
    public ActionResult<Pedido>CambiarEstadoPedido(int idPedido, int NuevoEstado)
    {
         var estado=(EstadoPedidos)NuevoEstado;
         if(estado==EstadoPedidos.aceptado)
         {
            cadeteria.AceptarPedido(idPedido);
         }else
         {
            cadeteria.RechazarPedido(idPedido);
         }
         return(Ok(cadeteria.buscarPedidoPorId(idPedido)));
    }

    [HttpPut("CambiarCadetePedido")]
    public ActionResult<Cadete> CambiarCadetePedido(int idPedido, int idNuevoCadete)
    {
        cadeteria.CambiarCadeteAPedido(idPedido,idNuevoCadete);
        return(Ok(cadeteria.buscarPedidoPorId(idPedido)));
    }
}
